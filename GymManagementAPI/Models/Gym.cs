using System.ComponentModel.DataAnnotations;

namespace GymManagementAPI.Models
{
    public class Gym
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
