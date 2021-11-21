using System;
using UnityEngine;
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
            Debug.Log("Player Dead");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyAttack"))
        {
            Damage(1f);
        }
    }
}
