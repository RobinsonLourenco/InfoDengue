using Microsoft.AspNetCore.Mvc;

namespace InfoDisease.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InfoDiseaseController : ControllerBase
    {
        // GET: api/v1/<InfoDiseaseController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/v1/<InfoDiseaseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/v1/<InfoDiseaseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/v1/<InfoDiseaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<InfoDiseaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
