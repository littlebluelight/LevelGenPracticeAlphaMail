using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;
    private float distanceBetweenPlats;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    //public GameObject[] thePlatforms;
    private int platformSelector;

    public float[] platformWidths;


   public ObjectPooler[] theObjectPools;


	void Start () {
        // platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x
        platformWidths = new float[theObjectPools.Length];

        for (var i = 0; i < theObjectPools.Length;i++){

            //here we are calling pooled obj from the object pooler script (its public)
            platformWidths[i] = theObjectPools[i].pooledObj.GetComponent<BoxCollider2D>().size.x;
            //platformWidths[i] = theObjectPools[i].pooledObj.GetComponent<BoxCollider2D>().size.x;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < generationPoint.position.x){
            distanceBetweenPlats = Random.Range(distanceBetweenMin, distanceBetweenMax);
            //when we have a good amount of the platforms to select from, can implement weights instead of this
            platformSelector = Random.Range(0, theObjectPools.Length);
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector])/2 + distanceBetweenPlats, transform.position.y, transform.position.z);

          //  Instantiate(/*thePlatform*/theObjectPools[platformSelector], transform.position, transform.rotation);

            GameObject newPlatform = theObjectPools[platformSelector].getPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;

            newPlatform.SetActive(true);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector])/2, transform.position.y, transform.position.z);

        }

    }
}
