
using CarRepair.Models;
using Newtonsoft.Json;
using CarRepair.Services;
namespace CarRepair.Services; // запись услуг

public class RecordRepair
{
    public IList<RecordModel> RecordPage = new List<RecordModel>();
    public RecordModel _newRecordPage = new RecordModel();
    private List<RecordModel> _newRecordModel = new List<RecordModel>();
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
    public void RecordAdd()
    {
        RecordPage.Add(_newRecordPage);
        _newRecordPage = new RecordModel();
        SaveFile();
        _newRecordPage.Id= (_newRecordModel.Count > 0) ? _newRecordModel.Max(u => u.Id) + 1 : 1;
        _newRecordModel.Add(_newRecordPage);
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