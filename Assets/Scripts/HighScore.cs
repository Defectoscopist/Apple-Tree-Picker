using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI; // ����� ��� ������ � UI

public class HighScore : MonoBehaviour
{
    static public int score = 1000;
  
  void Awake() // Awake() ������ ����� Start()
    {
        // ���� ��� ���� ������, ���������
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        // ��������� ������ � ���������
        PlayerPrefs.SetInt("HighScore", score);
    }

    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "HighScore: " + score;
        // �������� HighScore � PlayerPrefs
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}