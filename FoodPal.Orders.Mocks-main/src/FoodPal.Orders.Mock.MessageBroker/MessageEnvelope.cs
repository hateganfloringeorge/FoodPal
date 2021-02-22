using System;

namespace FoodPal.Orders.Mock.MessageBroker
{
	public class MessageEnvelope<T>
	{
		public string RequestId { get; set; }

		public string MessageType { get; set; }

		public T Data { get; set; }

		public MessageEnvelope() { }

		public MessageEnvelope(string messageType, T payload) : this(messageType, payload, Guid.NewGuid()) { }

		public MessageEnvelope(string messageType, T payload, Guid requestId)
		{
			MessageType = messageType;
			Data = payload;
			RequestId = requestId.ToString();
		}
	}
}
