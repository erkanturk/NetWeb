using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _15_Filter_Operation.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        
        public void OnAuthorization(AuthorizationFilterContext context)
        { 
            var user=context.HttpContext.User;//Sisteme giriş yapan kullanıcı
            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
            

        }
    }
}
