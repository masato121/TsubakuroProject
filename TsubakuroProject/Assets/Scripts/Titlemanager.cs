using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Novel;

public class Titlemanager : MonoBehaviour {



    public bool ClearFlag;
    public GameObject spring_apart;
    public GameObject winter_apart;
    public GameObject MiniGame;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (ClearFlag == true)
        {
            spring_apart.active = true;
            MiniGame.active = true;
            winter_apart.active = false;
        }
        else
        {
            spring_apart.active = false;
            MiniGame.active = false;
            winter_apart.active = true;
        }
    }
    public void PushClearButton()
    {
        ClearFlag = true;
    }
    public void PushButtonNoclear()
    {
        ClearFlag = false;
    }
    public void PushButtonNewGame()
    {
        NovelSingleton.StatusManager.callJoker("tall/scene1", "");
    }
    public void PushButtonContinue()
    {
        NovelSingleton.StatusManager.callJoker("tall/libs/save", "*loadstart");
    }
}


