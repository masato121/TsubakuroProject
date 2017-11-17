using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Novel;
public class SceneManagement : MonoBehaviour {


    private string tips;
    
    // Use this for initialization
    void Start () {
        int num = UnityEngine.Random.Range(1,6);
        int date = int.Parse(StatusManager.variable.get("f.date"));
        int hung = int.Parse(StatusManager.variable.get("f.food"));
        date += 1;
        if (hung <= 0)
        {
            SceneManager.LoadScene("TitleScene");
        }
        else
        {

            StatusManager.variable.set("f.date", date.ToString());


            SceneMan(date, num);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("train1");
        }
    }
    void SceneMan(int date,int num)
    {
        if (date == 10)
        {

        }else if (date == 20)
        {

        }
        else
        {
            SceneManager.LoadScene("MainMenu");

        }
        switch (num)
        {
            case 1:
                tips = "つばくろちゃんは燕市の戸隠神社のマスコットキャラクター。かわいいよ！";
                break;
            case 2:
                tips = "満腹度によってつばくろの動きの速さが変わるよ！";
                break;
            case 3:
                tips = "ゲーム中の場所は全部燕市のどこかがモデルになってるよ！";
                break;
            case 4:
                tips = "燕市の洋食器は世界的に有名で、ノーベル賞受賞式の晩餐会にも使われたことがあるよ！";
                break;
            case 5:
                tips = "このゲームは燕市の高校生が知識ゼロの状態から作っているから多少の粗は勘弁してね！";
                break;
        }
        StatusManager.variable.set("f.tips", tips);
        
    }




}
