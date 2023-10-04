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
    public class ItemController : ControllerBase
    {
        [HttpGet("/getitem/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public  IActionResult GetItem(int id)
        {
            var item = DBServices.GetItem(id);

            if(item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }


        }

        [HttpGet("/getitems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public  IActionResult GetItems()
        {
            return Ok(DBServices.GetItems());
        }

        [HttpPost("/additem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddItem([FromBody]Item item)
        {
            if(DBServices.AddItem(item))
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpPost("/updateitem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateItem([FromBody]Item item)
        {
            if(item.Id < 0)
            {
                return BadRequest();
            }

            try
            {
                if (DBServices.UpdateItem(item))
                {
                    return Ok($"The item has been updated: {item.Id}");
                }
                else
                {
                    return StatusCode(501);
                }
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpDelete("/deleteitem/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteItem(int id)
        {
            try
            {
                if (DBServices.DeleteItem(id))
                {
                    return Ok($"The item has been deleted: {id}");
                }
                else
                {
                    return StatusCode(501);
                }
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
