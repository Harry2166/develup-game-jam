using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using TMPro;

public class Bar : MonoBehaviour
{

    public GameObject bar;
    private int time = 360;
    private bool is_it_night = true;
    private bool start_time = false;
    private float time_time = 0f;
    [SerializeField] private TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        AnimateBar();
    }

    void Update()
    {

        if (is_it_night) {
            timeText.text = "Night Time";
        } else {
            timeText.text = "Day Time";
        }

        time_time += Time.deltaTime;

        if(time_time > 360 && is_it_night) {
            time = 180;
            is_it_night = false;
            Debug.Log("It is day time");
            bar.gameObject.transform.localScale = new Vector3(0, bar.gameObject.transform.localScale.y, bar.gameObject.transform.localScale.x);
            time_time = 0;
            AnimateBar();
        } else if (time_time > 180 && !(is_it_night)) {
            is_it_night = true;
            time = 360;
            Debug.Log("It is night time");
            time_time = 0;
            bar.gameObject.transform.localScale = new Vector3(0, bar.gameObject.transform.localScale.y, bar.gameObject.transform.localScale.x);
            AnimateBar();
        }

    }

    public void AnimateBar() {
        LeanTween.scaleX(bar, 1, time);
    }

}
