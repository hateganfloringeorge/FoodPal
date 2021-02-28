using FluentValidation;
using FoodPal.Notifications.Dto.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPal.Notifications.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static void ValidateAndThrowEx<T>(this IValidator<T> validator, T o)
        {
            var result = validator.Validate(o);
            if (!result.IsValid)
            {
                throw new ValidationsException(result.Errors.Select(x => x.ErrorMessage).ToList());
            }
        }
    }
}