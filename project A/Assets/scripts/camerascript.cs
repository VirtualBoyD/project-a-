using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascript : MonoBehaviour
{
    public Transform player;

    private void Update()
{
    //this line makes the camera follows the player in a more efficient way than adding the camera to the player :)
    transform.position = new Vector3(player.position.x, player.position.y, -10);
  }
}



//enix studios