using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using DarkTonic.MasterAudio;

public class PlayerController : MonoBehaviour {

    private float vertical;
    private float horizontral;
    private Rigidbody2D rigidbody2d;

    public SpriteRenderer SpriteRender;

    public int number = 0;
    public float speed = 10;

    public GameObject ScoreManager;
    public GameObject SoundManager;
    public Sprite[] sprites;

    public bool isTitle = false;

    // Use this for initialization
    void Start () {
        //スプライトのレンダーをとっておく
		SpriteRender = GetComponentInChildren<SpriteRenderer>();

        //初期状態のセット
        SpriteRender.sprite = sprites[number];
        SpriteRender.material.color = new Color(38 / 255f, 189 / 255f, 86 / 255f);

        //リジッドボディ取得
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        horizontral = Input.GetAxis("Horizontal") * speed;
        vertical = Input.GetAxis("Vertical") * speed;
        rigidbody2d.velocity = new Vector2( horizontral, vertical );
    }

    void AddNumber( int count )
    {
        //加算
        number += count;

        //10以上になった場合チェック
        if( number > 10 )
        {
            //減算する
            number = number % 10;//1の位だけ残したい

            //SE
            MasterAudio.PlaySound("Touch_001");
        }
        //10ちょうどのとき
        else if( number == 10 )
        {
            //タイトルでは無視する処理
            if( !isTitle )
            {
                //スコア加算
                ScoreManager.SendMessage("AddScore");

                //制限時間を延長
                ScoreManager.SendMessage("AddTimer");
            }

            //0に戻す
            number = 0;

            //SE
            MasterAudio.PlaySound("Decision_002");
        }
        else
        {
            //SE
            MasterAudio.PlaySound("Touch_001");
        }

        //全部終わったら描画に反映
        SpriteRender.sprite = sprites[number];
    }
}
