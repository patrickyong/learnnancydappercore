using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Models
{
    public class System:BaseEntity
    {
        [Key]
        public int ID { get; set; }

        public string Description { get; set; }
    }
}