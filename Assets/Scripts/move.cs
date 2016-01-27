using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    public float speed;

    private CharacterController controller;
    private Vector3 movement;

	void Start () {
        //controller = GetComponent<CharacterController>();
        movement = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        movement *= Time.deltaTime * speed;
        //controller.Move(movement);
        transform.Translate(movement);
	}

    void OnCollisionEnter(Collision collider)
    {
        if (collider.collider.tag == "Finish" )
        {
            Destroy(collider.gameObject);
            Debug.Log("he entrado 1");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            Destroy(other.gameObject);
            Debug.Log("he entrado 2");
        }
    }
}
