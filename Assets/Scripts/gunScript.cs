
using UnityEngine;

public class gunScript : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float shootingSpeed = 10f;

    public Transform fpsCam;
    public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update() {
        if(Input.GetButtonDown("Fire1")){
            shoot();
        }
    }

    void shoot() {
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
