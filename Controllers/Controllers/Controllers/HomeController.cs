using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;
namespace ControllersExample.Controllers

{
   public class HomeController: Controller    //the clas name should suffixed with 'Controller' so the csharp compier will know that it is controller class automatically
    {
        //just above the method we need add route attribute

        [Route("home")]
        // so whenever the url is localhost://port/hello --->then the below will execute
        // we can add multiple action methods , so baded on that the below will execute 
        [Route("/")] // def url localhost:port will also give the below msg without error


        public ContentResult Index()
        {
            //return new ContentResult()
            //{
            //    Content = "Hello from index",
            //    ContentType = "text/plain"
            //};

            //we can use above but lenght, so we using Microsft.Mvc.controlers and acces the in built methods and senf those in arguments

            //  return Content("Hello from index", "text/plain");
            return Content("<h1>Welcome Revanth<h1> <h2>Hello from Index</h2>", "text/html");
        }

        //jsonResult
        [Route("person")]
        public JsonResult Person()
        {
            //   return "{\"key\":\"value\"}"; -- it will hard to remeber the quotes syntax so we can use jsonObj
            //so create a sep folder -Models and in that declare the class and implementation and here return the json

            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Revanth",
                LastName = "Bandaru",
                Age = 22
            };
           // return JsonResult(person);  -- or else we can wright like this:
           return Json(person); 
            

        }

        // static files:
        //create  a folder wwwroot and add a sample pdf 

        [Route("file-download")]
        public VirtualFileResult FileDownload() //VrtualFileResult is used when file is in wwwroot folder
        {
            // return new VirtualFileResult("/sample.pdf","application/pdf"); -- instead of new we can return:
            return File("/sample.pdf", "application/pdf");

            // -- nameMthod("path","contentType")

        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            //  return new PhysicalFileResult(@"C:\Users\Admin\Downloads\Sample.pdf", "application/pdf");

            return PhysicalFile(@"C:\Users\Admin\Downloads\Sample.pdf", "application/pdf");
            // -- nameMthod("path","contentType")

        }


        [Route("about")]
        public string About()
        {
            return "Hi form About";
        }

        [Route("contact/{mobile:regex(^\\d{{10}}$)}")] // we can give rote constraints also
        public string Contact()
        {
            return "Hi form Contact";
        }
    }
    //Technically, this is the controller, but it doesn't work directly.
    //if we run the code by here it will error out 404 or it just prints from prgm.cs 'Hello'
    //In order to make it work, we require to do two things.
    //One is, we require to add this controller class as a service class.so that it can participate in the dependency injection.
    //ie:  builder.Services.AddControllers(); --in prgm.cs
//And the second one is, we require to enable the routing for this method.
//ie:app.MapControllers(); -- in prgm.cs 
}
