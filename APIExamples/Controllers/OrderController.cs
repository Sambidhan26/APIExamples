using APIExamples.DataAccessLayer;
using APIExamples.Models;
using APIExamples.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIExamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [IsAuthorized]
    public class OrderController : ControllerBase
    {
        [HttpGet("/getorder/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetOrder(int id)
        {
            var order = DBServices.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(order);
            }
        }

        [HttpGet("/getorders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetOrders()
        {
            return Ok(DBServices.GetOrders());
        }

        [HttpPost("/addorder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddOrder([FromBody]Order order)
        {

            if(DBServices.AddOrder(order))
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(201);
            }
        }

        [HttpPost("/updateorder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateOrder([FromBody] Order order)
        {
            if(DBServices.UpdateOrder(order))
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("/deleteorder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteOrder(int id)
        {
            if(DBServices.DeleteOrder(id))
            {
                return Ok($"Order have been deleted: {id}");
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
