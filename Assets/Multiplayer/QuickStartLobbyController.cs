using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
  // Start is called before the first frame update
  [SerializeField] private GameObject quickStartButton;
  [SerializeField] private GameObject quickCancelButton;
  [SerializeField] private int RoomSize = 2;
  [SerializeField] private Text joinRoomText;
  [SerializeField] Text statusUpdate;
  [SerializeField] Text numPlayers;
  
  void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
    string nameOfCurrentRoom = "";
    if (PhotonNetwork.CurrentRoom == null)
    {
      nameOfCurrentRoom = "NULL";
    }
    else
    {
      nameOfCurrentRoom = PhotonNetwork.CurrentRoom.Name;
    }    
    numPlayers.text = $"InRoom: {PhotonNetwork.InRoom} InLobby: {PhotonNetwork.InLobby}  Name Of Room: {nameOfCurrentRoom}";   
    }
  public override void OnConnectedToMaster()
  {
    Debug.Log("On Connected to Master");
    PhotonNetwork.AutomaticallySyncScene = true;
    quickStartButton.SetActive(true);
  }
  public void QuickStart()
  {    
    quickStartButton.SetActive(false);
    quickCancelButton.SetActive(true);
    bool joinedRoom = PhotonNetwork.JoinRandomRoom();
    int roomCount = PhotonNetwork.CountOfRooms;
    
   
    //if (roomName == null) { Debug.Log("roomName is null"); }
    //else { }
   
    Debug.Log("Quick Start: " + joinedRoom);
    
  }
  public override void OnJoinRandomFailed(short returnCode, string message)
  {
    Debug.Log("Failed to Join a Room");
    CreateRoom();
  }
  void CreateRoom()
  {
    Debug.Log("Creating a Room");
    int randNum = Random.Range(0, 200);
    RoomOptions roomOps = new RoomOptions()
    {
      IsVisible = true,
      IsOpen = true,
      MaxPlayers = (byte)RoomSize,      
    };
    string roomId = "SmolBoi" + randNum;
    bool roomCreated = PhotonNetwork.CreateRoom(roomId, roomOps);
    var photonNet = PhotonNetwork.CurrentRoom;
    Debug.Log("Current Room: " + photonNet);
    string roomCreation = $"{roomId} {roomCreated}";
    Debug.Log(roomCreation);
    statusUpdate.text = roomCreation;


  }
  public override void OnCreateRoomFailed(short returnCode, string message)
  {
    Debug.Log("Failed to recreate room: " + message + "  " + returnCode);
    CreateRoom();
  }

  public void JoinRoom()
  {
    PhotonNetwork.JoinRoom(joinRoomText.ToString());

  }
  public void QuickCancel()
  {
    quickCancelButton.SetActive(false);
    quickStartButton.SetActive(true);
    PhotonNetwork.LeaveRoom();
  }

}
