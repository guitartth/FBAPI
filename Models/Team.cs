using System.ComponentModel.DataAnnotations;

namespace API_FB.Models;

public class Team
{

    [Key]
    public int TeamID { get; set; }

    public string TeamAbr { get; set; }

    public string TeamCity { get; set; }

    public string TeamName { get; set; }

    public string LogoURL { get; set; }

    public string StadiumName { get; set; }

}
