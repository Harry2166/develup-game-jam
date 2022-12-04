using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomWithMouseWheel : MonoBehaviour
{

    [SerializeField] private float scroll_speed = 10;

    private Camera ZoomCamera;
    private bool is_ortographic_zoom;
    [SerializeField] GameObject pauseMenu;
    private bool is_paused = false;

    // Start is called before the first frame update
    void Start()
    {
        ZoomCamera = Camera.main;
        is_ortographic_zoom = ZoomCamera.orthographic;
    }

    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        is_paused = true;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        is_paused = false;
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

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if(is_paused == false) {
                Debug.Log("Escape pressed to pause!");
                Pause();
            } else {
                Debug.Log("Escape pressed to exit!");
                Resume();
            }

        }

    }
}
