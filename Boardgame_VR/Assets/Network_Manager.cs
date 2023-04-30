using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Network_Manager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

    // Update is called once per frame
    void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try Connecting To Server..");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Server.");
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a Room");
        base.OnJoinedRoom();
    }

    /*
    public override void OnPlayerConnected(NetworkPlayer player) {
        Debug.Log("A new PLayer Joined");
        base.OnPlayerEnteredRoom(newPlayer);
    }
    
    */
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new Player Joined");
        base.OnPlayerEnteredRoom(newPlayer);
    }
    

}   

