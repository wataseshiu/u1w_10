using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float RespawnTimer = 0.0f;
    public float RespawnLimit = 3.0f;
    public bool isCounting = false;
    public bool isSpawnFirstTime = true;//プレイヤー初期位置とかぶるやつだけfalseにしておく
    public bool isSpawnable = false;
    public bool isPlayerFar = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //リスポーンタイマー
		if( isCounting )
        {
            RespawnTimer += Time.deltaTime;

            if( RespawnTimer > RespawnLimit )
            {
                //リスポーン通知を飛ばす

                //リスポーンタイマーはリセット
                RespawnTimer = 0;

                //カウントも止める
                isCounting = false;
            }
        }

        //再生成可能かチェック
        if( !isSpawnable )
        {
            if( isPlayerFar && !isCounting && transform.childCount == 0 )
            {
                isSpawnable = true;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerFar = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerFar = true;
        }
    }
}
