using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesDefeated : MonoBehaviour
{
    public Transform EnemyObject;
    public int EnemiesLeft;
    public bool EnemiesDefeated;

    // Update is called once per frame
    void Update()
    {
        if (EnemyObject.childCount < 1) {
            EnemiesDefeated = true;
        } else {
            EnemiesDefeated = false;
        }
        EnemiesLeft = EnemyObject.childCount;
    }
}
