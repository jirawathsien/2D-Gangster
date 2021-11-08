using System;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public GameObject sword;
    public GameObject wand;

    private EnemyController enemyController;

    public GameObject questGiverObjects;
    
    
    private void Awake()
    {
        enemyController = FindObjectOfType<EnemyController>();
    }

    private void Start()
    {
        enemyController.onDead += () =>
        {
            questGiverObjects.SetActive(true);
        };
    }

    public void OnEquipSword()
    {
        GameManager.instance.pauseGame = false;
        UIManager.instance.SetQuestPanel(true);
        sword.SetActive(true);
        questGiverObjects.SetActive(false);
        
    }

    public void OnEquipWand()
    {
        GameManager.instance.pauseGame = false;
        UIManager.instance.SetQuestPanel(true);
        wand.SetActive(true);
        questGiverObjects.SetActive(false);
    }

}
