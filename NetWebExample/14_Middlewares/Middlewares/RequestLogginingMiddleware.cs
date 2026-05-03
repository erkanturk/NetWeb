namespace _14_Middlewares.Middlewares
{
    public class RequestLogginingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLogginingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var message = $"Middleware Çalıştı: {context.Request.Path}";
            context.Items["MiddlewareMessage"] = message;
            await _next(context);
            Console.WriteLine("Yanıt gönderildi:"+context.Response.StatusCode);
        }
    }
}
