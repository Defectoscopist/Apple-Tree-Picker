using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour 
{
    [Header("Set in Inspector")]
    // Шаблон создания яблок
    public GameObject applePrefab;

    // Скорость движения яблони
    public float speed = 1f;

    // Расстояний, на котором должно изменяться направление движения яблони
    public float leftAndRightEdge = 10f;

    // Вероятность случайного изменения направления движения
    public float chanceToChangeDirections = 0.1f;

    // Частота создания экземпляров яблок
    public float secondsBetweenAppleDrops = 1f;

    void Start()
    {
        Invoke("DropApple", 2f); // Вызвать "DropApple" через 2 секунды
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab); // создаем переменную apple, присваиваем ей префаб appleprefab
        apple.transform.position = transform.position; // указываем на местоположение яблони
        Invoke("DropApple", secondsBetweenAppleDrops); // и по новой
    }

    void Update()
    {
        // Простое перемещение
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime; // Time.deltaTime - 1 кадр
        transform.position = pos; // присваиваем обратно transform.position значение pos, чтобы яблоня перместилась

        // Изменение направления
        if (pos.x < -leftAndRightEdge)
        { // Если ушло к левому краю
            speed = Mathf.Abs(speed); // подвинуть вправо
        }
        else if (pos.x > leftAndRightEdge)
        { // Если ушло вправо
            speed = -Mathf.Abs(speed); // подвинуть влево
        }

    }

    void FixedUpdate()
    {
        // Незавизмо от FPS, случайно меняем направление движения
        if (Random.value < chanceToChangeDirections)
        { // Или просто случайно 
            speed *= -1; // меняем направление движения
        }
    }
    // Страница 515
}