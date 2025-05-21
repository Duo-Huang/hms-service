namespace Hms_Common.Model;

public class Home : BaseModel
{
    public required int HomeId { get; set; }

    public required string HomeName { get; set; }

    public string HomeDescription { get; set; }
}