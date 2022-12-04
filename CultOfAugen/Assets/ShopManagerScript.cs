using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class ShopManagerScript : MonoBehaviour
{

    public int[,] shopItems = new int[5,5];
    public GameObject FromCoins;
    [SerializeField] private TextMeshProUGUI coinsText;
    public GameObject[] prefab_store_items;


    void Start()
    {
        coinsText.text = "Coins: " + FromCoins.GetComponent<MouseController>().coins.ToString();

        // ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        // Price
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
        shopItems[2, 4] = 40;

    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (FromCoins.GetComponent<MouseController>().coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]) {
            FromCoins.GetComponent<MouseController>().coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];

            if(ButtonRef.GetComponent<ButtonInfo>().ItemID == 1) {
                Instantiate(prefab_store_items[0], new Vector3(0.3f * (Random.Range(0, 5)) + Random.Range(0, 5), 0.2f * (Random.Range(0, 5)) + Random.Range(0, 5), 0), Quaternion.identity);
            }

            coinsText.text = "Coins: " + FromCoins.GetComponent<MouseController>().coins.ToString();
        }

    }
}
