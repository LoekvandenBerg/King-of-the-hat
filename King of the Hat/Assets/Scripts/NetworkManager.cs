using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // instance
    public static NetworkManager instance;

    private void Awake()
    {
        // set instance to this GameObject
        if (instance != null && instance != this)
            gameObject.SetActive(false);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        //connect to master server
        PhotonNetwork.ConnectUsingSettings();
    }


    //attempts to CREATE a room
    public void CreateRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
    }

    //attempts to JOIN a room
    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    //changes the scene using Photon's system
    [PunRPC]
    public void ChangeScene(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }
}
