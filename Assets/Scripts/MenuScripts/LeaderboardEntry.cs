﻿using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class LeaderboardEntry {

	public string player { get; set; }
	public int score { get; set; }

	public LeaderboardEntry(string player, int score)
	{
		this.player = player;
		this.score = score;
	}

}
