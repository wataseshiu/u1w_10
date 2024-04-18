using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DarkTonic.MasterAudio;

public class GameManager : MonoBehaviour {

    public enum GAME_STATE
    {
        STATE_TITLE,
        STATE_GAME_INIT,
        STATE_GAME_START,
        STATE_GAME_PLAYING,
        STATE_GAME_TIMEOVER,
    }

    public GAME_STATE GameStete;

    public GameObject GameMain;
    public GameObject GameInit;
    public GameObject GameTitle;
    public GameObject GameOver;
    public GameObject ObjPool;
    public TextMeshProUGUI ObjPool_Score;

    public float count = 0;

    // Use this for initialization
    void Start () {
        GameStete = GAME_STATE.STATE_TITLE;
    }
	
	// Update is called once per frame
	void Update () {

        //タイトル画面
        if (GameStete == GAME_STATE.STATE_TITLE)
        {
            //ゲーム開始時の入力チェック
            if (Input.GetButtonDown("Cancel"))
            {
                //ゲーム開始処理
                //ステートきりかえ
                GameStete = GAME_STATE.STATE_GAME_INIT;

                //タイトルシーケンス非表示
                GameTitle.SetActive(false);

                //ゲームシーケンス表示
                GameInit.SetActive(true);
            }
        }
        //ゲーム開始前の画面
        else if (GameStete == GAME_STATE.STATE_GAME_INIT)
        {
            //3秒待機
            if (count < 3)
            {
                count += Time.deltaTime;
            }
            //3秒立ったら次のシーケンスへ
            else
            {
                //一応countを戻しておく
                count = 0;

                //ステートきりかえ
                GameStete = GAME_STATE.STATE_GAME_PLAYING;

                //開始前シーケンス非表示
                GameInit.SetActive(false);

                //ゲームシーケンス表示
                GameMain.SetActive(true);
            }
        }

        //ゲームオーバー画面
        else if (GameStete == GAME_STATE.STATE_GAME_TIMEOVER)
        {
            if (!GameOver.activeSelf)
            {
                GameOver.SetActive(true);
                ObjPool.SetActive(false);
                ObjPool_Score.text = GameMain.GetComponentInChildren<ScoreManager>().Score.ToString();
                MasterAudio.ChangePlaylistByName("PlayList_Score");
                //MasterAudio.StopPlaylist("PlaylistController");
            }
            //ゲームオーバー時の入力チェック
            if (Input.GetButtonDown("Cancel"))
            {
                ////ゲーム開始処理
                ////ステートきりかえ
                //GameStete = GAME_STATE.STATE_TITLE;

                ////ゲームシーケンス表示
                //GameMain.SetActive(false);

                ////タイトルシーケンス表示
                //GameTitle.SetActive(true);
                SceneManager.LoadScene(0);
            }
        }
    }

    //タイムオーバーにステートを切り替える
    void GameStateChangeTimeOver()
    {
        //ステートきりかえ
        GameStete = GAME_STATE.STATE_GAME_TIMEOVER;
    }
}
