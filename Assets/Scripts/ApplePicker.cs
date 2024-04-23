using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Добавление рекорда

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject   basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -13.5f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

    }

    public void AppleDestroyed()
    {
        
        // Удалить все упавшие яблоки
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        // Удаляем корзины
        int basketIndex = basketList.Count - 1;
        if (basketList.Count == 1)
        {
            SceneManager.LoadScene("TryAgain");
        }
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
    }

    
}
