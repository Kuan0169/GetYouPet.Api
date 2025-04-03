using GetYouPet.Data;
using GetYouPet.Data.Entities;
using GetYouPet.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace GetYouPet.Services.Services
{
    public interface IPetService
    {
        Task<IEnumerable<PetDto>> GetAllPets();
        Task<PetDto> GetPetById(Guid id);
        Task<PetDto> CreatePet(PetModel petModel);
        Task UpdatePet(PetModel petModel);
        Task DeletePet(Guid id);
        Task UpdatePet();
    }
    public class PetService : IPetService
    {
        private readonly TestContext context;

        public PetService(TestContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PetDto>> GetAllPets()
        {
            return await context.Pet.Select(p => new PetDto
            {
                Id = p.PetId,
                Name = p.Name,
                Species = p.Species,
                Age = p.Age,
            }).ToListAsync();
        }

        public async Task<PetDto> GetPetById(Guid id)
        {
            var pet = await context.Pet.Where(p => p.PetId == id).Select(c => new PetDto
            {
                Id = c.PetId,
                Name = c.Name,
                Species = c.Species,
                Age = c.Age,
            }).FirstOrDefaultAsync();
                if (pet == null)
            {
                throw new Exception("Pet not found");
            }
            return pet;
        }

        public async Task<PetDto> CreatePet(PetModel petModel)
        {
            var pet = new Pet
            {
                PetId = Guid.NewGuid(),
                Name = petModel.Name,
                Species = petModel.Species,
                Age = petModel.Age,
            };
            context.Pet.Add(pet);
            await context.SaveChangesAsync();
            var petDto = new PetDto
            {
                Id = pet.PetId,
                Name = pet.Name,
                Species = pet.Species,
                Age = pet.Age,
            };
            return petDto;
        }

        public async Task UpdatePet(PetModel petModel)
        {
            var pet = await context.Pet.Where(c => c.PetId == petModel.Id).FirstOrDefaultAsync();
            if (pet == null)
            {
                throw new Exception("Pet not found");
            }
            context.Pet.Update(pet);
            await context.SaveChangesAsync();
        }

        public async Task DeletePet(Guid id)
        {
            var pet = await context.Pet.Where(c => c.PetId == id).ExecuteDeleteAsync();
            await context.SaveChangesAsync();
        }
    }
}
