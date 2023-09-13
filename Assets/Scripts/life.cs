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
    public bool isMoldy = false;
    public float moldPercent = 0f;
    public bool isCooked = false;
    public float cookedPercent = 0f;

    void Start() {
        health = maxHealth;
    }

    void Update() {
        
    }
}
