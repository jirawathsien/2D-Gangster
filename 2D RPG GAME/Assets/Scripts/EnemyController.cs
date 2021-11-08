using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    [SerializeField] private SpriteRenderer[] spriteRenderers;
    [SerializeField] private Rigidbody2D[] bodyRbs;
    private bool isEnemyActivated;

    private Transform playerController;
    private Rigidbody2D rb;

    [SerializeField] private int health = 3;
    private bool stopMoving;


    public event Action onDead;
    
    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>().transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!stopMoving && isEnemyActivated)
        {
            float distance = Vector2.Distance(transform.position, playerController.position);

            if (distance > 2.5f)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerController.position, speed * Time.deltaTime);
            }
        }
    }

    public void ActivateEnemy()
    {
        isEnemyActivated = true;
        foreach (var sp in spriteRenderers)
        {
            sp.DOColor(Color.white, 2f);
            sp.DOFade(1f, 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            stopMoving = true;
            Vector2 forceAmount = Vector2.right * 5f;
            rb.AddForce(forceAmount, ForceMode2D.Impulse);
            Damage(1);
        }
    }


    void Damage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            EnemyDead();
        }
    }

    void EnemyDead()
    {
        onDead?.Invoke();
        foreach (var rb in bodyRbs)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * 5f, ForceMode2D.Impulse);
            rb.transform.DOScale(0f, 2f).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
    }
}
