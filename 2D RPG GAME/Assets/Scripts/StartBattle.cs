using UnityEngine;
using Random = UnityEngine.Random;

public class StartBattle : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int enemyCount;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Instantiate(enemyPrefab,
                spawnPoint.position,
                Quaternion.identity);
            }
        }
        gameObject.SetActive(false);
    }
}
