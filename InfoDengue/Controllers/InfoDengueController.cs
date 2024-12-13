using Microsoft.AspNetCore.Mvc;

namespace InfoDengue.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InfoDengueController : ControllerBase
    {
        // GET: api/v1/<InfoDengueController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/v1/<InfoDengueController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/v1/<InfoDengueController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/v1/<InfoDengueController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<InfoDengueController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
