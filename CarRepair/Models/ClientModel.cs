namespace CarRepair.Models; //Модель Клиента

public class ClientModel
{
    public string ClientName { get; set; }
    public string ClientText { get; set; }
    public string ClientTitle { get; set; }
    public DateTime Test { get; set; }

    public TimeOnly Vremia { get; set; } = new TimeOnly(10, 0);
    public int Id { get; set; }
}