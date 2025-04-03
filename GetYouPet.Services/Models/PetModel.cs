namespace GetYouPet.Services.Models
{
    public class PetModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Species { get; set; }
        public required int Age { get; set; }
    }
}
