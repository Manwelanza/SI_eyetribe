using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

    public GameObject bullet;
    public GameObject shooter;
    public float delayShoot = 0.5f;
    public float delayStart = 0f;
    public bool random = false;
    public int probability;

    private float timerShoot = 0f;
    private float timerStart = 0f; 

	// Use this for initialization
	void Start () {
        timerShoot = 1 + delayShoot;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (timerStart > delayStart)
        {
            if (timerShoot > delayShoot)
            {
                if (!random)
                {
                    Instantiate(bullet, shooter.transform.position, shooter.transform.rotation);
                    timerShoot = 0f;
                }
                else
                {
                    timerShoot = 0f;
                    int aux =  Random.Range(0, 100);
                    if (aux < probability)
                    {
                        Debug.Log(aux);
                        Instantiate(bullet, shooter.transform.position, shooter.transform.rotation);
                    }
                }
            }
            timerShoot += Time.deltaTime;
        }
        else
        {
            timerStart += Time.deltaTime;
        }
	}
}
