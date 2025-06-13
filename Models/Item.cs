using System.ComponentModel.DataAnnotations;

namespace sem_2_k_2.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
