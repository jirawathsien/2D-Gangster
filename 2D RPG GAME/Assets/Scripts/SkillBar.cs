using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBar : MonoBehaviour
{
    private Image equipmentItemImage;

    public bool isAttackable;
    
    private void Start()
    {
      
        equipmentItemImage = GetComponent<Image>();
        
    }

    [SerializeField] private float fillAmountTimee = 3f;
    public float fillAmountCountDownTimer = 0f;
    public void Update()
    {
        if (equipmentItemImage.fillAmount < 1f)
        {
            fillAmountCountDownTimer += Time.deltaTime;
            var percent = fillAmountCountDownTimer / fillAmountTimee;
            equipmentItemImage.fillAmount = percent;
            isAttackable = false;
        }
        else
        {
            isAttackable = true;
            fillAmountCountDownTimer = 0f;
        }
    }
    
}
