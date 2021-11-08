using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private CanvasGroup dialoguePanel;
    [SerializeField] private RectTransform dialogueDataHolder;
    [SerializeField] private GameObject questPanel;
    
    private void Awake()
    {
        instance = this;
    }

    public void SetDialoguePanel(bool isActive = false)
    {
        if (isActive)
        {
            dialoguePanel.gameObject.SetActive(true);
            dialoguePanel.DOFade(1f, 1f);
            dialogueDataHolder.DOMoveY(0f, 1f);
        }
        else
        {
            dialogueDataHolder.DOMoveY(-400f, 1f);
            dialoguePanel.DOFade(0f, 1f).OnComplete(() =>
            {
                dialoguePanel.gameObject.SetActive(false);
            });
        }
    }

    public void SetQuestPanel(bool isOff = false)
    {
        if (!isOff)
        {
            questPanel.SetActive(true);
            questPanel.transform.DOScale(1f, 0.5f).From(0f).SetEase(Ease.OutQuart);
        }
        else
        {
            questPanel.SetActive(false);
            questPanel.transform.DOScale(0f, 0.5f).From(1f).SetEase(Ease.InQuart);
        }
    }
    
}
