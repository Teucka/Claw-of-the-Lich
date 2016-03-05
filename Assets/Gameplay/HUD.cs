﻿using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour
{
    private CameraScripts cameraScripts = null;
    private PartySystem partySystem = null;
    // Use this for initialization
    void Start()
    {
        cameraScripts = Camera.main.GetComponent<CameraScripts>();
        partySystem = GameObject.Find("PartySystem").GetComponent<PartySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            cameraScripts.toggleLock();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            HealthBar[] healthBars = FindObjectsOfType(typeof(HealthBar)) as HealthBar[];
            foreach (HealthBar bar in healthBars)
            {
                bar.toggleVisibility();
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            foreach (GameObject c in partySystem.characters)
            {
                if (c != null && c.GetComponent<UnitCombat>() != null)
                    c.GetComponent<UnitCombat>().takeDamage(-c.GetComponent<UnitCombat>().getMaxHealth());
            }
        }
    }

    void OnGUI()
    {
        int width = Screen.width;
        //int height = Screen.height;

        GUI.Label(new Rect(10, 30, 300, 20), "Press F to Toggle Camera Lock to Selection");
        GUI.Label(new Rect(10, 50, 300, 20), "Press V to Toggle Show Healthbars");
        GUI.Label(new Rect(10, 70, 300, 20), "Press (Shift +) Num to (De)select a Character");
        GUI.Label(new Rect(10, 90, 300, 20), "Press H to Heal Player Characters");
        GUI.Label(new Rect(10, 110, 300, 20), "Press S to Stop Moving");
        float msec = Time.deltaTime * 1000.0f;
        float fps = 1.0f / Time.deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(new Rect(width - 110, 10, 110, 20), text);
    }
}
