namespace CarRepair.Services; //Сервис для клиентов
using CarRepair.Models;
using CarRepair.Services;
using Newtonsoft.Json;
public class ClientRepair
{

    public IList<ClientModel> ClientPage = new List<ClientModel>();
    public ClientModel _newClientPage = new ClientModel();
    // public List<ClientModel> _newClientModel = new List<ClientModel>();
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
        _newClientPage.Id= (ClientPage.Count > 0) ? ClientPage.Max(u => u.Id) + 1 : 1;
        SaveFile();
    }

    // public string GetKlientName(int ClientId)
    // {
    //     ClientModel clientModel = ClientPage.FirstOrDefault(k => k.Id == ClientId)!;
    //     
    //     if (clientModel!=null)
    //     {
    //         return _newClientPage.ClientName;
    //     }
    //
    //     return "Клиент не найден";
    // }

    public void RemoveClient(ClientModel clientModel)
    {
        ClientPage.Remove(clientModel);
        SaveFile();
    }
}