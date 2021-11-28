using Newtonsoft.Json;

namespace Entities.ErrorModel
{
	/// <summary>
	/// Represents an error.
	/// </summary>
	public class ErrorDetails
	{
		/// <summary>
		/// The status of the error.
		/// </summary>
		public int StatusCode { get; set; }

		/// <summary>
		/// The message of the error.
		/// </summary>

		public string Message { get; set; }

		///<inheritdoc />
		public override string ToString() => JsonConvert.SerializeObject(this);
	}
}