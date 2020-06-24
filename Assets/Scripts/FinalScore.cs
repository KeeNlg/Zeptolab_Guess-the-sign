using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    public static FinalScore Instance;

    public Text score;

    public GameObject panel;

    private void Awake()
    {
        Instance = this;
    }

    public void Show()
    {
        score.text = PlayerPrefs.GetInt("Score", 0).ToString();

        panel.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}
