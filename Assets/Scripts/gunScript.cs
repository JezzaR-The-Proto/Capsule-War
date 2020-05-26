using System.Collections;
using UnityEngine;

public class gunScript : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float shootingSpeed = 10f;
    public int ClipSize = 20;
    public int CurrentBullets = 20;
    private float LastReloadTime = 0f;
    private float LastShootTime = 0f;

    public Transform fpsCam;
    public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update() {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.R)) {
            Reload();
        }
    }

    void Shoot() {
        if (Time.time - LastShootTime < 0.1f) {
            return;
        } else if (CurrentBullets < 1) {
            return;
        } else {
            LastShootTime = Time.time;
            CurrentBullets -= 1;
            muzzleFlash.Play();
            RaycastHit hit;
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null) {
                    target.TakeDamage(damage);
                }
            }
        }
    }

    void Reload() {
        if (Time.time - LastReloadTime > 1f) {
            LastReloadTime = Time.time;
            CurrentBullets = ClipSize;
        } else {
            return;
        }
        
    }
}
