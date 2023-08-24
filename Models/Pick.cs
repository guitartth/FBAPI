using System.ComponentModel.DataAnnotations;

namespace API_FB.Models;

public class Pick
{

    [Key]
    public int PickID { get; set; }

    public int UserId { get; set; }

    public int GameId { get; set; }

    public float HomeSpread { get; set; }

    public int PickWeek { get; set; }

    public int HomePick { get; set; }

    public int UserWin { get; set; }

}
