using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BotonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().color = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FeedBack()
    {
        if (gameObject.name == "exit")
        {
            GetComponent<Text>().color = Color.red;
        }
        else
        {
            GetComponent<Text>().color = Color.green;
        }
    }

    public void DisableFeedBack()
    {
        GetComponent<Text>().color = Color.white;
    }
}
