using GetYouPet.Data;
using GetYouPet.Services.Services;
using Microsoft.EntityFrameworkCore;


namespace GetYouPet.Tests.PetServiceTest
{
    public class PetServiceBaseTest
    {
        protected readonly IPetService petService;
        protected readonly TestContext context;

    public PetServiceBaseTest()
        {
            var options = new DbContextOptionsBuilder<TestContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            context = new TestContext(options);
            petService = new PetService(context);

        }
    }
}
