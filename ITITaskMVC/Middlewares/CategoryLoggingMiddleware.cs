namespace ITITaskMVC.Middlewares
{
	public class CategoryLoggingMiddleware
	{
		private readonly RequestDelegate _next;

		public CategoryLoggingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var category = context.Request.Query["category"];
			if (!string.IsNullOrEmpty(category))
			{
				Console.WriteLine($"Category Filter Applied: {category}");
			}
			await _next(context);
		}
	}

	public static class MiddlewareExtensions
	{
		public static IApplicationBuilder UseCategoryLogging(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<CategoryLoggingMiddleware>();
		}
	}

}
