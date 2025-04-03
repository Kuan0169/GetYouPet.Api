using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetYouPet.Data.Entities
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Speices { get; set; }
        public required int Age { get; set; }
        public required Guid PetId { get; set; }
    }
}
