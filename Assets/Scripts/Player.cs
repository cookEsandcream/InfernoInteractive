﻿using UnityEngine;
using System.Collections;
using System;
//Adapted from inScope Studios' health bar tutorial
//This demonstrates the code  on the player's side.
using UnityEngine.UI;
using AssemblyCSharp;


public class Player : MonoBehaviour {

	public UIAdapter ui;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			ui.damagePlayer (-10);
		} else if (Input.GetKeyDown (KeyCode.S)) {
			ui.damagePlayer (10);
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			ui.damageBoss (-1);
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			ui.damageBoss (1);
		} else if (Input.GetKeyDown (KeyCode.Space)) {
			ui.achieve();
		}
	}
}
