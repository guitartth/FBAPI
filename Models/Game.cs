using System.ComponentModel.DataAnnotations;

namespace API_FB.Models;

public class Game
{

    [Key]
    public int GameID { get; set; }
    
    public int HomeTeamId { get; set; }

    public int AwayTeamId { get; set; }

    public float HomeSpread { get; set; }

    public int Week { get; set; }

    public DateTime GameDate { get; set; }

    public DateTime GameTime { get; set; }

}
