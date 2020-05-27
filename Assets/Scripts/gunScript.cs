using System.Collections;
using UnityEngine;

public class gunScript : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public int ClipSize = 20;
    public int CurrentBullets = 20;
    public float ReloadTime = 1;
    public Transform fpsCam;
    public ParticleSystem muzzleFlash;
    public Animator Animator;
    private bool IsReloading = false;

    // Update is called once per frame
    void Update() {
        if(Input.GetButtonDown("Fire1")){
            if (IsReloading) {
                return;
            }
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.R)) {
            StartCoroutine(Reload());
            return;
        }
    }

    void Shoot() {
        if (CurrentBullets < 1) {
            return;
        } else {
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

    IEnumerator Reload() {
        IsReloading = true;
        Animator.SetBool("Reloading",true);
        yield return new WaitForSeconds(ReloadTime);
        CurrentBullets = ClipSize;
        Animator.SetBool("Reloading",false);
        IsReloading = false;
    }
}
