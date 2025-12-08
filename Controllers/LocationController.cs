using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchedulerJqxWebApi.Crud;
using SchedulerJqxWebApi.Models;

namespace SchedulerJqxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Location>> Get()
        {
            try
            {
                List<Location> list = LocationCrud.GetAll();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public ActionResult<Location> Get(int id)
        {
            try
            {
                Location model = LocationCrud.GetOne(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<LocationController>
        [HttpPost]
        public ActionResult<Location> Post(Location model)
        {
            try
            {
                model = LocationCrud.Insert(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<LocationController>/5
        [HttpPut]
        public ActionResult Put(Location model)
        {
            try
            {
                LocationCrud.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                LocationCrud.Del(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}