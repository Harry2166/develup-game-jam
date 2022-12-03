using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseController : MonoBehaviour {

    GameObject objSelected = null;
    public GameObject[] snapPoints;
    [SerializeField] private float snapSensitivity = 2.0f;
    private int coins = 0;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI coinUsedText;
    [SerializeField] private TextMeshProUGUI numberOfCards;
    public GameObject coinPrefab;
    public GameObject newCardsPrefab;
    private int coinsTracker = 0;
    private int number_of_coins;

    private void Start() {
        coinText.text = "Coins: 0";
        coinUsedText.text = "Coins spent: 0";
        numberOfCards.text = "Cards: 1";
    }

    // Update is called once per frame
    void Update() {

        update_card_count();

        if (Input.GetMouseButtonDown(0)) {
            CheckHitObject();
        }

        if (Input.GetMouseButton(0) && objSelected != null) {
            DragObject();
        }

        if (Input.GetMouseButtonUp(0) && objSelected != null) {
            DropObject();
        }
    }

    void CheckHitObject() {
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        if (hit2D.collider != null) {
            objSelected = hit2D.transform.gameObject;
            if (objSelected.tag == "Card") number_of_coins = objSelected.name[4] - '0';
        }

    }

    void DragObject() {
        objSelected.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 10.0f));
    }

    void DropObject() {

        for (int i = 0; i < snapPoints.Length; i++) {
            if (Vector3.Distance(snapPoints[i].transform.position, objSelected.transform.position) < snapSensitivity && i == 0 && objSelected.tag == "Card") {

                objSelected.transform.position = new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y, snapPoints[i].transform.position.z - 0.1f);

                Destroy(objSelected);
                coins += number_of_coins;
                coinText.text = "Coins: " + coins.ToString();
                for (int j = 0; j < number_of_coins; j++) {
                    Instantiate(coinPrefab, new Vector3(0.3f * (Random.Range(0, 5)) + Random.Range(0, 5), 0.2f * (Random.Range(0, 5)) + Random.Range(0, 5), 0), Quaternion.identity);
                }

            } else if (Vector3.Distance(snapPoints[i].transform.position, objSelected.transform.position) < snapSensitivity && i > 0 && objSelected.tag == "Coin") {

                objSelected.transform.position = new Vector3(snapPoints[i].transform.position.x, snapPoints[i].transform.position.y, snapPoints[i].transform.position.z - 0.1f);
                Destroy(objSelected);
                coins--;
                coinsTracker++;
                coinText.text = "Coins: " + coins.ToString();
                coinUsedText.text = "Coins spent: " + coinsTracker;

                if (coinsTracker == 3) {
                    Instantiate(newCardsPrefab, new Vector3(0.3f * (Random.Range(0, 5)) + Random.Range(0, 5), 0.2f * (Random.Range(0, 5)) + Random.Range(0, 5), 0), Quaternion.identity);
                    coinsTracker = 0;
                    coinUsedText.text = "Coins spent: " + coinsTracker;
                }

            }
        }

        objSelected = null;
    }

    void update_card_count() {

        int cards_count = GameObject.FindGameObjectsWithTag("Card").Length;
        int generator_count = GameObject.FindGameObjectsWithTag("Generator").Length;

        int sum = cards_count + + generator_count;

        numberOfCards.text = "Cards: " + sum;
        //Debug.Log("Cards: " + sum);

    }

}
