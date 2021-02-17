﻿using System;

namespace FoodPal.Orders.MessageBroker.Contracts
{
	public class MessageBrokerEnvelope<TPayload>
	{
		public string RequestId { get; set; }

		public string MessageType { get; set; }

		public TPayload Data { get; set; }

		public MessageBrokerEnvelope() { }

		public MessageBrokerEnvelope(string messageType, TPayload payload) : this(messageType, payload, Guid.NewGuid().ToString()) { }

		public MessageBrokerEnvelope(string messageType, TPayload payload, string requestId)
		{
			MessageType = messageType;
			Data = payload;
			RequestId = requestId;
		}
	}
}