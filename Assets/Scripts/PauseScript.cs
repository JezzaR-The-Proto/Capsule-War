using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool IsGamePaused = false;

    public GameObject PauseMenu;
    public GameObject PauseMenuText;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (IsGamePaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        PauseMenu.SetActive(false);
        PauseMenuText.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause() {
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        PauseMenuText.SetActive(true);
        IsGamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Quit() {
        PauseMenu.SetActive(false);
        PauseMenuText.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
        SceneManager.LoadScene("Menu");
    }
}
