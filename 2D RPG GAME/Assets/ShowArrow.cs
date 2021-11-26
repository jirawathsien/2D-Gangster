using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowArrow : MonoBehaviour
{
   public CanvasGroup arrow;
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         arrow.gameObject.SetActive(true);
         arrow.DOFade(1f, 1f).OnComplete(() =>
         {
            arrow.DOFade(0f, 5f).OnComplete(() =>
            {
               arrow.gameObject.SetActive(false);
            });
           
         });
      }
   }
}
