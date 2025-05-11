using System.Diagnostics;

namespace WebApplication1.MiddleWare
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimingMiddleware> _logger;

        public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            await _next(context);
            watch.Stop();

            _logger.LogInformation($"Request [{context.Request.Method}] {context.Request.Path} took {watch.ElapsedMilliseconds} ms");
        }
    }
}
