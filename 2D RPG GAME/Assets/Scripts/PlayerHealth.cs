using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float healthPoints = 100f;
    private float health;

    public Image healthImage;
    
    private void Start()
    {
        health = healthPoints;
    }

    public void Damage(float damageAmount)
    {
        health -= damageAmount;
        healthImage.fillAmount = (health / 100f);
        
        if (health <= 0f)
        {
            // dead
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyAttack"))
        {
            Damage(0.5f);
        }

        if (other.gameObject.CompareTag("Rock"))
        {
            Damage(2f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Health"))
        {
            Destroy(other.gameObject);
            if (health <= 100f)
            {
                health += 15f;
                healthImage.fillAmount = (health / 100f);

                if (health > 100f)
                {
                    health = 100f;
                    healthImage.fillAmount = (health / 100f);
                }
            }
          
        }
    }
}
