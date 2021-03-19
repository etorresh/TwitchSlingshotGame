using UnityEngine;
using TwitchLib.Unity;
using TwitchLib.Client.Models;

public class ChatClient : MonoBehaviour
{
    public PlayersHandler ph;
    public Client client;
    private string channe_name = "emiliotorresh_";
    // Start is called before the first frame update
    void Start()
    {
        Application.runInBackground = true;
        ConnectionCredentials credentials = new ConnectionCredentials("unbotmuyguapo", Secrets.bot_access_token);
        client = new Client();
        client.Initialize(credentials, channe_name);

        client.OnMessageReceived += MyMessageReceivedFunction;

        client.Connect();
    }

    private void MyMessageReceivedFunction(object sender, TwitchLib.Client.Events.OnMessageReceivedArgs e)
    {
        // Detectar si un viewer escribe !jugar
        if (e.ChatMessage.Message[0] == '!')
        {
            if(e.ChatMessage.Message[1] == 'j')
            {
                ph.JoinGame(e.ChatMessage.UserId);
                client.SendMessage(client.JoinedChannels[0], "Quieres jugar guapo?");
            }
            else if(e.ChatMessage.Message[1] == 'd')
            {
                client.SendMessage(client.JoinedChannels[0], "Disparar");
                ph.Shoot(e.ChatMessage.Message);
            }
        }
    }
}
