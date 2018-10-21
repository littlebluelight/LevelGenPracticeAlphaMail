using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooler : MonoBehaviour {

    public GameObject pooledObj;

    public int pooledAmnt;

    List<GameObject> pooledObjs;
 

	// Use this for initialization
	void Start () {

        pooledObjs = new List<GameObject>();

        for (int i = 0; i < pooledAmnt; i++){
            //extra game object just casting to make sure pooled obj is a game object
            GameObject obj = (GameObject)Instantiate(pooledObj);
            obj.SetActive(false);
            pooledObjs.Add(obj);
        }


	}

    public GameObject getPooledObject(){
        for (int i = 0; i < pooledObjs.Count; i++){
            if(!pooledObjs[i].activeInHierarchy){
                return pooledObjs[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObj);
        obj.SetActive(false);
        pooledObjs.Add(obj);

        return obj;

    }
}
