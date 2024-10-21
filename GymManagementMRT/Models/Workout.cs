using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagementAPI.Models
{
    public class Workout
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int Duration { get; set; } //This is in minutes as a time unit

        //Related to the Gym
        public int GymID { get; set; }
        [ForeignKey("GymID")]
        public Gym Gym { get; set; }
    }
}
