using GetYouPet.Services.Services;
using Microsoft.AspNetCore.Mvc;
using GetYouPet.Services.Models;

namespace GetYouPet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController(IPetService petService) : ControllerBase
    {
        private readonly IPetService _petService = petService;

        [HttpGet]
        public async Task<IActionResult> GetAllPets()
        {
            var pets = await petService.GetAllPets();
            return Ok(pets);
        }

        [HttpGet]
        [Route("GetPetById/{id}")]
        public async Task<IActionResult> GetPetById(Guid id)
        {
            var pet = await petService.GetPetById(id);
            return pet != null ? Ok(pet) : NotFound("Add one?");
        }

        [HttpPost]
        [Route("CreatePet")]
        public async Task<IActionResult> CreatePet(PetModel petModel)
        {
            if (petModel == null)
            {
                return BadRequest("Invalid pet data");
            }
            var createdPet = await petService.CreatePet(petModel);
            return Ok(createdPet);
        }

        [HttpPut]
        [Route("UpdatePet/{id}")]
        public async Task<IActionResult> UpdatePet(PetModel petModel)
        {
            await petService.UpdatePet(petModel);
            return Ok("Pet updated successfully");
        }

        [HttpDelete]
        [Route("DeletePet/{id}")]
        public async Task<IActionResult> DeletePet(Guid id)
        {
            await petService.DeletePet(id);
            return Ok("Pet deleted");
        }
    }
}
