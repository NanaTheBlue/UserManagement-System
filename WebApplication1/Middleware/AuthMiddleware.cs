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



            var user = await userService.GetUserFromSession(Guid.Parse(sessionId));
            if (user == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized: Invalid token.");
                return;
            }


            context.Items["User"] = user;





            await _next(context);
        }

    }
}
