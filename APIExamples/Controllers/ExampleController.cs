using APIExamples.DataAccessLayer;
using APIExamples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace APIExamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class ExampleController : ControllerBase
    {
        public DBServices _dbServices { get; set; }

        public ExampleController(DBServices dbServices)
        {
            _dbServices = dbServices;
        }

        [HttpGet]
        [Route("/action1")]
        public string Action1()
        {
            return "Test!";
        }

        [HttpGet]
        [Route("/action2")]
        public string Action2()
        {
            var p1 = Request.Query["par1"];
            var p2 = Request.Query["par2"];

            return p1 + " " + p2;
        }

        [HttpGet]
        [Route("/action3")]
        public string Action3([FromQuery] string par1, [FromQuery] int par2)
        {
            var p1 = par1;
            var p2 = par2;

            return p1 + " " + p2;
        }

        [HttpPost]
        [Route("/action4")]
        public string Action4()
        {
            var p1 = Request.Form["par1"];
            var p2 = Request.Form["par2"];

            return p1 + " " + p2;
        }

        [HttpPost]
        [Route("/action5")]
        public string Action5([FromForm] string par1, [FromForm] int par2)
        {
            var p1 = par1;
            var p2 = par2;


            return p1 + " " + p2;
        }

        [HttpPost]
        [Route("/action6")]
        public async Task<string> Action6()
        {
            byte[] byteArray = new byte[(int)Request.ContentLength];
            await Request.Body.ReadAsync(byteArray, 0, (int)Request.ContentLength);

            return System.Text.Encoding.UTF8.GetString(byteArray);

            System.IO.StreamReader data = new System.IO.StreamReader(Request.Body);

            return await data.ReadToEndAsync();
        }

        [HttpPost]
        [Route("/action7")]
        public string Action7([FromBody] User obj)
        {
            return obj.FirstName;
        }

        [HttpGet]
        [Route("/action8")]
        public string Action8()
        {
            string cookies = Request.Cookies["grandmother-cookies"];
            string header = Request.Headers["scope"];
            return $"{cookies} {header}";
        }

        [HttpGet]
        [Route("/action9")]
        public string Action9()
        {
            Response.Cookies.Append("grandfather-cookies", "some value");
            Response.Headers.Add("credentials", "login info");

            return "";
        }

        [HttpGet]
        [Route("action10/{id}")]
        public string Action10(int id)
        {
            return _dbServices.GetScope(id);
        }

        [HttpGet]
        [Route("action11/{id}")]
        public string Action11([FromServices] DBServices services, int id)
        {
            return services.GetScope(id);
        }

        [HttpPost]
        [Route("/uploadfile")]
        public async Task<string> UploadFile([FromBody] IFormFile image)
        {
            MemoryStream stream = new MemoryStream();
            try
            {
                await image.CopyToAsync(stream);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return stream.Length.ToString();
        }

        [HttpGet]
        [Route("/downloadimage")]
        public async Task<IActionResult> DownloadImage()
        {
            byte[] buff = System.IO.File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "1.jpg"));
            MemoryStream stream = new MemoryStream(buff);

            string mimeType = "image/jpg";
            return new FileStreamResult(stream, mimeType)
            {
                FileDownloadName = "image.jpg"
            };
        }
    }
}
