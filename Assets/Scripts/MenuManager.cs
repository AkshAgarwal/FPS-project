using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
   [SerializeField] GameObject hud;
    [SerializeField] GameObject pausemenu;
    [SerializeField] GameObject winScene;
    [SerializeField] bool ispaused;
    // Start is called before the first frame update
    public static MenuManager mm=null;
    private void Start()
    {
        if (mm == null)
        {
            mm = this;
        }
        ispaused = false;
        if (pausemenu != null)
        {
            pausemenu.SetActive(false); 
        }
        if(hud!=null)
            
        hud.SetActive(true);
        winScene.SetActive(false);
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(ispaused)
            {
                ispaused = false;
                Resume();
            }else if(!ispaused)
            {
                ispaused = true;
                pause();            
            }
        }
    }
    public void pause()
    {
        if (pausemenu != null)
        {
            Time.timeScale = 0f;
            hud.SetActive(false);
            pausemenu.SetActive(true);
        }
        else
        {
            return;
        }
        Cursor.lockState = CursorLockMode.None;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        hud.SetActive(true);
        pausemenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);

    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
    public void WinScene()
    {
        
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        winScene.SetActive(true);
        hud.SetActive(false);
    }
}
