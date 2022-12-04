using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class Bar : MonoBehaviour
{

    public GameObject bar;
    public int time;
    private bool start_time = false;

    // Start is called before the first frame update
    void Start()
    {
        AnimateBar();
    }

    void Update()
    {
        
    }

    public void AnimateBar() {
        LeanTween.scaleX(bar, 1, time);
    }

}