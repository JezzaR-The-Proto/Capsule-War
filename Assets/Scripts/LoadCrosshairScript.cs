using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadCrosshairScript : MonoBehaviour
{
    public Image Crosshair;
    public UnityEngine.Object[] CrosshairArray;
    public int ArrayIndex = 0;
    private string SettingsFile = "CapsuleWarSettings.txt";
    private string SettingsString;
    private List<string> AllSettings = new List<string>();
    private bool IsParseable;

    // Start is called before the first frame update
    void Start()
    {
        CrosshairArray = Resources.LoadAll("Crosshairs", typeof(Sprite));
        StreamReader sr = File.OpenText(SettingsFile);
        SettingsString = sr.ReadLine();
        while (SettingsString != null) {
            AllSettings.Add((string)SettingsString);
            SettingsString = sr.ReadLine();
        }
        IsParseable = Int32.TryParse(AllSettings[0], out ArrayIndex);
        if (IsParseable) {
            Crosshair.sprite = (Sprite)CrosshairArray[ArrayIndex];
        }
        
    }
}
