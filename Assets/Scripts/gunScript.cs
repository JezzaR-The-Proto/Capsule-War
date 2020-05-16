
using UnityEngine;

public class gunScript : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float shootingSpeed = 10f;

    public Transform fpsCam;
    public ParticleSystem muzzleFlash;
    public Rigidbody bullet;

    // Update is called once per frame
    void Update() {
        if(Input.GetButtonDown("Fire1")){
            shoot();
        }
    }

    void shoot() {
        muzzleFlash.Play();
        RaycastHit hit;
        Rigidbody newBullet;
        newBullet = Instantiate(bullet, fpsCam.position, Quaternion.Euler(fpsCam.transform.eulerAngles.x,fpsCam.transform.eulerAngles.y,fpsCam.transform.eulerAngles.z));
        newBullet.AddForce(fpsCam.transform.forward * shootingSpeed);
        Destroy(newBullet.gameObject,5);
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {

            Target target = hit.transform.GetComponent<Target>();
            if (target != null) {
                target.TakeDamage(damage);
            }
        }
    }
}
