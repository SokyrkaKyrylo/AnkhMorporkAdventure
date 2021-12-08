using System.ComponentModel.DataAnnotations;

namespace AnkhMorporkAdventure.Models
{
    public class RewardModel
    {        
        [Range(0,999.99)]
        [DataType(DataType.Currency)]
        public int? Reward { get; set; }
    }
}