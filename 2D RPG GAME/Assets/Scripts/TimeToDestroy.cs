using UnityEngine;

public class TimeToDestroy : MonoBehaviour
{
   [SerializeField] private float timeToDestroy = 4f;

   private void Update()
   {
      timeToDestroy -= Time.deltaTime;

      if (timeToDestroy <= 0)
      {
         Destroy(gameObject);
      }
   }
}
