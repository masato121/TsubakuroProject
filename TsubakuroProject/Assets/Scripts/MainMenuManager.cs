using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Novel;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    public GameObject para_button;
    public GameObject para_text;
    public GameObject kanko_canvas;
    public GameObject food_canvas;
    public GameObject work_canvas;
    public GameObject menu_canvas;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PushButtonPara()
    {
        para_button.SetActive(false);
        para_text.SetActive(true);
    }
    public void PushButtonParaCancel()
    {
        para_button.SetActive(true);
        para_text.SetActive(false);
    }
    public void PushButtonKanko()
    {
        kanko_canvas.SetActive(true);
    }
    public void PushButtonKankoCancel()
    {
        kanko_canvas.SetActive(false);
    }
    public void PushButtonFood()
    {
        food_canvas.SetActive(true);
    }
    public void PushButtonFoodCancel()
    {
        food_canvas.SetActive(false);
    }
    public void PushButtonWork()
    {
        work_canvas.SetActive(true);
    }
    public void PushButtonWorkCancel()
    {
        work_canvas.SetActive(false);
    }
    public void PushButtonMenu()
    {
        menu_canvas.SetActive(true);
    }
    public void PushButtonMenuCancel()
    {
        menu_canvas.SetActive(false);
    }
    public void PushButtonConfig()
    {
        NovelSingleton.StatusManager.callJoker("tall/libs/config", "");
    }
    public void PushButtonTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
