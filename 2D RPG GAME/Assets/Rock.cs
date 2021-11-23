using System;
using DG.Tweening;
using UnityEngine;

public class Rock : MonoBehaviour
{

    
    private Rigidbody2D rb;

    private Transform playerTransform;

    private Vector2 playerPos;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
      
    }

    private void Start()
    {
        playerPos = playerTransform.position;
        rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos, 15f * Time.deltaTime);
    }
 
}
