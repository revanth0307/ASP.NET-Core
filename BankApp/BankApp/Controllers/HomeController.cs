using Microsoft.AspNetCore.Mvc;
using BankApp.Models;

namespace BankApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            Response.StatusCode = 200;
            return Content("Welcome to the Bank");
        }

        [Route("/account-details")]
        public IActionResult Account()
        {

            bankAccountDetails acc = new bankAccountDetails
            {
                accountNumber = 1001,
                accountHolderName = "Test",
                currentBalance = 50000
            };
            return Json(acc);
        }

        [Route("/account-statement")]
        public IActionResult AccountStatement()
        {
            Response.StatusCode=200;
            return File("/Sample.pdf", "application/pdf");
        }

        [Route("/get-current-balance/{accountNumber:int}")]
        public IActionResult Balance(int accountNumber)
        {
            if (accountNumber != 1001)
            {
                return BadRequest("Account Number should be 1001");
            }
            return Ok(5000);
            
        }
        [Route("/get-current-balance/")]
        public IActionResult NoBalance()

        {
     
            return NotFound("Account Number should be supplied");
        }


    }
}
