using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore")]
        //lets say in future we updated the url , so for existing cust to not impact we will redirect that url to another url , so even when they use old url we will redirect this to new url, this concept called Redirect -- so to implement that we created another controller- StoreController.cs
        // so at last after validations we will redirect that -- refer last line of code (50)
        public IActionResult Index()
        {
            //book id should be applied
            if (!Request.Query.ContainsKey("bookid"))
            {
                //Response.StatusCode = 400;
                return BadRequest("Book id is not supplied");
            }
            //book id cant be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
               // Response.StatusCode = 400;

                return BadRequest("book id cant be null/empty");
            }

            //book id should be 1-1000
            int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
            //the above is correct way to access the request object

            if (bookId <= 0)
            {
                // Response.StatusCode = 404;
                //return new BadRequest();

               // return Content("book id cant be less than or equal to zero");
                return BadRequest("book id cant be less than or equal to zero");
            }
            if (bookId > 1000)
            {
              //  Response.StatusCode = 404;

                return NotFound("book id cant be greater than 1000");
            }
            //isloggedin should true
            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                //Response.StatusCode = 401;
                return Unauthorized("user must be authenticated");
            }

            //return File("/sample.pdf", "application/pdf"); -- instead of going to file we r redirecting to

            //return new RedirectToActionResult("Books","Store",new  { },true); // RedirectResult("actionmethod","controlername")
            return  RedirectToActionPermanent("Books", "Store", new {id=bookId }); // RedirectResult("actionmethod","controlername")


            // so if used     public ContentResult Index() 'ContentResult' then we cant use File result 
            // so if we change from ContentResult to FileResult then we cnat sue other Content (which is use to return Content())

            // so we use IActionResult in place of those child actions:

            //The IActionResult is the parent interface for all the action results in ASP.NET Core.That is ContentResult, JSONResult, RedirectResult,

            //FileResult.All these are children of IActionResult interface.
        }
    }
}
