using GetYouPet.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace GetYouPet.Data
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }
        public DbSet<Pet> Pet { get; set; }
    }
}
