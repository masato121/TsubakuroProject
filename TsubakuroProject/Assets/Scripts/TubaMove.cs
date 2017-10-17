using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubaMove : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        float dir = Random.Range(0, 359);
        float spd = 2;
        CharaMove(dir, spd);
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        float dir = Random.Range(0, 359);
        float spd = 2;
        CharaMove(dir, spd);

    }
    public void CharaMove(float dir,float sp)
    {
        Vector2 v;
        v.x = Mathf.Cos(Mathf.Deg2Rad * dir) * sp;
        v.y = Mathf.Sin(Mathf.Deg2Rad * dir) * sp;
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        Animator anim = GetComponent<Animator>();
        if (v.x > 1)
        {
            anim.Play("Tubakuro_migi");
        }else if (v.x < 0)
        {
            anim.Play("Tubakuro_hidari");
        }
        r.velocity = v;

    }
}
