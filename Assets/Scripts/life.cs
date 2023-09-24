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

    private bool died = false;

    void Start() {
        health = maxHealth;
    }

    void Update() {
        
    }

    public void takeDamage(float damageAmount) {
        //Don't do anything if dead
        if(died) {
            return;
        }

        health -= damageAmount;
        if (health <= 0) {
            die();
        }
    }

    public void die() {
        //Death
        Debug.Log("Died");
        died = true;
    }

    public bool isDead() {
        return died;
    }
}
