using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetYouPet.Services.Models
{
    public class PetDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Species { get; set; }
        public required int Age { get; set; }
    }
}
