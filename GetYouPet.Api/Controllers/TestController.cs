using GetYouPet.Services.Services;
using Microsoft.AspNetCore.Mvc;
using GetYouPet.Services.Models;

namespace GetYouPet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController(IPetService petService) : ControllerBase
    {
        private readonly IPetService petService;

        [HttpGet]
        public async Task<IActionResult> GetAllPets()
        {
            var pets = await petService.GetAllPets();
            return Ok(pets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPetById(Guid id)
        {
            var pet = await petService.GetPetById(id);
            return pet != null ? Ok(pet) : NotFound("Add one?");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePet(PetModel petModel)
        {
            if (petModel == null)
            {
                return BadRequest("Invalid pet data");
            }
            var createdPet = await petService.CreatePet(petModel);
            return Ok(createdPet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(PetModel petModel)
        {
            var updatedPet = await petService.UpdatePet(petModel);
            return Ok(updatedPet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(Guid id)
        {
            var updatedPet = await petService.DeletePet(id);
            return Ok(updatedPet);
        }
    }
}
