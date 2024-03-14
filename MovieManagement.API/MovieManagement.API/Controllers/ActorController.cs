using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Domain.Repository;
using System.Reflection.Metadata.Ecma335;

namespace MovieManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var listOfActor = await _unitOfWork.ActorRepository.GetAllAsync();
            return Ok(listOfActor);
        }
        [HttpGet("movies")]
        public ActionResult GetWithMovies()
        {
            var actorsFromRepo = _unitOfWork.ActorRepository.GetActorsWithMovies();
            return Ok(actorsFromRepo);
        }

    }
}
