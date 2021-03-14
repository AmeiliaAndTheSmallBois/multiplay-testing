using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    CreatePlayer();
    }

    // Update is called once per frame
    private void CreatePlayer()
  {
    Debug.Log("Creating Player");
    PhotonNetwork.Instantiate(Path.Combine("CharacterPrefab", "Character"), Vector3.zero, Quaternion.identity);
  }
}
