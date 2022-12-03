using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomWithMouseWheel : MonoBehaviour
{

    [SerializeField] private float scroll_speed = 10;

    private Camera ZoomCamera;
    private bool is_ortographic_zoom;

    // Start is called before the first frame update
    void Start()
    {
        ZoomCamera = Camera.main;
        is_ortographic_zoom = ZoomCamera.orthographic;
    }

    // Update is called once per frame
    void Update()
    {
        if (ZoomCamera.orthographic && ZoomCamera.orthographicSize >= 10 && ZoomCamera.orthographicSize <= 25) {
            ZoomCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scroll_speed;
        }

        if (ZoomCamera.orthographicSize < 10) {
            ZoomCamera.orthographicSize += 1;
        } else if (ZoomCamera.orthographicSize > 25) {
            ZoomCamera.orthographicSize -= 1;
        }

    }
}
