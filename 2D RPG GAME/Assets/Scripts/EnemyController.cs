using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    private bool isEnemyActivated;

    private Transform playerController;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private int health = 3;
    private bool stopMoving;

    [SerializeField] private float timeToAttack = 2f;
    float timeCounter;

    public bool isBoss;
    public CanvasGroup lastDialogueGroup;
    public Image fadeScreen;
    public GameObject tobeCon;

    public GameObject rock;
    [SerializeField] private float rockThrowTime = 3.5f;
    private float throwRockTime;
    
    [SerializeField] private Transform indicator;
    
    public event Action onDead;

    private Vector2 playerPos;
    public GameObject healthPickup;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerController = FindObjectOfType<PlayerController>().transform;
        rb = GetComponent<Rigidbody2D>();
       
        timeCounter = timeToAttack;
        throwRockTime = rockThrowTime;
    }

    private void Start()
    {
       
        playerPos = playerController.position;
        
    }

    private void Update()
    {
        if (stopMoving) return;
        this.spriteRenderer.flipX = playerController.position.x < this.transform.position.x;
        float distance = Vector2.Distance(transform.position, playerController.position);

        if (!isBoss)
        {
            if (distance < 10f && distance > 1.95f)
            {
                animator.SetBool("Run", true);
                transform.position = Vector3.MoveTowards(transform.position, playerController.position, speed * Time.deltaTime);
            
            }
            else
            {
                animator.SetBool("Run", false);

                if (distance < 2f)
                {
                    timeCounter -= Time.deltaTime;

                    if (timeCounter < 0)
                    {
                        timeCounter = UnityEngine.Random.Range(2.5f, timeToAttack);
                        animator.SetTrigger("Attack");
                    }
                }
            }
        }
        else
        {
            if (distance < 25f && distance > 2f)
            {
                animator.SetBool("Run", true);
                transform.position = Vector3.MoveTowards(transform.position, playerController.position, speed * Time.deltaTime);

                throwRockTime -= Time.deltaTime;

                if (throwRockTime < 0f)
                {
                    throwRockTime = rockThrowTime;
                    indicator.gameObject.SetActive(true);
                    indicator.DOMove(playerController.position, 0.5f).OnComplete(() =>
                    {
                        indicator.gameObject.SetActive(false);
                        GameObject rockObject = Instantiate(rock, transform.position, Quaternion.identity);
                        Destroy(rockObject, 2f);
                    });
                } 
            }
            else
            {
                animator.SetBool("Run", false);

                if (distance < 1.99f)
                {
                    timeCounter -= Time.deltaTime;

                    if (timeCounter < 0)
                    {
                        timeCounter = UnityEngine.Random.Range(2.5f, timeToAttack);
                        animator.SetTrigger("Attack");
                    }
                }
            }
        }
        
    }

    public void ActivateEnemy()
    {
        isEnemyActivated = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sword") || other.gameObject.CompareTag("Barrel"))    
        { 
            // Vector2 forceAmount = Vector2.right * 1.5f;
           // rb.AddForce(forceAmount, ForceMode2D.Impulse);
            Damage(1);
        }

        if (other.gameObject.CompareTag("SandAttack"))
        {
            Damage(1);
            transform.DOMove(transform.position, 5f);
        }
        
        if (other.gameObject.CompareTag("PoisonAttack"))
        {
            Damage(1);
            speed = 0.3f;
            transform.DOScale(1f, 5f).OnComplete(() =>
            {
                speed = 3f;
            });
        }
    }


    void Damage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            EnemyDead();
            stopMoving = true;
        }
    }

    void EnemyDead()
    {
        onDead?.Invoke();
        spriteRenderer.DOFade(0f, 0.5f).OnComplete(() =>
        {
            if (isBoss)
            {
                if (lastDialogueGroup != null)
                {
                    lastDialogueGroup.DOFade(1f, 0.5f).OnComplete(() =>
                    {
                        lastDialogueGroup.DOFade(0f, 2f).SetDelay(3f);
                        fadeScreen.DOFade(1f, 2f).SetDelay(2f).OnComplete(() =>
                        {
                            tobeCon.SetActive(true);
                        });
                    });
                }
            }

            Instantiate(healthPickup, transform.position, Quaternion.identity);
            Destroy(gameObject);
        });
    }
}
