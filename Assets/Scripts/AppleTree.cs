using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour 
{
    [Header("Set in Inspector")]
    // ������ �������� �����
    public GameObject applePrefab;

    // �������� �������� ������
    public float speed = 1f;

    // ����������, �� ������� ������ ���������� ����������� �������� ������
    public float leftAndRightEdge = 10f;

    // ����������� ���������� ��������� ����������� ��������
    public float chanceToChangeDirections = 0.1f;

    // ������� �������� ����������� �����
    public float secondsBetweenAppleDrops = 1f;

    void Start()
    {
        Invoke("DropApple", 2f); // ������� "DropApple" ����� 2 �������
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab); // ������� ���������� apple, ����������� �� ������ appleprefab
        apple.transform.position = transform.position; // ��������� �� �������������� ������
        Invoke("DropApple", secondsBetweenAppleDrops); // � �� �����
    }

    void Update()
    {
        // ������� �����������
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime; // Time.deltaTime - 1 ����
        transform.position = pos; // ����������� ������� transform.position �������� pos, ����� ������ ������������

        // ��������� �����������
        if (pos.x < -leftAndRightEdge)
        { // ���� ���� � ������ ����
            speed = Mathf.Abs(speed); // ��������� ������
        }
        else if (pos.x > leftAndRightEdge)
        { // ���� ���� ������
            speed = -Mathf.Abs(speed); // ��������� �����
        }

    }

    void FixedUpdate()
    {
        // ��������� �� FPS, �������� ������ ����������� ��������
        if (Random.value < chanceToChangeDirections)
        { // ��� ������ �������� 
            speed *= -1; // ������ ����������� ��������
        }
    }
    // �������� 515
}