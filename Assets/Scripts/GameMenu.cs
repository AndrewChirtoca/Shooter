using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public UnityEvent OnPausePanelShown;
    public UnityEvent OnPausePanelHidden;
    private bool _pauseMenuShown = false;

    void OnEnable()
    {
        Resume();
    }

    public void Pause()
    {
        _pauseMenuShown = true;
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Resume()
    {
        _pauseMenuShown = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitApplication()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
#endif
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pauseMenuShown)
            {
                OnPausePanelHidden.Invoke();
            }
            else
            {
                OnPausePanelShown.Invoke();
            }
        }
    }
}
