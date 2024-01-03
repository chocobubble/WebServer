using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebServer.HttpCommand;

namespace WebServer.Filter
{
	public class GlobalActionFilter : ActionFilterAttribute
	{
		public GlobalActionFilter()
		{
		}

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("aaaaaaaaa");

            var action = context.ActionArguments.FirstOrDefault();
            if (action.Value is BaseRequest)
            {
                // ���ǰ˻�
                // ���� �˻縦 �����ϸ�?
                // ����
                context.Result = new ContentResult() { Content = " ? ? ? ?" };
                return Task.CompletedTask;
            }


            return base.OnActionExecutionAsync(context, next);
        }
    }
}

