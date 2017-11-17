using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Novel;
using Scene;

public class Para_text : MonoBehaviour {
   
    [SerializeField]
    private Text para_food;
    [SerializeField]
    private Text para_know;
    [SerializeField]
    private Text para_fly;
    [SerializeField]
    private Text para_band;
    [SerializeField]
    private Text para_date;
    [SerializeField]
    private Text para_tips;
    [SerializeField]
    private Text para_money;
    
    // Use this for initialization
    void Start () {


	}
	
	// Update is called once per frame
	void Update () {

        para_food.text = "満腹度：" + StatusManager.variable.get("f.food");
        para_know.text="燕市知識：" + StatusManager.variable.get("f.know");
        para_fly.text="運動能力：" + StatusManager.variable.get("f.fly");
        para_band.text="親密度：" + StatusManager.variable.get("f.band");
        para_tips.text = StatusManager.variable.get("f.tips");
        int date = int.Parse(StatusManager.variable.get("f.date"));
        para_date.text = ((((date-1) /4) + 4)) + "月　第" + (((date - 1) % 4) + 1) + "週";
        para_money.text ="所持金"+ StatusManager.variable.get("f.money") + "円";

	}


  
    
}
