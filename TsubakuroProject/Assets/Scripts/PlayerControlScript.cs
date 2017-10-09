using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour {

	float Speed=2;
	public Vector2 SPEED = new Vector2(0.05f, 0.05f);
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {


		Move();
	}


	void Move(){

		Vector2 Position = transform.position;

		if(Input.GetKey("left")){

			Position.x -= SPEED.x;
		} else if(Input.GetKey("right")){
			// 代入したPositionに対して加算減算を行う
			Position.x += SPEED.x;
		} else if(Input.GetKey("up")){
			// 代入したPositionに対して加算減算を行う
			Position.y += SPEED.y;
		} else if(Input.GetKey("down")){ 
			// 代入したPositionに対して加算減算を行う
			Position.y -= SPEED.y;
		}
		// 現在の位置に加算減算を行ったPositionを代入する
		transform.position = Position;
	}


}