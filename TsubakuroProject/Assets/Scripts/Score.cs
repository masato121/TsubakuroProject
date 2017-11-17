using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Novel;
public class Score : MonoBehaviour
{
    // スコアを表示するGUIText
    public Text scoreText;

    // ハイスコアを表示するGUIText
    public Text highScoreText;

    public Text remainText;
    // スコア
    private int score;

    // ハイスコア
    private int highScore;

    public int life;

    // PlayerPrefsで保存するためのキー
    private string highScoreKey = "highScore";

    
    void Start()
    {
        Initialize();
    }

    void Update()
    {
        // スコアがハイスコアより大きければ
        if (highScore < score)
        {
            highScore = score;
        }

        // スコア・ハイスコアを表示する
        scoreText.text = score.ToString();
        highScoreText.text = "HighScore : " + highScore.ToString();
        remainText.text = "Remaining : " + life.ToString();
    }

    // ゲーム開始前の状態に戻す
    private void Initialize()
    {
        // スコアを0に戻す
        score = 0;

        // ハイスコアを取得する。保存されてなければ0を取得する。
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    // ポイントの追加
    public void AddPoint(int point)
    {
        score = score + point;
    }

    // ハイスコアの保存
    public void Save()
    {
        if (life > 1)
        {
            life -= 1;
        }
        else
        {


            PlayerPrefs.SetInt(highScoreKey, highScore);
            PlayerPrefs.Save();
            int hung = int.Parse(StatusManager.variable.get("f.food"));
            int fly = int.Parse(StatusManager.variable.get("f.fly"));
            int band = int.Parse(StatusManager.variable.get("f.band"));
            hung -= 20;
            fly += score /100;
            band += 10;

            StatusManager.variable.set("f.food", hung.ToString());
            StatusManager.variable.set("f.fly", fly.ToString());
            StatusManager.variable.set("f.band", band.ToString());
            SceneManager.LoadScene("Master");
        }
    }
            // ハイスコアを保存する

}
