using WebServer.Service.Interface;
using WebServer.Service;
using WebServer.Repository.Interface;
using WebServer.Repository;
using Microsoft.Net.Http.Headers;
using ProtobufFormatter.Formatters;
using CustomFormattersSample.Formatters;
using ProtoBuf.Meta;

var builder = WebApplication.CreateBuilder(args);
// protobuf
/*
builder.Services.AddControllers(options =>
{
    //options.InputFormatters.Insert(0, new SessionProtobufInputFormatter());
    options.OutputFormatters.Insert(0, new SessionProtobufOutputFormatter());
   // options.FormatterMappings.SetMediaTypeMappingForFormat("protobuf", MediaTypeHeaderValue.Parse("application/x-protobuf"));
});*/
builder.Services.AddControllers(options =>
{
    options.OutputFormatters.Insert(0, new SessionProtobufOutputFormatter());

    options.FormatterMappings
        .SetMediaTypeMappingForFormat("protobuf",
          MediaTypeHeaderValue.Parse("application/x-protobuf"));
});
// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddSingleton<IAccountService, AccountService>();
builder.Services.AddSingleton<IAccountRepository, AccountRepository>();
builder.Services.AddSingleton<ICharacterDataRepository, CharacterDataRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// gRPC
builder.Services.AddGrpc();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// gRPC
app.MapGrpcService<GreeterService>();
app.MapGrpcService<LoadService>();

app.Run();
