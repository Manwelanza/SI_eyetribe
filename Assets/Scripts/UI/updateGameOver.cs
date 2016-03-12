﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using SpaceInvaders;

public class updateGameOver : MonoBehaviour {

    private static Canvas gameOver;
    private static Text score;
    private static InputField input;
    private static string player;

    public static GameObject father;
    public static GameObject visualKeyboard;
    public float timeLimit = 0.5f;
    public GameObject objectObserved = null;

    private float counter = 0f;

	// Use this for initialization
	void Start () {
        gameOver = GetComponent<Canvas> ();
        gameOver.enabled = false;
        father = GameObject.Find("father");
        Text[] texts = GetComponentsInChildren<Text>();
        foreach (Text i in texts)
        {
            if (i.gameObject.name == "points")
            {
                score = i;
                break;
            }
        }


        Image [] images = GetComponentsInChildren<Image>();
        foreach (Image i in images)
        {
            if (i.gameObject.name == "VisualKeyboard")
            {
                visualKeyboard = i.gameObject;
                visualKeyboard.GetComponent<VisualKeyboardController>().interfaz = this;
                visualKeyboard.SetActive(false);
                break;
            }
        }


        input = GetComponentInChildren<InputField>();
        InputField.OnChangeEvent se = new InputField.OnChangeEvent();
        se.AddListener(EditInput);
        input.onValueChanged = se;
	}

    public void EditInput (string arg0)
    {
        player = arg0;
    }
	
	public static void show () {
        gameOver.enabled = true;
        score.text = updatePoints.getPoints().ToString();
        input.ActivateInputField();
        input.Select();
        father.SetActive(false);
        visualKeyboard.SetActive(false);
    }

    public void startGame()
    {
        Points.stateGame.Save(new PlayerPoint(player, updatePoints.getPoints()));
        father.SetActive(true);
        SceneManager.LoadScene("MainMenu");
        game.startGame();
    }

    public static void showVisualKeyboard ()
    {
        visualKeyboard.SetActive(true);
    }

    public void EndVisualKeyboard (string text)
    {
        visualKeyboard.SetActive(false);
        input.text = text;
        player = text;
    }

    void Update ()
    {
        if (gameOver.enabled && !visualKeyboard.activeSelf)
        {
            GraphicRaycaster graphic = this.GetComponent<GraphicRaycaster>();
            PointerEventData point = new PointerEventData(null);
            point.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            graphic.Raycast(point, results);

            EventSystem.current.RaycastAll(point, results);
            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    if (results[i].gameObject.name == "Button")
                    {
                        if (objectObserved == results[i].gameObject)
                        {
                            if (counter >= timeLimit)
                            {
                                showVisualKeyboard();
                                counter = 0f;
                                break;
                            }
                            else
                            {
                                counter += Time.deltaTime;
                                break;
                            }
                        }
                        else
                        {
                            objectObserved = results[i].gameObject;
                            counter = 0;
                            break;
                        }
                        
                    }
                    else if (results[i].gameObject.name == "continue")
                    {
                        if (objectObserved == results[i].gameObject)
                        {
                            if (counter >= timeLimit)
                            {
                                gameOver.enabled = false;
                                startGame();
                                counter = 0f;
                                break;
                            }
                            else
                            {
                                counter += Time.deltaTime;
                                break;
                            }
                        }
                        else
                        {
                            objectObserved = results[i].gameObject;
                            counter = 0;
                            break;
                        }
                    }
                }
            }
        }
    }

}
