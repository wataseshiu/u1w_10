using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour {

    public GameObject[] Spawner;
    public GameObject SpawnObj;

    private GameObject childObject;

	// Use this for initialization
	void Start () {

        //生成条件を満たしているものだけ生成する
        for ( int i = 0; i < Spawner.Length; i++ )
        {
            if ( Spawner[i].GetComponent<Spawner>().isSpawnFirstTime )
            {
                Debug.Log("spawn");
                //数字生成
                childObject = Instantiate( SpawnObj, Spawner[i].transform.position, Quaternion.identity ) as GameObject;
                childObject.transform.parent = Spawner[i].transform;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        //生成条件を満たしているものだけ生成する
        for (int i = 0; i < Spawner.Length; i++)
        {
            if( Spawner[i].GetComponent<Spawner>().isSpawnable )
            {
                Debug.Log("spawn");
                //数字生成
                childObject = Instantiate(SpawnObj, Spawner[i].transform.position, Quaternion.identity) as GameObject;
                childObject.transform.parent = Spawner[i].transform;
                Spawner[i].GetComponent<Spawner>().isSpawnable = false;
            }
        }
	}
}
