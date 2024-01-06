using System;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using WebServer.HttpCommand;
using ProtoBuf;
using System.Text;

namespace WebServer.Filter
{
	public class GlobalExceptionFilter : IExceptionFilter
	{
		public GlobalExceptionFilter()
		{
        }

        public void OnException(ExceptionContext context)
        {
            Console.WriteLine("GlobalExceptionFilter - OnException");
            //throw new NotImplementedException();

            BaseResponse baseResponse = new BaseResponse();
            baseResponse.apiReturnCode = ApiReturnCode.InvalidSessionId;

            //context.Result = new ContentResult() { Content = JsonSerializer.Serialize(baseResponse) };
            
            MemoryStream memoryStream = new MemoryStream();
            Serializer.Serialize(memoryStream, baseResponse);
            byte[] bytes;
            bytes = memoryStream.ToArray();
            context.Result = new ContentResult() { Content = Encoding.Default.GetString(bytes) };
        }
    }
}

