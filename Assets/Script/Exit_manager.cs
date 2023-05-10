using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_manager : MonoBehaviour
{
    public GameObject Exit_Screen;
    bool open= false; 
    void Update()
    {
        Open_Eixt();
    }
    void Open_Eixt()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!open)
            {
                Exit_Screen.gameObject.SetActive(true);
                Time.timeScale = 0f;
                open = true;
            }
            else
            {
                continue_game();
            }
        }
    }

    public void Exitgame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    public void continue_game()
    {
        Exit_Screen.gameObject.SetActive(false);
        Time.timeScale = 1f;
        open = false;
    }

    }
