using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(0f,15f)]
    public float speed = 10f; // Bullet speed.
    [Range(0f,20f)]
    public float lifetime = 2f; // Bullet lifetime (in seconds).
    public float damage = 1f;

    private void Start() {
        // Set the bullet's initial velocity.
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) {
            rb.velocity = transform.forward * speed;
        }

        // Destroy the bullet after a specified lifetime.
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision col) {

        // Check if the bullet has hit an enemy (you may need to customize this part).
        if (col.gameObject.CompareTag("enemy"))
        {
            life enemyLife = col.gameObject.GetComponent<life>();
            enemyLife.takeDamage(damage);

            //Destroy Bullet
            Destroy(this.gameObject);
        }
    }

    public void SetDamage(float newDamage) {
        damage = newDamage;
    }
}
