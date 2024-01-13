using WebServer.Service.Interface;
using WebServer.Service;
using WebServer.Repository.Interface;
using WebServer.Repository;
using Microsoft.Net.Http.Headers;
using ProtobufFormatter.Formatters;
using ProtoBuf.Meta;
using WebServer.Filter;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
    options.OutputFormatters.Insert(0, new SessionProtobufOutputFormatter());
    options.InputFormatters.Insert(0, new SessionProtobufInputFormatter());
    options.FormatterMappings
        .SetMediaTypeMappingForFormat("protobuf",
          MediaTypeHeaderValue.Parse("application/x-protobuf"));
    // TODO: ㄷㅗㅣㄷㅗㄹㄹㅣㄱㅣ
    // options.Filters.Add<GlobalActionFilter>();
    // options.Filters.Add<GlobalExceptionFilter>();
});

/*
builder.Services.AddControllers(options =>
{
    options.FormatterMappings
        .SetMediaTypeMappingForFormat("protobuf",
          MediaTypeHeaderValue.Parse("application/x-protobuf"));
}).AddProtobufFormatters();
*/
// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddSingleton<IAccountService, AccountService>();
builder.Services.AddSingleton<ISessionService, SessionService>();
//builder.Services.AddSingleton<IAccountRepository, AccountRepository>();
builder.Services.AddSingleton<IAccountRepository, AccountFromRedis>();
//builder.Services.AddSingleton<ICharacterDataRepository, CharacterDataRepository>();
builder.Services.AddSingleton<ICharacterDataRepository, CharacterDataFromRedis>();
builder.Services.AddSingleton<ISessionRepository, SessionFromRedis>();
builder.Services.AddSingleton<IRankingService, RankingService>();
builder.Services.AddSingleton<IDataService, DataService>();
builder.Services.AddSingleton<IRankRepository, RankFromRedis>();
builder.Services.AddSingleton<ISqlService, SqlService>();


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

app.Run();
