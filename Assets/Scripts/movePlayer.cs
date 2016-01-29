using UnityEngine;
using System.Collections;

public class movePlayer : MonoBehaviour {

    public float speed = 10f;

    private float diference;
    private CharacterController controller;

	// Use this for initialization
	void Start () {
        diference = 76.44f - 57.5f + 11;
        controller = GetComponent<CharacterController> ();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 positionPlayer = transform.position - new Vector3(diference, 0, 0);
        Vector3 movement = new Vector3 (speed * Time.deltaTime, 0, 0);

        if (positionMouse.x - positionPlayer.x > 1)
        {
            // Move Right
            controller.Move(movement);
        }
        else if (positionMouse.x - positionPlayer.x < -1)
        {
            // Move Left
            controller.Move(-1 * movement);
        }

       //Debug.Log("Mouse -->" + positionMouse.x);
       //Debug.Log("Player -->" + positionPlayer.x);
      

    }
}
