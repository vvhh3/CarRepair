using Microsoft.AspNetCore.Components;

namespace CarRepair.Services; //Сервис для услуг
using CarRepair.Models;
using Newtonsoft.Json;
public class RepairService
{
    public IList<RepairModel> ServicesPage = new List<RepairModel>();
    public RepairModel _newServicesPage = new RepairModel();
    public List<RepairModel> _newRepairModel = new List<RepairModel>();
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
    public void ServiceAdd()
    {
        ServicesPage.Add(_newServicesPage);
        _newServicesPage = new RepairModel();
        SaveFile();
        _newServicesPage.Id= (_newRepairModel.Count > 0) ? _newRepairModel.Max(u => u.Id) + 1 : 1;
        _newRepairModel.Add(_newServicesPage);
    }
    // public string GetUslugaName(int uslugaId)
    // {
    //     RepairModel usluga = ServicesPage.FirstOrDefault(u => u.Id == uslugaId)!;
    //     
    //     if (usluga != null)
    //     {
    //         return usluga.ServiceTitle;
    //     }
    //
    //     return "Услуга не найдена";
    // }

    public void Remove(RepairModel repairModel)
    {
        ServicesPage.Remove(repairModel);
    }
    
}