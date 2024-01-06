using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebServer.HttpCommand;
using WebServer.Service.Interface;

namespace WebServer.Filter
{
	public class GlobalActionFilter : ActionFilterAttribute
	{
        private readonly ISessionService _sessionService;

		public GlobalActionFilter(ISessionService sessionService)
		{
            _sessionService = sessionService;
		}

        //public override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    Console.WriteLine("1");
        //}

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    Console.WriteLine("2");
        //}

        //public override void OnResultExecuted(ResultExecutedContext filterContext)
        //{
        //    Console.WriteLine("3");
        //}

        //public override void OnResultExecuting(ResultExecutingContext filterContext)
        //{
        //    Console.WriteLine("4");
        //}

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //Console.WriteLine("aaaaaaaaa");

            var action = context.ActionArguments.FirstOrDefault();
            Console.WriteLine($"action : {action}");
            if (action.Value is BaseRequest)
            {
                //context.Result = new ContentResult() { Content = " ? ? ? ?" };
                //return Task.CompletedTask;

                BaseRequest request = (BaseRequest)action.Value;
                if (_sessionService.IsValidSession(request.sessionId))
                {
                    _sessionService.RefreshSessionId(request.sessionId);
                }
            }

            return base.OnActionExecutionAsync(context, next);
        }
    }
}

