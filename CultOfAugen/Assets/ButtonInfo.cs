using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    [SerializeField] private TextMeshProUGUI priceText;
    public GameObject ShopManager;

    // Update is called once per frame
    void Update()
    {
        priceText.text = "Price: $" + ShopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID].ToString();
    }
}
