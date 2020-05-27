using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCountScript : MonoBehaviour
{
    public gunScript Gun;
    public TMPro.TMP_Text BulletText;
    
    private int MaxBullets;
    private int CurrentBullets;

    // Start is called before the first frame update
    void Start()
    {
        MaxBullets = Gun.ClipSize;
        CurrentBullets = Gun.CurrentBullets;
        BulletText.text = CurrentBullets + "/" + MaxBullets;
    }

    // Update is called once per frame
    void Update()
    {
        MaxBullets = Gun.ClipSize;
        CurrentBullets = Gun.CurrentBullets;
        BulletText.text = CurrentBullets + "/" + MaxBullets;
    }
}
