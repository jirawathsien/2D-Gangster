using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewRoom : MonoBehaviour
{

    public Animator fadeAnim;
    public Transform playerT;
    public Transform nextRoomPoint;

    public bool isBackToSecondRoomTrigger;
    public GameObject thirdRoomNpcOne;
    public GameObject thirdRoomNpcTwo;
    
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
        if (nextRoomPoint == null)
        {
            SceneManager.LoadScene("Level 2");
            return;
        }
        
        StartCoroutine(MovePlayerToSecondRoom());
        fadeAnim.SetTrigger("FadeIn");

        if (isBackToSecondRoomTrigger)
        {
            Destroy(thirdRoomNpcOne);
            thirdRoomNpcTwo.SetActive(true);
        }
        
    }
  }

  IEnumerator MovePlayerToSecondRoom()
  {
      yield return new WaitForSeconds(1f);
      playerT.position = nextRoomPoint.position;

  }
}
