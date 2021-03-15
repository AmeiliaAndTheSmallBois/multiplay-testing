using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
  [SerializeField] float moveFactor;
  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(KeyCode.W))
    {
      transform.position += new Vector3(0, moveFactor * 1, 0);
    }
    if (Input.GetKey(KeyCode.A))
    {
      transform.position += new Vector3(moveFactor * 1, 0, 0);
    }
    if (Input.GetKey(KeyCode.S))
    {
      transform.position += new Vector3(0, moveFactor * -1, 0);
    }
    if (Input.GetKey(KeyCode.D))
    {
      transform.position += new Vector3(moveFactor * -1, 0 ,0);
    }
  }
}