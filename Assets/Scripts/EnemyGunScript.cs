using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGunScript : MonoBehaviour
{
    public Transform fpsCam;
    public ParticleSystem muzzleFlash;
    public float range = 100f;
    public float damage = 10f;
    public HealthBar HealthBar;
    public Slider HealthSlider;
    private float TargetHealth = 0f;
    private float LastShot = 0f;

    public void Shoot(float ShootInterval) {
        if (Time.time - LastShot > ShootInterval) {
            LastShot = Time.time;
            RaycastHit hit;
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
                Transform target = hit.transform;
                muzzleFlash.Play();
                if (target != null) {
                    if (Random.Range(0,100) > 25) {
                        TargetHealth = HealthSlider.value;
                        TargetHealth -= damage;
                        HealthBar.SetHealth(TargetHealth);
                    }
                }
            }
        }
    }
}
