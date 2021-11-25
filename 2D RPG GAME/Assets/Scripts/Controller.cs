using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public TextMeshProUGUI landingtext;

    private void Start()
    {
        landingtext.DOFade(1f, 0.5f).From(0f);

        landingtext.DOFade(0f, 1f).From(1f).SetDelay(3f).OnComplete(() =>
        {
            SceneManager.LoadScene("Level 1");
        });

    }
}
