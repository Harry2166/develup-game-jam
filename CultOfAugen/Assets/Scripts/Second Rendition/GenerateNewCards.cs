using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNewCards : MonoBehaviour {

    public GameObject[] cardPrefab;

    public int tapTimers;
    public float resetTimer;

    IEnumerator ResetTapTimes() {
        yield return new WaitForSeconds(resetTimer);
        tapTimers = 0;
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            StartCoroutine("ResetTapTimes");
            tapTimers++;
        }

        if(tapTimers >= 2) {
            tapTimers = 0;
            Debug.Log("double tap");
            OnMouseDown_test();
        }
    }

    private void OnMouseDown_test() {

        float yOffset = 6f;
        float xOffset = 6f;

        for (int i = 0; i < 4; i++) {
            int random_element = Random.Range(0, cardPrefab.Length);
            if (i % 2 == 0) {
                switch (i) {
                    case 0:
                        Instantiate(cardPrefab[random_element], new Vector3(this.transform.position.x, this.transform.position.y + yOffset, 0), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(cardPrefab[random_element], new Vector3(this.transform.position.x, this.transform.position.y - yOffset, 0), Quaternion.identity);
                        break;
                }
            } else {
                switch (i) {
                    case 1:
                        Instantiate(cardPrefab[random_element], new Vector3(this.transform.position.x + xOffset, this.transform.position.y, 0), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(cardPrefab[random_element], new Vector3(this.transform.position.x - xOffset, this.transform.position.y, 0), Quaternion.identity);
                        break;
                }
            }

            Destroy(gameObject);
        }

        /*

            0
        3       1
            2
        */
    }
}
