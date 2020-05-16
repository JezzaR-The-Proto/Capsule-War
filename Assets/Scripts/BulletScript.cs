using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public LayerMask ground;
    public Rigidbody bullet;

    void OnCollisionEnter(Collision other) {
        int layer = other.gameObject.layer;
        if (ground != (ground | (1 << layer))) return;
        Destroy(bullet.gameObject);
    }
}
