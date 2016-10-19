﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapBehaviour : MonoBehaviour {

	public int id;
	public float rotateSpeed = 1;
	public float translateSpeed = 1;
	public float translateAmplitude = 1;

	private Vector3 _startPosition;

	// Use this for initialization
	void Start () {
		_startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, 20 * Time.deltaTime * rotateSpeed);

		transform.position = _startPosition + new Vector3(0.0f, translateAmplitude * Mathf.Sin(Time.time * translateSpeed), 0.0f);
	}

	public void OnTriggerEnter(Collider other)
	{
		// TODO "pick up" map

	
		if (id == 3 && other.gameObject.tag == "Player") // last map to collect and it's actually the player hitting it
		{
			UIAdapter.win();

			//check for the trap master achievement
			List<string> achievementsToDisplay = new List<string> ();
			if (!AchievementController.hasBeenDamagedByTraps) {
				AchievementController.updateAchievement ("Traps? what traps?", !AchievementController.hasBeenDamagedByTraps);
				achievementsToDisplay.Add ("Traps? what traps?");

				//cycle through all achievements youved gained
				AchievementController.displayAchievements(achievementsToDisplay);

			}
			SoundAdapter.playCollectSound();
			Destroy(this.gameObject);

		}

		//see if the box acheivement is achieved
		if (id == 1 && other.gameObject.tag == "Player") {

			//check for the puzzle achievement
			List<string> achievementsToDisplay = new List<string> ();
			if (!AchievementController.hasFailedBoxStage) {
				AchievementController.updateAchievement ("Puzzle Master", !AchievementController.hasFailedBoxStage);
				achievementsToDisplay.Add ("Puzzle Master");
			
				//cycle through all achievements youved gained
				AchievementController.displayAchievements(achievementsToDisplay);

			}
			SoundAdapter.playCollectSound();
			Destroy(this.gameObject);

		}
	}

}
