using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API_FB.Models;

public class Games
{

    [Key]
    public int Id { get; set; }
    
    public int HomeTeamId { get; set; }

    public int AwayTeamId { get; set; }

    public float HomeSpread { get; set; }

    public int Week { get; set; }

    public string GameDate { get; set; }

    public string GameTime { get; set; }

}
