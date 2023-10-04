using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttacking : MonoBehaviour
{
    [Range(0f,10f)]
    public float damageAmount = 8f;
    public float shootingInterval = 2f; // Time between shots.

    public GameObject bulletPrefab;
    public Transform shootingStart;
    public GameObject audio;

    private float nextShotTime;
    private GameObject closestEnemy;

    private FlatAudioManager audioManager;

    void Awake() {
        audio = GameObject.Find("Audio");
        audioManager = audio.GetComponent<FlatAudioManager>();
    }

    void Update() {
        //Look at closest enemy
        if(closestEnemy!=null) {
            transform.LookAt(closestEnemy.transform);
        }

        // Check if it's time to shoot.
        if (Time.time >= nextShotTime) {
            // Find the closest enemy
            GameObject closestEnemy = FindClosestEnemy();

            if (closestEnemy != null) {
                // Rotate to look at the closest enemy.
                transform.LookAt(closestEnemy.transform);

                Shoot();

                // Set the next shot time based on the shooting interval.
                nextShotTime = Time.time + shootingInterval;
            }
        }
    }

    public void Shoot() {
        // Instantiate and shoot a bullet in the direction of the enemy.
        GameObject newBullet = Instantiate(bulletPrefab, shootingStart.position, transform.rotation);
        newBullet.GetComponent<Bullet>().SetDamage(damageAmount);
        audioManager.playFlatSound("Woosh");
    }

    private GameObject FindClosestEnemy() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            //Skip if enemy is dead
            if (enemy.GetComponent<life>().isDead()) {
                continue;
            }

            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance) {
                closestEnemy = enemy;
                closestDistance = distance;
            }
        }

        return closestEnemy;
    }
}
