using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Screen : MonoBehaviour
{
    public GameObject Main_Screen_obj;
    // Start is called before the first frame update
    void Start()
    {
        Sound_Manager.instance.PlaySound("Green Green Garden", 0);
        Time.timeScale = 0.00f;
    }

  public void StartBtn()
    {
        Time.timeScale = 1.0f;
        Main_Screen_obj.gameObject.SetActive(false);
        Sound_Manager.instance.PlaySound("St.Anne's Reel", 0);
    }
}
