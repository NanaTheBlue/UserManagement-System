using WebApplication1.Services;

namespace WebApplication1.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
      


        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {

            var sessionId = context.Request.Cookies["sessionId"];
            if (sessionId == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized: No token provided.");
                return;
            }



            // Here you would typically validate the token and set the user context
            // For example, you could decode the token, verify its signature, and check its expiration
            // If the token is valid set the user context (e.g., using HttpContext.Items)

            userService.
            //get session from database using sessionId, then get user from database using session.UserId, then set user context to user


            // context.Items["User"] = decodedUser;





            await _next(context);
        }

    }
}
