namespace CarRepair.Models;
//Модель Услуг

public class RepairModel
{
    public string ServiceTitle { get; set; }
    public string ServiceText { get; set; }
    public int? Price { get; set; }
    public int Id { get; set; }

    public DateTime ClientDate { get; set; } = DateTime.Today;
}