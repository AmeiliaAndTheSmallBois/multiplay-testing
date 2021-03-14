using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;

public class QuickStartRoomController : MonoBehaviourPunCallbacks
{
  // Start is called before the first frame update
  [SerializeField] private int multiplayerSceneIndex;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  public override void OnEnable()
  {
    PhotonNetwork.AddCallbackTarget(this);
  }
  public override void OnDisable()
  {
    PhotonNetwork.RemoveCallbackTarget(this);
  }
  public override void OnJoinRoomFailed(short returnCode, string message)
  {   Debug.Log("Joined Room");
      StartGame();    
  }
  private void StartGame()
    {
      if (PhotonNetwork.IsMasterClient)
      {
        Debug.Log("Starting the Game, I am the Master!");
        PhotonNetwork.LoadLevel(multiplayerSceneIndex);
      }
    }

}
