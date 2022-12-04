using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNewCards : MonoBehaviour {

    public GameObject[] cardPrefab;

    public int tapTimers;
    public float resetTimer;
    private bool on_mouse = false;


    IEnumerator ResetTapTimes() {
        yield return new WaitForSeconds(resetTimer);
        tapTimers = 0;
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            StartCoroutine("ResetTapTimes");
            tapTimers++;
        }

        if(Time.timeScale == 0f) {
            tapTimers = 0;
        }

        if(tapTimers >= 2 && on_mouse) {
            tapTimers = 0;
            Debug.Log("double tap");
            OnMouseDown_test();
        }
    }

    void OnMouseOver() {
        on_mouse = true;
    }

    void OnMouseExit() {
        on_mouse = false;
    }

    private void OnMouseDown_test() {

        float yOffset = 6f;
        float xOffset = 6f;

        for (int i = 0; i < 4; i++) {
            int random_element = Random.Range(1, cardPrefab.Length);
            Debug.Log("cardPrefab.Length: " + cardPrefab.Length);
            Debug.Log("random_element: " + random_element);
            if (i % 2 == 0) {
                switch (i) {
                    case 0:
                        if (GameObject.FindGameObjectsWithTag("Follower").Length == 0) Instantiate(cardPrefab[0], new Vector3(this.transform.position.x, this.transform.position.y + yOffset, 0), Quaternion.identity);
                        else Instantiate(cardPrefab[random_element], new Vector3(this.transform.position.x, this.transform.position.y + yOffset, 0), Quaternion.identity);
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
