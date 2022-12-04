using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMarket : MonoBehaviour
{
    [SerializeField] GameObject Market;

    public void CloseMarket() {
        Debug.Log("Market Opened!");
        Market.SetActive(false);
        Time.timeScale = 1f;

    }
}
