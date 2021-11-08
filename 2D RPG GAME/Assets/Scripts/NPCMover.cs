using System;
using UnityEngine;

public class NPCMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform[] targetPoints;

    private int targetIndex = 0;

    private void Update()
    {
        if (GameManager.instance.pauseGame) return;
        
        if (targetIndex < targetPoints.Length)
        {
            if (Vector3.Distance(transform.position, targetPoints[targetIndex].position) > 0.1f)
            { 
                transform.position = Vector3.MoveTowards(transform.position, 
                targetPoints[targetIndex].position, moveSpeed * Time.deltaTime);
            }
            else
            {
                targetIndex++;
            }
        }
        else
        {
            targetIndex = 0;
        }
    }
}
