using FoodPal.Auth.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FoodPal.Auth.RandomStuff
{
    public class ReverseProxyMiddleware
    {
        private readonly RequestDelegate next;
        public ReverseProxyMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var dbContext = context.RequestServices.GetService<AppIdentityContext>();

            var pathComponents = context.Request.Path.Value.Split("/", System.StringSplitOptions.RemoveEmptyEntries);

            if(pathComponents[0] == "api")
            {
                await next(context);
                return;
            }

            var targetApp = dbContext.ProxyApps.FirstOrDefault(w => w.AppName.ToLower() == pathComponents[0].ToLower());

            if(targetApp == null)
            {
                // return 404
                context.Response.StatusCode = 404;
                var contentWriter = new StringContent("Your princess is in another castle.");
                await context.Response.Body.WriteAsync(await contentWriter.ReadAsByteArrayAsync());
                return;
            }

            var requestMessage = await CreateRequestMessage(context);
            requestMessage.RequestUri = BuildTargetUri(targetApp.AppUrl, context);

            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(requestMessage);
                context.Response.StatusCode = (int)response.StatusCode;
                CopyFromTargetResponseHeaders(context, response);
                await response.Content.CopyToAsync(context.Response.Body);
                return;
            }

            await next(context);
        }

        private async Task<HttpRequestMessage> CreateRequestMessage(HttpContext context)
        {
            var result = new HttpRequestMessage();
            result.Method = GetMethod(context.Request.Method);

            if(!(new List<HttpMethod> { HttpMethod.Get, HttpMethod.Delete }).Contains(result.Method))
            {
                var contentType = context.Request.Headers.ContainsKey("Content-Type") ? context.Request.Headers["Content-Type"][0].Split(';')?[0] ?? context.Request.Headers["Content-Type"][0] : "application/json";
                var requestBody = "";
                using(StreamReader sr = new StreamReader(context.Request.Body))
                {
                    requestBody = await sr.ReadToEndAsync();
                }

                var streamContent = new StringContent(requestBody, System.Text.Encoding.UTF8, contentType);
                result.Content = streamContent;
            }

            foreach(var header in context.Request.Headers)
            {
                result.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
            }

            return result;
        }

        private static HttpMethod GetMethod(string method)
        {
            if (HttpMethods.IsDelete(method)) return HttpMethod.Delete;
            if (HttpMethods.IsGet(method)) return HttpMethod.Get;
            if (HttpMethods.IsHead(method)) return HttpMethod.Head;
            if (HttpMethods.IsOptions(method)) return HttpMethod.Options;
            if (HttpMethods.IsPost(method)) return HttpMethod.Post;
            if (HttpMethods.IsPut(method)) return HttpMethod.Put;
            if (HttpMethods.IsTrace(method)) return HttpMethod.Trace;
            return new HttpMethod(method);
        }

        private void CopyFromTargetResponseHeaders(HttpContext context, HttpResponseMessage responseMessage)
        {
            foreach (var header in responseMessage.Headers)
            {
                context.Response.Headers[header.Key] = header.Value.ToArray();
            }

            foreach (var header in responseMessage.Content.Headers)
            {
                context.Response.Headers[header.Key] = header.Value.ToArray();
            }

            context.Response.Headers.Remove("transfer-encoding");
        }

        private Uri BuildTargetUri(string targetHost, HttpContext context)
        {
            var baseUrl = targetHost.EndsWith('/') ? targetHost.Substring(0, targetHost.Length - 1) : targetHost;
            var pathComp = context.Request.Path.Value.Split("/", System.StringSplitOptions.RemoveEmptyEntries);

            return new Uri($"{baseUrl}/{string.Join("/", pathComp.Skip(1))}");
        }
    }
}
