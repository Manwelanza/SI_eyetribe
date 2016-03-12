﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public enum eTiposLayers_Game
{
    UI = 5
}

public class KeysController : MonoBehaviour {
    public float timeLimit = 0.5f;
    public VisualKeyboardController interfaz;

    private float counter;
    private Ray ray;
    private RaycastHit hit;
    private bool active;
    private GameObject objectObserved;
    private string text;

    // Use this for initialization
    void Awake () {
        counter = 0f;
        active = false;
        hit = new RaycastHit();
        ray = new Ray();
        objectObserved = null;
        text = "";
	}

    // Update is called once per frame
    void Update () {
        if (active)
        {
            GraphicRaycaster graphic = this.GetComponent<GraphicRaycaster>();
            PointerEventData point = new PointerEventData(null);
            point.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            graphic.Raycast(point, results);
            bool anyItem = false;

            EventSystem.current.RaycastAll(point, results);
            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    if (results[i].gameObject.GetComponent<Button>() != null)
                    {
                        if (objectObserved == results[i].gameObject)
                        {
                            if (counter >= timeLimit)
                            {
                                if (objectObserved.name == "ENTER")
                                {
                                    anyItem = true;
                                    interfaz.EndVisualKeyboard();
                                    counter = 0;
                                    break;
                                }
                                else if (objectObserved.name == "REMOVE")
                                {
                                    anyItem = true;
                                    text = text.Substring(0, text.Length - 1);
                                    counter /= 3;
                                    break;
                                }
                                else if (objectObserved.name == "REMOVE_ALL")
                                {
                                    anyItem = true;
                                    text = "";
                                    counter = 0;
                                    break;
                                }
                                else
                                {
                                    if (results[i].gameObject.name != "continue" &&
                                        results[i].gameObject.name != "Button")
                                    {
                                        anyItem = true;
                                        text += results[i].gameObject.GetComponentInChildren<Text>().text;
                                        counter = -0.1f;
                                        try
                                        {
                                            objectObserved.GetComponent<KeyController>().DisableFeedBack();
                                        }
                                        catch (System.Exception excepcion)
                                        {

                                        }
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                anyItem = true;
                                counter += Time.deltaTime;
                                try
                                {
                                    objectObserved.GetComponent<KeyController>().FeedBack();
                                }
                                catch (System.Exception excepcion)
                                {

                                }
                                break;
                            }
                        }
                        else
                        {
                            try
                            {
                                objectObserved.GetComponent<KeyController>().DisableFeedBack();
                            }
                            catch (System.Exception excepcion)
                            {

                            }
                            Debug.Log("Cambio de objeto");
                            counter = Time.deltaTime;
                            objectObserved = results[i].gameObject;
                            break;
                        }
                    }
                    else
                    {
                        //Debug.Log("No entro aqui");
                        //counter = 0f;
                        //objectObserved = null;
                        //break;
                        
                    }
                }
            }
            else
            {
                Debug.Log(results.Count);
            }

            if (!anyItem)
            {
                try
                {
                    objectObserved.GetComponent<KeyController>().DisableFeedBack();
                }
                catch (System.Exception excepcion)
                {

                }
            }
        }
	}


    public void TurnOnVisualKeyboard ()
    {
        active = true;
    }

    public void TurnOffVisualKeyboard ()
    {
        active = false;
    }

    public string getText ()
    {
        return text;
    }
}
