using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    [Header("References")]

    [Header("Health")]
    [Range(0f,200f)]
    public float maxHealth = 100f;
    public float health;
    
    [Header("Status Effects")]
    public float moldPercent = 0f;
    public float cookedPercent = 0f;

    void Start() {
        health = maxHealth;
    }

    void Update() {
        
    }

    public void takeDamage(float damageAmount) {
        health -= damageAmount;
        if (health <= 0) {
            die();
        }
    }

    public void die() {
        Debug.Log("Died");
    }
}
