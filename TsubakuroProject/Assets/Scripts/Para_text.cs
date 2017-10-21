using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Novel;

public class Para_text : MonoBehaviour {
    [SerializeField]
    private float food = 50;
    public float Food
    {
        get { return food; }
        set
        {
            if (value > 100)
            {
                food = 100;
            }
            else
            {
                food = value;
            };
        }
    }
    public int money = 1000;
    public float know = 0;
    public float fly = 0;
    public float band = 0;
    public int date = 1;
    public string tips;
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
        para_food.text = "満腹度：" + Food;
        para_know.text="燕市知識：" + know;
        para_fly.text="運動能力：" + fly;
        para_band.text="親密度：" +band;
        para_tips.text = tips;
        para_date.text = (((date / 4) + 4)) + "月　第" + (((date - 1) % 4) + 1) + "週";
        para_money.text ="所持金"+ money + "円";

	}

  
    
}
