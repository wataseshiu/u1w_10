using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public GameObject GameManager;
    public int Score = 0;
    public int Score_add = 10;

    public int Timer = 10;
    public int AddTimerNum = 2;
    private float count = 0;

    public TextMeshProUGUI Score_Text;
    public TextMeshProUGUI Timer_Text;

    // Use this for initialization
    void Start()
    {
        ResetScore();
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if( Timer > 0 )
        {
            count += Time.deltaTime;
            if (count >= 1)
            {
                Timer--;
                count = 0;
                TimerUpdate();
            }
        }
        //タイマーがカウント終了している、ゲームオーバー処理へ
        else
        {
            //ゲームステートをTIME_OVERに切り替える
            GameManager.SendMessage("GameStateChangeTimeOver");
        }
    }

    void AddScore()
    {
        //加算するスコアにボーナス係数をかけるときはここでやる


        //スコア加算
        Score += Score_add;
        ScoreUpdate();
    }

    void ResetScore()
    {
        //スコアを0にする
        Score = 0;
        ScoreUpdate();
    }

    void ScoreUpdate()
    {
        Score_Text.text = Score.ToString();
    }

    void AddTimer()
    {
        Timer += AddTimerNum;
        TimerUpdate();
    }

    void TimerUpdate()
    {
        Timer_Text.text = Timer.ToString();
    }

    void ResetTimer()
    {
        //タイマーをリセットする
        Timer = 10;
        TimerUpdate();
    }
}
