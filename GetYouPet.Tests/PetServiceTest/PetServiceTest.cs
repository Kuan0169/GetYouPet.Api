using GetYouPet.Data.Entities;
using GetYouPet.Services.Models;
using GetYouPet.Tests.PetServiceTest;
using Microsoft.EntityFrameworkCore;

namespace GetYouPet.Tests.TestServiceTest
{
    public class PetServiceTest : PetServiceBaseTest
    {
        [Fact]
        public async Task GetAllPets_ReturnsAllPets()
        {
            // Arrange
            var pet1 = new Pet
            {
                PetId = Guid.NewGuid(),
                Name = "Buddy",
                Species = "Dog",
                Age = 5,
            };
            var pet2 = new Pet
            {
                PetId = Guid.NewGuid(),
                Name = "Mittens",
                Species = "Cat",
                Age = 3,
            };
            context.Pet.AddRange(pet1, pet2);
            context.SaveChanges();
            // Act
            var result = await petService.GetAllPets();
            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, p => p.Id == pet1.PetId);
            Assert.Contains(result, p => p.Id == pet2.PetId);

        }


        [Fact]
        public async Task GetPetById_ExistingId_ReturnsPet()
        {
            // Arrange
            var pet = new Pet
            {
                PetId = Guid.NewGuid(),
                Name = "Buddy",
                Species = "Dog",
                Age = 5,
            };
            context.Pet.Add(pet);
            context.SaveChanges();
            // Act
            var result = await petService.GetPetById(pet.PetId);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(pet.Name, result.Name);
        }

        [Fact]
        public async Task GetPetById_NoExistingId_ThrowException()
        {
            // Arrange
            var petId = Guid.NewGuid();
            // Act
            var result = await Assert.ThrowsAsync<Exception>(() => petService.GetPetById(petId));
            // Assert
            Assert.Equal("Pet not found", result.Message);
        }

        [Fact]
        public async Task CreatePet_ValidModel_ReturnsNewPet()
        {
            // Arrange
            var petModel = new PetModel
            {
                Name = "Buddy",
                Species = "Dog",
                Age = 5,
            };
            // Act
            var result = await petService.CreatePet(petModel);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(petModel.Name, result.Name);
        }

        [Fact]
        public async Task UpdatePet_ExistingPet_UpdatesData()
        {
            // Arrange
            var petId = Guid.NewGuid();
            var existingPet = new Pet 
            { 
                PetId = petId, 
                Name = "OldName", 
                Species = "Dog", 
                Age = 4 
            };
            context.Pet.Add(existingPet);
            await context.SaveChangesAsync();

            // Act
            var petModel = new PetModel 
            {
                Id = petId, 
                Name = "NewName", 
                Species = "Dog", 
                Age = 4 
            };
            await petService.UpdatePet(petModel);

            // Assert: 直接查询数据库验证更新
            var updatedPet = await context.Pet.FirstOrDefaultAsync( p => p.PetId == petId);

            Assert.NotNull(updatedPet);
            Assert.Equal("NewName", updatedPet.Name);
        }

        [Fact]
        public async Task DeletePet_RemovesPetFromDatabase()
        {
            // Arrange
            var petId = Guid.NewGuid();
            var pet = new Pet { PetId = petId, Name = "ToDelete", Species = "Bird", Age = 1 };
            context.Pet.Add(pet);
            await context.SaveChangesAsync();

            // Act
            await petService.DeletePet(petId);

            // Assert
            var deletedPet = await context.Pet.FirstOrDefaultAsync(p => p.PetId == petId);
            Assert.Null(deletedPet);
        }

    }
}
