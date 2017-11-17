﻿using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour
{
    // Waveプレハブを格納する
    public GameObject[] waves;

    // 現在のWave
    private int currentWave;
    private Manager manager;
    IEnumerator Start()
    {

        // Waveが存在しなければコルーチンを終了する
        if (waves.Length == 0)
        {
            yield break;
        }
        manager = FindObjectOfType<Manager>();
        while (true)
        {
            while (manager.IsPlaying() == false)
            {

                yield return new WaitForEndOfFrame();
            }
            // Waveを作成する
            GameObject wave = (GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);

            // WaveをEmitterの子要素にする
            wave.transform.parent = transform;

            // Waveの子要素のEnemyが全て削除されるまで待機する
            while (wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
                if (manager.IsPlaying() == false)
                {
                    break;                }
            }


            // Waveの削除
            Destroy(wave);

            // 格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
            if (waves.Length <= ++currentWave)
            {
                currentWave = 0;
            }

        }
    }
}