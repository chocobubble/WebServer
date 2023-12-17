﻿using System;
using System.Text;
using System.Threading.Tasks;
using CustomFormattersSample.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using ProtoBuf;
using ProtoBuf.Meta;
using WebServer.Protos;

namespace ProtobufFormatter.Formatters
{
    public class SessionProtobufOutputFormatter : OutputFormatter
    {

        private static Lazy<RuntimeTypeModel> model = new Lazy<RuntimeTypeModel>(CreateTypeModel);

        public string ContentType { get; private set; }

        public static RuntimeTypeModel Model
        {
            get { return model.Value; }
        }

        public SessionProtobufOutputFormatter()
        {
            ContentType = "application/x-protobuf";
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/x-protobuf"));

            //SupportedEncodings.Add(Encoding.GetEncoding("utf-8"));
        }

        private static RuntimeTypeModel CreateTypeModel()
        {
            var typeModel = RuntimeTypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            return typeModel;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var response = context.HttpContext.Response;
            MemoryStream stream = new MemoryStream();
            Model.Serialize(stream, context.Object);
            var data = stream.ToArray();
            await response.Body.WriteAsync(data, 0, data.Length);
        }
    }

    public class SessionProtobufInputFormatter : InputFormatter
    {
        private static Lazy<RuntimeTypeModel> model = new Lazy<RuntimeTypeModel>(CreateTypeModel);

        public static RuntimeTypeModel Model
        {
            get { return model.Value; }
        }

        public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            var type = context.ModelType;
            var request = context.HttpContext.Request;
            MediaTypeHeaderValue requestContentType = null;
            MediaTypeHeaderValue.TryParse(request.ContentType, out requestContentType);


            object result = Model.Deserialize(context.HttpContext.Request.Body, null, type);
            return InputFormatterResult.SuccessAsync(result);
        }

        public override bool CanRead(InputFormatterContext context)
        {
            return true;
        }


        private static RuntimeTypeModel CreateTypeModel()
        {
            var typeModel = RuntimeTypeModel.Default;
            typeModel.UseImplicitZeroDefaults = false;
            return typeModel;
        }
    }

    
}


