/*
using System.Collections;
using System.Net.Scotes;
using UnityEngine;

public class Servers : MonoBehaviour
{
    public int port = 6321;

    private List<ServerClient> clients;
    private List<ServerClient> disconnectList;

    private TopListener servers;
    private bool serverStarted;

    public void InIt()
    {
        DontDestroyOnLoad(gameObject);
        clients = new List<ServerClient>();
        disconnectList = new List<ServerClient>();

        try
        {
            server = new TopListener(IPAddress.Any, port);
        }
        catch (Exception e)
        {
            Debug.Log("Socket error: " + e.Message);
        }
    }

    private void StartListening()
    {
        server.BegignAcceptTopClient(AcceptTopClients, server);
    }



        }
    
public class ServerClient
{
    public straing clientName;
    public TopClient top;

    public ServerClient(TopClient top)
    {
        this.top = top;
    }
}
*/