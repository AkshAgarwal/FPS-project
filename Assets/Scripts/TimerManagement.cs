using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerManagement : MonoBehaviour
{
    [SerializeField] float minutes,seconds;
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] GameObject losescene;
    [SerializeField] GameObject hud;
    // Start is called before the first frame update
    void Start()
    {
        minutes = 3;
        seconds = 0;
        Score.SetText(minutes + ":" + seconds);
        losescene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(seconds<=0)
        {
            seconds = 59;
            minutes--;
            Score.SetText(minutes + ":" + seconds);
        }
        else
        {
            seconds-=Time.deltaTime;
            Score.text = minutes + ":" + seconds.ToString("0");
        } 

        if(seconds<=0&&minutes<=0)
        {
            seconds = 0;
            minutes = 0;
            Score.text = minutes + ":" + seconds.ToString("0");
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            losescene.SetActive(true);
            hud.SetActive(false);
        }
    }
}
