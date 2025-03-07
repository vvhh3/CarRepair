
using CarRepair.Components.Pages;
using CarRepair.Models;
using Newtonsoft.Json;
using CarRepair.Services;
using Microsoft.AspNetCore.Components;


namespace CarRepair.Services; // запись услуг

public class RecordRepair
{
    public IList<RecordModel> RecordPage = new List<RecordModel>();
    public RecordModel _newRecordPage = new RecordModel();
    const string path = "RecordPage.json";
    
    public void OpenFile()
    {
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            RecordPage = JsonConvert.DeserializeObject<List<RecordModel>>(json)!;
        }
        else
        {
            SaveFile();
        }
    }

    public void SaveFile()
    {
        var json = JsonConvert.SerializeObject(RecordPage);
        File.WriteAllText(path, json);
    }

    public void Remove(RecordModel recordModel)
    {
        RecordPage.Remove(recordModel);
    }
    // public DateTime GetDateTime( RecordModel recordModel)
    // {
    //     recordModel.DateTimeRecord = DateTime.Now.ToShortDateString();
    // }
    
}