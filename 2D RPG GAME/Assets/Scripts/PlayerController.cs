using System;
using DG.Tweening;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpd = 40f;
    
    private float horizontal;
    private float vertical;
    private bool jump;
    
    private Character2D character2D;
    private Animator animator;
    
    
    private void Start()
    {
        character2D = GetComponent<Character2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.instance.pauseGame) return;

        HandleInputs();

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
        
        if (horizontal != 0)
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }


}
