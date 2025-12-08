using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using SchedulerJqxWebApi.Crud;
using SchedulerJqxWebApi.Models;
using SchedulerJqxWebApi.Repositories;

namespace SchedulerJqxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScheduleEventsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<ScheduleEvents>> Get(DateTime dateTime)
        {
            try
            {
                List<ScheduleEvents> list = ScheduleEventsCrud.GetAll(dateTime);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ScheduleEventsController>/5
        [HttpGet("{id}")]
        public ActionResult<ScheduleEvents> Get(int id)
        {
            try
            {
                ScheduleEvents model = ScheduleEventsCrud.GetOne(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ScheduleEventsController>
        [HttpPost]
        public ActionResult<ScheduleEvents> Post(ScheduleEvents model)
        {
            try
            {
                model = ScheduleEventsCrud.Insert(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ScheduleEventsController>/5
        [HttpPut]
        public ActionResult Put(ScheduleEvents model)
        {
            try
            {
                ScheduleEventsCrud.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ScheduleEventsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                ScheduleEventsCrud.Del(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}