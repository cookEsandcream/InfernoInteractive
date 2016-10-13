﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CircularBarScript : MonoBehaviour {

    public GameObject robot;
    public GameObject deathAnimation;
    public Image circularBar;
    public float speed;
	public GameObject countdownBarCanvas;
    public bool startCountdown;

    void Start () {
        circularBar.fillAmount = 1;
        circularBar.color = Color.yellow;

    }

	void Update () {
        
		if (startCountdown) {
            robot.SetActive(true);
            StartCountdownHealthBar();
        }

        //Make the health bar appear below the specified enemy
        Vector3 newPosition = robot.transform.position;
        newPosition.y = (float)1.5;
        transform.position = Camera.main.WorldToScreenPoint(newPosition);

        //Reset all values when health bar runs out
        if (circularBar.fillAmount == 0)
        {
            countdownBarCanvas.GetComponent<Canvas>().enabled = false;
            ((CircularBarScript)countdownBarCanvas.GetComponentInChildren(typeof(CircularBarScript))).startCountdown = false;
            circularBar.fillAmount = 1;

            robot.SetActive(false);
            //Destroy(robot);
            Instantiate(deathAnimation, robot.transform.position, robot.transform.rotation);            
        }
    }

    void StartCountdownHealthBar()
    {
        //Change colour from green to red
        circularBar.color = Color.Lerp(Color.red, Color.yellow, circularBar.fillAmount);

        //Make health bar empty/unfill to representing a timer running out
        circularBar.fillAmount = circularBar.fillAmount - speed * Time.deltaTime;
    }

}
