using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITHS_Backend_C_Lab_1.Entities
{
    public class Animal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Uid { get; set;}
        
        [Required]
        public string Type { get; set; }

        [Required]
        public string Name { get; set; }


        public string GetName()
        {
            return Name;
        }
    }
}