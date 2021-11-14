using System.Collections;
using UnityEngine;

public class NewRoom : MonoBehaviour
{
 
  public Transform playerT;
  
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
        StartCoroutine(MovePlayerToSecondRoom());
    }
  }

  IEnumerator MovePlayerToSecondRoom()
  {
      yield return new WaitForSeconds(0.5f);
      playerT.position = new Vector3(20.07f, playerT.position.y, playerT.position.z);
  }
}
