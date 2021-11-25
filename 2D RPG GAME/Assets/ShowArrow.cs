using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowArrow : MonoBehaviour
{
   public Image arrow;
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         arrow.gameObject.SetActive(true);
         arrow.DOFade(1f, 2f).OnComplete(() =>
         {
            arrow.DOFade(0f, 2f).OnComplete(() =>
            {
               arrow.gameObject.SetActive(false);
            });
           
         });
      }
   }
}
