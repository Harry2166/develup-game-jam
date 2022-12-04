using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMarket : MonoBehaviour
{
    [SerializeField] GameObject Market;

    private void OnMouseDown() {
        Debug.Log("Market Opened!");
        Market.SetActive(true);
        Time.timeScale = 0f;
    }

}
