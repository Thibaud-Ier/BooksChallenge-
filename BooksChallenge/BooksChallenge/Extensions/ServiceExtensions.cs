using Contracts;
using LoggerService;
using Microsoft.Extensions.DependencyInjection;

namespace BooksChallenge.Extensions
{
	internal static class ServiceExtensions
	{
		public static void ConfigureLoggerService(this IServiceCollection services) =>
			services.AddScoped<ILoggerManager, LoggerManager>();
	}
}