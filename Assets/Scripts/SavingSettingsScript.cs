using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SavingSettingsScript : MonoBehaviour
{

    private const string SettingsFile = "CapsuleWarSettings.txt";
    public CrosshairSettingScript Script;
    private int CrosshairArrayIndex;

    public void SaveSettings() {
        CrosshairArrayIndex = Script.ArrayIndex;
        if (File.Exists(SettingsFile)) {
            StreamWriter sw = new StreamWriter(SettingsFile);
            sw.Write(CrosshairArrayIndex);
            sw.Close();
        } else {
            StreamWriter sr = File.CreateText(SettingsFile);
            sr.Write(CrosshairArrayIndex);
            sr.Close();
        }
    }
}
