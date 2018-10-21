using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

    public GameObject platformDegenerationPoint;

	// Use this for initialization
	void Start () {
        platformDegenerationPoint = GameObject.Find("PlatformDegenerationPoint");
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x < platformDegenerationPoint.transform.position.x){

            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
		
	}
}
