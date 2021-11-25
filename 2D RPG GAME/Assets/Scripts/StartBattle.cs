using UnityEngine;

public class StartBattle : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
   
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyPrefab.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
