using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
  // Start is called before the first frame update
  [SerializeField] private GameObject quickStartButton;
  [SerializeField] private GameObject quickCancelButton;
  [SerializeField] private int RoomSize = 2;
  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  public override void OnConnectedToMaster()
  {
    PhotonNetwork.AutomaticallySyncScene = true;
    quickStartButton.SetActive(true);
  }
  public void QuickStart()
  {
    quickStartButton.SetActive(false);
    quickCancelButton.SetActive(true);
    PhotonNetwork.JoinRandomRoom();
    Debug.Log("Quick Start");
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
      MaxPlayers = (byte)RoomSize
    };
    string roomId = "SmolBoi" + randNum;
    PhotonNetwork.CreateRoom(roomId, roomOps);
    Debug.Log("Created Room: " + roomId);
  }
  public override void OnCreateRoomFailed(short returnCode, string message)
  {
    Debug.Log("Failed to recreate room: " + message + "  " + returnCode);
    CreateRoom();
  }
  public void QuickCancel()
  {
    quickCancelButton.SetActive(false);
    quickStartButton.SetActive(true);
    PhotonNetwork.LeaveRoom();
  }

}
