using Microsoft.AspNetCore.Builder;

namespace JobSolution.Infrastructure.WebAuth
{
    public static class JwtProviderExtensions
    {
        public static IApplicationBuilder UseJwtProvider(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtTokenProvider>();
        }
    }
}
