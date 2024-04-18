using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class ObjController : MonoBehaviour {

    public GameObject Player;
    public int number = 0;
    public bool isTitle = false;

    public Sprite[] sprites;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");

        //数字をランダムで取得してくる
        number = Random.Range(1, 9);

        //実際に描画される数字もそれに合わせる
        GetComponentInChildren<SpriteRenderer>().sprite = sprites[number];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "Player" )
        {
            //タイトルでは無視する処理
            if( !isTitle )
            {
                GetComponentInParent<Spawner>().isCounting = true;
            }
            //Playerの加算処理を行う
            Player.SendMessage("AddNumber", number);
            Destroy(this.gameObject);

        }
    }
}
