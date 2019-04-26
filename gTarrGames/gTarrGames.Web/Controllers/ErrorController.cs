using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gTarrGames.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ViewResult Index()
        {
            return View("Error");
        }
        public ViewResult Ok()
        {
            Response.StatusCode = 200; //I may want to set this to 200
            return View("Ok");
        }
        public ViewResult Created()
        {
            Response.StatusCode = 201; //I may want to set this to 200
            return View("Created");
        }
        public ViewResult Accepted()
        {
            Response.StatusCode = 202; //I may want to set this to 200
            return View("Accepted");
        }
        public ViewResult NoContent()
        {
            Response.StatusCode = 204; //I may want to set this to 200
            return View("NoContent");
        }
        public ViewResult BadRequest()
        {
            Response.StatusCode = 400; //I may want to set this to 200
            return View("BadRequest");
        }
        public ViewResult Unauthorized()
        {
            Response.StatusCode = 401; //I may want to set this to 200
            return View("Unauthorized");
        }
        public ViewResult Forbidden()
        {
            Response.StatusCode = 403; //I may want to set this to 200
            return View("Forbidden");
        }
        public ViewResult NotFound()
        {
            Response.StatusCode = 404; //I may want to set this to 200
            return View("NotFound");
        }
        public ViewResult MethodNotAllowed()
        {
            Response.StatusCode = 405; //I may want to set this to 200
            return View("MethodNotAllowed");
        }
        public ViewResult RequestTimeout()
        {
            Response.StatusCode = 408; //I may want to set this to 200
            return View("RequestTimeout");
        }
        public ViewResult LengthRequired()
        {
            Response.StatusCode = 411; //I may want to set this to 200
            return View("LengthRequired");
        }
        public ViewResult InternalServerError()
        {
            Response.StatusCode = 500; //I may want to set this to 200
            return View("InternalServerError");
        }
        public ViewResult NotImplemented()
        {
            Response.StatusCode = 501; //I may want to set this to 200
            return View("NotImplemented");
        }
        public ViewResult BadGateway()
        {
            Response.StatusCode = 502; //I may want to set this to 200
            return View("BadGateway");
        }
        public ViewResult ServiceUnavailable()
        {
            Response.StatusCode = 503; //I may want to set this to 200
            return View("ServiceUnavailable");
        }
    }
}