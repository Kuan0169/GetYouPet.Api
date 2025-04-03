using GetYouPet.Data.Entities;


namespace GetYouPet.Data
{
    public class TestContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }
        public DbSet<Pet> Pet { get; set; }
    }
}
