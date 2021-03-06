﻿using UnityEngine;
using System.Collections;

public class ShowDebugLogs : MonoBehaviour
{

    public int logCap = 20;
    private int curLogs = 0;
    private int numDuplicates = 1;
    private string output = "";
    private string myLog = "";
    private string lastLogString = "";


    void OnEnable()
    {
        Application.RegisterLogCallback(HandleLog);
    }


    void OnDisable()
    {
        // Remove callback when object goes out of scope
        Application.RegisterLogCallback(null);
    }


    void HandleLog(string logString, string stackTrace, LogType type)
    {
        //reset logs if hit cap
        if (curLogs == logCap)
        {
            myLog = "";
            curLogs = 0;
        }
        myLog += "\n [" + type + "] : " + logString;
        lastLogString = logString;
        curLogs++;
    }


    void OnGUI()
    {
        //display logs
        GUILayout.Label(myLog);
        string print = "\nNum of calls: " + numDuplicates;
        GUILayout.Label(print);
    }
}
