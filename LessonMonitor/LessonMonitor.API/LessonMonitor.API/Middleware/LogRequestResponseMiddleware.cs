using LessonMonitor.API.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace LessonMonitor.API.Middleware
{
    public class LogRequestResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public LogRequestResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            await LogRequest(request);

            await _next.Invoke(context);           
        }

        private static async Task LogRequest(HttpRequest request)
        {
            if (!request.Body.CanSeek)
                request.EnableBuffering();
            var body = await new StreamReader(request.Body).ReadToEndAsync();
            request.Body.Position = 0;

            var log = new LogModel
            {
                Protocol = request.Protocol,
                Method = request.Method,
                Scheme = request.Scheme,
                QueryString = request.QueryString.Value,
                Headers = request.Headers.Values,
                RequestBody = body,
            };

            log.Loging();
        }

    }
}
