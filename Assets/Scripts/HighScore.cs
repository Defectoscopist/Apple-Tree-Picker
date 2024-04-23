using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI; // Нужна для работы с UI

public class HighScore : MonoBehaviour
{
    static public int score = 1000;
  
  void Awake() // Awake() всегда перед Start()
    {
        // Если уже есть рекорд, прочитать
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        // Сохранить рекорд в хранилище
        PlayerPrefs.SetInt("HighScore", score);
    }

    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "HighScore: " + score;
        // Обновить HighScore в PlayerPrefs
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}