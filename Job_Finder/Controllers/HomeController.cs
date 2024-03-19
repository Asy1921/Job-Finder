using Microsoft.AspNetCore.Mvc;
using BAL;
using Models;
[ApiController]
public class HomeController : Controller
{
    [HttpPost]
    [Route("[controller]/AddUpdateUser")]

    public ActionResult<string> AddUpdateUser(UserDetails Data)
    {

        BusinessOperations BOps = new BusinessOperations();
        string ReturnData = BOps.AddUpdateUser(Data);
        var route = Request.Path.Value;


        if (ReturnData == null)
        {
            var Response = NotFound();
            //Save Log
            return Response;
        }
        else
        {
            var Response = Ok(ReturnData);
            //Save Log
            return Response;
        }
    }
    [HttpGet]
    [Route("[controller]/User")]

    public ActionResult<string> GetUserDetails()
    {


        BusinessOperations BOps = new BusinessOperations();
        (string ReturnData, string status) = ("test", "test");
        var route = Request.Path.Value;


        if (ReturnData == null)
        {
            var Response = NotFound(status);
            // Save Log
            return Response;
        }
        else
        {
            var Response = Ok(ReturnData);
            // Save Log
            return Response;
        }
    }
}