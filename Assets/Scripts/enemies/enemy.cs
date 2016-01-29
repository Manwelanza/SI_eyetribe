using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

    public int points = 10;
    public float speed = 10f;
    public float speedDown = 5f;
    
    private static int n_enemies = 0;
    private static bool right = true;
    private static bool secure = false;

	// Use this for initialization
	void Start () {
        n_enemies++;
        speed = 50f;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        int aux;
        if (right)
        {
            aux = 1;
        }
        else
        {
            aux = -1;
        }

        transform.Translate(aux * speed * Time.deltaTime, 0, 0);
        if (secure)
        {
            secure = false;
        }
	}

    public void  moveDown ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].transform.Translate(0, - speedDown, 0);
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.collider.tag == "wall")
        {
            if (!secure)
            {
                secure = true;
                if (right)
                {
                    right = false;
                }
                else
                {
                    right = true;
                }
                moveDown();
            }
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
