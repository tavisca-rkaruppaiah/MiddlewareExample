using Microsoft.AspNetCore.Builder;

namespace MiddlewareExample.Middleware
{
    public static class MyMiddleWareExtensions
    {
        public static IApplicationBuilder UseMyMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleWare>();
        }
    }
}
