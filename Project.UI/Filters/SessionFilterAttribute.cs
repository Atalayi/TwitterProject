using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Project.UI.Filters
{
    public class SessionFilterAttribute : ActionFilterAttribute
    {
        private readonly bool _sessionState;

        public SessionFilterAttribute(bool sessionState)
        {
            _sessionState = sessionState;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userIdString = context.HttpContext.Session.GetString("UserId");

            var state = int.TryParse(userIdString, out int userId);

            if (_sessionState) // session olması gerekiyor
            {
                if (!state)
                {
                    context.Result = new RedirectResult("/Account/Login");
                }
            }
            else // session olmaması gerekiyor
            {
                if (state)
                {
                    context.Result = new RedirectResult("/Home/Index");
                }
            }
        }

    }
}
