using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;

public class UI_Leaderboard : MonoBehaviour
{
    private static UI_Leaderboard instance;

    private Button_UI closeBtn;
    private TextMeshProUGUI[] score;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        score = new TextMeshProUGUI[10];
        closeBtn = transform.Find("closeBtn").GetComponent<Button_UI>();
        for(int i = 0; i<10; i++)
        {
            score[i] = transform.Find("Score "+(i+1).ToString()).GetComponent<TextMeshProUGUI>();
        }

        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            closeBtn.ClickFunc();
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show(Action onCancel)
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();
        closeBtn.ClickFunc = () =>
        {
            Hide();
            onCancel();
        };
    }
    public static void Show_Static(Action onCancel)
    {
        instance.Show(onCancel);
    }
    public void updateScore(int side, int val)
    {
        score[side - 1].text = val.ToString();
    }
}
