namespace FoodPal.Orders.Mock.Dtos
{
	public class ErrorInfoDto
	{
		public ErrorInfoType Type { get; set; }
		public string Message { get; set; }
		public string Details { get; set; }
	}

	public enum ErrorInfoType
	{
		Info,
		Warning,
		Error
	}
}
