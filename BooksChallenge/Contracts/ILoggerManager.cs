namespace Contracts
{
	/// <summary>
	/// The logger interface.
	/// </summary>
	public interface ILoggerManager
	{
		/// <summary>
		/// Log for debug.
		/// </summary>
		/// <param name="message"></param>
		void LogDebug(string message);

		/// <summary>
		/// Log for informations.
		/// </summary>
		/// <param name="message"></param>
		void LogInfo(string message);

		/// <summary>
		/// Log for warnings.
		/// </summary>
		/// <param name="message"></param>
		void LogWarn(string message);

		/// <summary>
		/// Log for errors.
		/// </summary>
		/// <param name="message"></param>
		void LogError(string message);
	}
}