﻿using UnityEngine;
using System.Collections;

public class ActivateNewDialog : MonoBehaviour {

	public UnityEngine.GameObject cutscene;
    public UnityEngine.GameObject mainCamera;

    public TextAsset theText;

    public int startLine = 0;
    public int endLine = 0;

    public DialogTextManager dialogManager;

    public bool destroyWhenActivated = true;

    public bool stopGameMovements;

    private QuickCutsceneController cutsceneController;
    public int lineNumber;

    // Use this for initialization
    void Start () {
        dialogManager = FindObjectOfType<DialogTextManager>();
        cutsceneController = cutscene.GetComponent<QuickCutsceneController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Tank")
        {
            if(stopGameMovements == true)
            {
                dialogManager.stopGameMovements = true;
            }
            else
            {
                dialogManager.stopGameMovements = false;
            }

            dialogManager.ReloadScript(theText);
            dialogManager.currentLineNumber = startLine;
            dialogManager.endLineNumber = endLine;
            if(cutscene != null)
            {
                dialogManager.SetCutscene(mainCamera, cutsceneController, lineNumber);
            }
            dialogManager.EnableDialogBox();

            //if end line isnt inputted default to all lines
            if (endLine == 0)
            {
                dialogManager.endLineNumber = dialogManager.textLines.Length - 1;
            }

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }

}
