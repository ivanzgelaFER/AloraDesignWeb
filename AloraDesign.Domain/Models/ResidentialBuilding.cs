using System.ComponentModel.DataAnnotations;

namespace AloraDesign.Domain.Models
{
    public class ResidentialBuilding
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
