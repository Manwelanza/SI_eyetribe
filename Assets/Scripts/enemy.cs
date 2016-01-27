using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

    public int points = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "PlayerBullet")
        {
            updatePoints.add(points);
            Destroy(this.gameObject);
        }
    }
}
