using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairSettingScript : MonoBehaviour
{
    public Image Crosshair;
    public Object[] CrosshairArray;
    public int ArrayIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        CrosshairArray = Resources.LoadAll("Crosshairs", typeof(Sprite));
    }

    public void ChangeImageForward() {
        if (ArrayIndex + 1 != CrosshairArray.Length) {
            ArrayIndex += 1;
            Crosshair.sprite = (Sprite)CrosshairArray[ArrayIndex];
        }
    }

    public void ChangeImageBackward() {
        if (ArrayIndex != 0) {
            ArrayIndex -= 1;
            Crosshair.sprite = (Sprite)CrosshairArray[ArrayIndex];
        }
    }
}
