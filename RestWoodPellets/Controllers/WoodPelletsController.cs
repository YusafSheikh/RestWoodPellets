using Microsoft.AspNetCore.Mvc;
using RestWoodPellets.Repository;
using WoodPelletLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestWoodPellets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WoodPelletsController : ControllerBase
    {
        private WoodPelletRepository _repository;

        public WoodPelletsController(WoodPelletRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<WoodPelletsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public IEnumerable<WoodPellet> Get()
        {
            List<WoodPellet> result = _repository.GetAll();
            return result;
        }

        // GET api/<WoodPelletsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public WoodPellet Get(int id)
        {
            WoodPellet? foundWoodPellet = _repository.GetById(id);
            return foundWoodPellet;
        }

        // POST api/<WoodPelletsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public WoodPellet Post([FromBody] WoodPellet newWoodPellet)
        {
            WoodPellet createdWoodPellet = _repository.Add(newWoodPellet);
            return createdWoodPellet;
        }

        // PUT api/<WoodPelletsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<WoodPellet> Put(int id, [FromBody] WoodPellet updates)
        {
            WoodPellet? updatedWoodPellet = _repository.Update(id, updates);
            return updatedWoodPellet;
        }

        // DELETE api/<WoodPelletsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public WoodPellet Delete(int id)
        {
            WoodPellet? deletedWoodPellet= _repository.Delete(id);
            return deletedWoodPellet;
        }
    }
}
