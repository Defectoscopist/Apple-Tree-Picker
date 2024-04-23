using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    public AudioSource pickUpApple;

    private void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter"); // Отыскать ScoreCounter
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";

    }
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;

        //ScreenToWorldPoint() преобразует экранные координаты mousePoint2D в координаты в трехмерном игровом пространстве
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    // Ловля яблок
    //Метод OnCollisionEnter вызывается всякий раз, когда какой-то другой объект сталкивается с этой корзиной
    private void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject; // Создать GO из объекта, столкнувшегося с корзиной
        if (collidedWith.tag == "Apple") // Если это яблоко
        {
            Destroy(collidedWith); // Удалить яблоко

            pickUpApple.Play();
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

            // Запомнить рекорд
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
    
}
