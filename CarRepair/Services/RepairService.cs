namespace CarRepair.Services; //Сервис для услуг
using CarRepair.Models;
using Newtonsoft.Json;
public class RepairService
{
    public IList<RepairModel> ServicesPage = new List<RepairModel>();
    private RepairModel _newServicesPage = new RepairModel();
    const string path = "ServisecPage.json";
    
    public void OpenFile()
    {
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            ServicesPage = JsonConvert.DeserializeObject<List<RepairModel>>(json)!;
        }
        else
        {
            SaveFile();
        }
    }

    public void SaveFile()
    {
        var json = JsonConvert.SerializeObject(ServicesPage);
        File.WriteAllText(path, json);
    }
}