﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class tipsGenerator : MonoBehaviour {

    public Text tipText;

	// Use this for initialization
	void Start () {
        string[] tips = GenerateTips();

        System.Random rnd = new System.Random();
        int index = rnd.Next(tips.Length);

        tipText.text = "Tip: " + tips[index];
    }

    string[] GenerateTips()
    {
        string[] tips = new string[9];

        tips[0] = "Difficulty levels can be changed in he settings menu ";
        tips[1] = "Objectives can be viewed in the pause menu";
        tips[2] = "Gaining achievements will unlock weapon upgradess";
        tips[3] = "The front facing gun is strong, but you need the driver's help to aim it";
        tips[4] = "If you are in trouble, run away and use the repair station or let your shield recharge";
        tips[5] = "Do not stay in one station for too long";
        tips[6] = "Once the shield is activated, you do not need to stay in the station";
        tips[7] = "Each boss has a different set of strengths and weaknesses";
        tips[8] = "Change they way you fight by customising your tank in the Customise menu";

        return tips;
    }
}
