using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using APIExamples.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIExamples.Models;
using APIExamples.Services;

namespace APIExamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [IsAuthorized]
    public class UserController : ControllerBase
    {
        [HttpGet("/getuser/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUser(int id)
        {
            var user = DBServices.GetUser(id);
            if(user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpGet("/getusers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUsers()
        {
            var user = DBServices.GetUsers();

            if(user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpPost("/adduser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddUser([FromBody] User user)
        {
            if(DBServices.AddUser(user))
            {
                return Ok($"User was Added {user.FirstName}");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("/updateuser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateUser([FromBody] User user)
        {
            if(user.Id < 1)
            {
                return BadRequest();
            }
            try
            {
                DBServices.UpdateUser(user);
                return Ok("User first Name: " + user.FirstName + " has been updated");
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("/deleteuser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteUser([FromBody]User user)
        {
            if (user.Id < 1)
            {
                return BadRequest();
            }
            try
            {
                DBServices.DeleteUser(user);
                return Ok("User first Name: " + user.FirstName + " has been deleted");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
