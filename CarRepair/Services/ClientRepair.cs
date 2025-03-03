namespace CarRepair.Services; //Сервис для клиентов
using CarRepair.Models;
using Newtonsoft.Json;
public class ClientRepair
{

    public IList<ClientModel> ClientPage = new List<ClientModel>();
    public ClientModel _newClientPage = new ClientModel();
    const string path = "ClientPage.json";
    
    public void OpenFile()
    {
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            ClientPage = JsonConvert.DeserializeObject<List<ClientModel>>(json)!;
        }
        else
        {
            SaveFile();
        }
    }

    public void SaveFile()
    {
        var json = JsonConvert.SerializeObject(ClientPage);
        File.WriteAllText(path, json);
    }
    public void ClientAdd()
    {
        ClientPage.Add(_newClientPage);
        _newClientPage = new ClientModel();
        SaveFile();
        _newClientPage.Id += 1;
    }

    // public void ClientDelete()
    // {
    //     ClientPage.Remove();
    // }
}