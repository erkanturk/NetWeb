namespace _14_Middlewares.Middlewares
{
    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLogginingMiddleware>();
        }
    }
}
