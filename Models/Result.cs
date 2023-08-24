using System.ComponentModel.DataAnnotations;

namespace API_FB.Models;

public class Result
{

    [Key]
    public int ResultID { get; set; }

    public int GameId { get; set; }

    public int HomeWin { get; set; }

    public float HomeMargin { get; set; }

}
