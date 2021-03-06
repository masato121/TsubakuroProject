﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Spaceshipコンポーネント
    Common spaceship;
    Vector3 tapPoint;
    public int myhp = 5;
    IEnumerator Start()
    {
        // Spaceshipコンポーネントを取得
        spaceship = GetComponent<Common>();

        while (true)
        {

            // 弾をプレイヤーと同じ位置/角度で作成
            spaceship.Shot(transform);

            // ショット音を鳴らす GetComponent<AudioSource>().Play();

            // shotDelay秒待つ
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

    void Update()
    {
        // 右・左
        float x1 = Input.GetAxisRaw("Horizontal");

        // 上・下
        float y1 = Input.GetAxisRaw("Vertical");

        // 移動する向きを求める
        Vector2 directions = new Vector2(x1, y1).normalized;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float x = touch.deltaPosition.x;
            float y = touch.deltaPosition.y;
            Vector2 direction = new Vector2(x, y);


            // 移動の制限
            Move(direction,spaceship.speed);

        }
        Move(directions,3);
    }

    // 機体の移動
    void Move(Vector2 direction,float speed)
    {


        // 画面左下のワールド座標をビューポートから取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // 画面右上のワールド座標をビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // プレイヤーの座標を取得
        Vector2 pos = transform.position;

        // 移動量を加える
        pos += direction * speed * Time.deltaTime;

        // プレイヤーの位置が画面内に収まるように制限をかける
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // 制限をかけた値をプレイヤーの位置とする
        transform.position = pos;
    }


    // ぶつかった瞬間に呼び出される
    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);
        // レイヤー名がBullet (Enemy)の時は弾を削除
        if (layerName == "EBullet")
        {
            // 弾の削除
            Destroy(c.gameObject);
        }
        // レイヤー名がBullet (Enemy)またはEnemyの場合は爆発
        if (layerName == "EBullet" || layerName == "Enemy")
        {
           
                // 爆発する spaceship.Explosion();
                


                    FindObjectOfType<Manager>().GameOver();

            // プレイヤーを削除
            Destroy(gameObject);

        }



    }
}