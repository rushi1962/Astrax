using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControl : MonoBehaviour
{
    public void NextScene()
    {
        GameManager.gm.LoadNextScene();
    }
    public void PlayAgain()
    {
        GameManager.gm.PlayAgain();
    }
    public void Quit()
    {
        GameManager.gm.GameQuit();
    }
    public void Pause()
    {
        GameManager.gm.PauseGame();
    }
    public void Resume()
    {
        GameManager.gm.ResumeGame();
    }
}
