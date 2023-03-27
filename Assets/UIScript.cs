using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        // Pause 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!canvas.activeSelf){
                canvas.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            } else {
                
                canvas.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }
        }
    }

    public void OnClick(string ButtonName)
    {
        if (ButtonName == "Exit")
        {
            UnityEditor.EditorApplication.isPlaying = false;
        } else if (ButtonName == "Unpause")
        {
            canvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }
}
