using System.ComponentModel.DataAnnotations;

namespace AnkhMorporkAdventure.Models
{
    public class RewardModel
    {
        [Required]
        public int Reward { get; set; }
    }
}