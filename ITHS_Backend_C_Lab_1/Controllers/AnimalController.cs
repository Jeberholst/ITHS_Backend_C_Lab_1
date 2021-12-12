using ITHS_Backend_C_Lab_1.Entities;
using ITHS_Backend_C_Lab_1.Repo;
using Microsoft.AspNetCore.Mvc;
using ITHS_Backend_C_Lab_1.DTOs;

namespace ITHS_Backend_C_Lab_1.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepo _aRepo;

        public AnimalController(IAnimalRepo aRepo)
        {
            _aRepo = aRepo;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllAnimals()
        {
            var animals = _aRepo.GetAll();
            return Ok(animals);
        }
        
        [HttpGet("{uid}")]
        public IActionResult GetAnimalByUid(int uid)
        {
            Animal animal = _aRepo.FindByUid(uid);
            if (animal is null)
            {
                return NotFound("Could not find animal with UID " + uid);
            }

            AnimalDto animalDto = MapAnimalToAnimalDto(animal);
            return Ok(animalDto);
        }
        
        [HttpPost("")]
        public IActionResult CreateAnimal([FromBody] CreateAnimalDto createAnimalDto)
        {
            
            Animal createAnimal = _aRepo.CreateAnimal(createAnimalDto);
            AnimalDto newAnimalDto = MapAnimalToAnimalDto(createAnimal);
            
           
            return CreatedAtAction(
                nameof(GetAnimalByUid),
                new { uid = newAnimalDto.Uid },
                newAnimalDto);

        }
        
        [HttpPatch("{uid}")]
        public IActionResult UpdateAnimal([FromBody] UpdateAnimalDto updateAnimalDto, int uid)
        {
            
            Animal animal = _aRepo.FindByUid(uid);
            if (animal is null)
            {
                return NotFound("Could not find animal with UID " + uid);
            }
            
            Animal nUpdateAnimal = _aRepo.UpdateAnimal(updateAnimalDto, uid);
            AnimalDto animalDto = MapAnimalToAnimalDto(nUpdateAnimal);
            
            
            return Ok("Animal with UID " + uid + " was updated with new name, " + animalDto.ToUpdateString());
        }
        
        
        [HttpDelete("{uid}")]
        public IActionResult DeleteAnimal(int uid)
        {
            Animal animal = _aRepo.FindByUid(uid);
            if (animal is null)
            {
                return NotFound("Could not find animal with UID " + uid);
            }
            _aRepo.DeleteAnimal(uid);
            return Ok("Animal has been has been deleted");
        }
        
        private AnimalDto MapAnimalToAnimalDto(Animal animal)
        {
            return new AnimalDto
            {
                Uid = animal.Uid,
                Type = animal.Type,
                Name = animal.Name,
            };
        }
        
    }
    
    
    
}
