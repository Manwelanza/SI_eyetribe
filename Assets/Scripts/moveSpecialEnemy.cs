using UnityEngine;
using System.Collections;

public class moveSpecialEnemy : MonoBehaviour {

    public float speed = 100f;
    public int points = 200;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.collider.tag == "destructor")
        {
            Destroy(this.gameObject);
        }
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
