using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesDefeated : MonoBehaviour
{
    public Transform EnemyObject;
    public int EnemiesLeft;
    public bool EnemiesDefeated = false;
    public Animator Door;
    public AudioSource Audio;

    // Update is called once per frame
    void Update()
    {
        if (EnemiesDefeated) {
            return;
        }
        if (EnemyObject.childCount < 1) {
            EnemiesDefeated = true;
            Audio.Play();
            Door.SetBool("Opening",true);
        } else {
            EnemiesDefeated = false;
            Door.SetBool("Opening",false);
        }
        EnemiesLeft = EnemyObject.childCount;
    }
}
