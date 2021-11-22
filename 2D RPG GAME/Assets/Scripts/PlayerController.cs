using System;
using System.Threading;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpd = 40f;
    
    private float horizontal;
    private float vertical;
    private bool jump;
    public bool isWeaponPicked;
    
    private Character2D character2D;
    private Animator animator;
    public CanvasGroup dialogueTrigger;


    [SerializeField] private GameObject sandAttack;
    [SerializeField] private GameObject poisonAttack;

    private static bool isSandAttack;

    public GameObject weaponTypeBox;
    public static bool isSecondWeaponPickedup;

    public Rigidbody2D barrelRb;
    public Transform barrelPoint;
    private bool isBarrel;

    public Image whichImage1;
    public Image whichImage2;
    public Sprite sand;
    public Sprite poison;

    private static Sprite saveSprite;

    public SkillBar skillBar;

    public TextMeshProUGUI controlScheme;
    
    private void Start()
    {
        character2D = GetComponent<Character2D>();
        animator = GetComponent<Animator>();

        if (saveSprite != null)
        {
            whichImage1.gameObject.SetActive(true); 
        }
        else
        {
            whichImage1.gameObject.SetActive(false); 
        }
        
        whichImage1.sprite = whichImage2.sprite = saveSprite;

        if (controlScheme != null)
        {
            controlScheme.DOFade(0f, 5f);
        }
        
    }

    void Update()
    {
        if (GameManager.instance.pauseGame) return;

        HandleInputs();

        if (isBarrel)
        {
            barrelRb.transform.position = transform.position;
        }
        
        if (!isBarrel && Input.GetMouseButtonDown(0) &&  isWeaponPicked)
        {
            animator.SetTrigger("Attack");
        }
        else if (Input.GetMouseButtonDown(0) && isBarrel)
        {
            barrelRb.GetComponent<TimeToDestroy>().enabled = true;
            barrelRb.transform.parent = null;
            barrelRb.bodyType = RigidbodyType2D.Dynamic;
            barrelRb.gameObject.layer = 0;
            
            if (character2D.m_FacingRight)
            {
                barrelRb.AddForce(transform.right * 7f + Vector3.up *3f, ForceMode2D.Impulse);
            }
            else
            {
                barrelRb.AddForce(-transform.right * 7f + Vector3.up * 3f, ForceMode2D.Impulse);
            }

            barrelRb = null;
            isBarrel = false;
        }
        
        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

      
    }
    
    void FixedUpdate()
    {
        if (GameManager.instance.pauseGame) return;
        character2D.Move(horizontal * Time.fixedDeltaTime, vertical * Time.fixedDeltaTime);
        jump = false;
    }

    void HandleInputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * moveSpd;
        vertical = Input.GetAxisRaw("Vertical") * moveSpd;

        if (skillBar.isAttackable && isSecondWeaponPickedup && Input.GetMouseButtonDown(1))
        {
            whichImage2.fillAmount = 0f;
            animator.SetTrigger("Throw");
            if (isSandAttack)
            {
                GameObject obj = Instantiate(sandAttack, transform.position, Quaternion.identity);
                
                if (character2D.m_FacingRight)
                {
                    obj.GetComponent<Rigidbody2D>().AddForce(transform.right * 9f + Vector3.up * 5f, ForceMode2D.Impulse);
                }
                else
                {
                    obj.GetComponent<Rigidbody2D>().AddForce(-transform.right * 9f + Vector3.up * 5f, ForceMode2D.Impulse);
                } 
            }
            else
            {
                GameObject obj = Instantiate(poisonAttack, transform.position, Quaternion.identity);
                    
                if (character2D.m_FacingRight)
                {
                    obj.GetComponent<Rigidbody2D>().AddForce(transform.right * 5f + Vector3.up * 5f, ForceMode2D.Impulse);
                }
                else
                {
                    obj.GetComponent<Rigidbody2D>().AddForce(-transform.right * 5f + Vector3.up * 5f, ForceMode2D.Impulse);
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            isWeaponPicked = true;
            animator.SetTrigger("Attack");
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("DialougTrigger"))
        {
            other.enabled = false;
            dialogueTrigger.DOFade(1f, 1f).OnComplete(() =>
            {
                dialogueTrigger.DOFade(0f, 1f).SetDelay(2f);
            });
        }
        
        if (other.gameObject.CompareTag("Barrel"))
        {
            isBarrel = true;
            barrelRb = other.gameObject.GetComponent<Rigidbody2D>();
            barrelRb.transform.parent = barrelPoint;
        }

    }


    public void OnWeaponTypePress(string weaponName)
    {
        whichImage1.gameObject.SetActive(true);
        isSecondWeaponPickedup = true;
        if (weaponName == "PoisonAttack")
        {
            whichImage1.sprite = whichImage2.sprite = poison;
            isSandAttack = false;
        }
        else
        {
            whichImage1.sprite = whichImage2.sprite = sand;
            isSandAttack = true;
        }

        saveSprite = whichImage1.sprite;
        weaponTypeBox.SetActive(false);
    }
}
