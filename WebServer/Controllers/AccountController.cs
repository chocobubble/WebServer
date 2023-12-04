using Microsoft.AspNetCore.Mvc;
using WebServer.Model;



namespace WebServer.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        static private Account currentAccount = new Account();
        //private static readonly string[] Summaries = new[]
        //{
        //"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "GetAccount")]
        //public IEnumerable<Account> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new Account
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}


        [HttpPost]
        public IActionResult AddId(string id, string pwd)
        {
            currentAccount.AddAccount(id, pwd);
            return Content(currentAccount.GetAccountNumber());
        }

        //[HttpGet(Name = "tuighNumber")]
        

        //[HttpGet]
        //public IActionResult PrintId(string id)
        //{

        //    return Content(currentAccount.PrintAccountInfo(id));

        //}
        [HttpGet]
        public IActionResult TuighNumber()
        {
            //return Content("string");
           return Content(currentAccount.GetAccountNumber());
        }

        //public IActionResult GETId2()
        //{
        //    return Content("");



        //}
    }
}