using UnityEngine;
using System.Collections;

public class specialRespawn : MonoBehaviour {

    public int points2Appear = 300;
    public GameObject specialEnemy;

    private bool appear = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	    if ((updatePoints.getPoints() >= points2Appear) && !appear)
        {
            Instantiate(specialEnemy, transform.position, transform.rotation);
            appear = true;
        }
	}
}
