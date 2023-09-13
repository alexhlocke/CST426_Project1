using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TroopUI : MonoBehaviour
{
    [Header("References")]
    public GameObject troopParent;
    public Slider healthSlider;

    private life lifeManager;

    void Start() {
        lifeManager = troopParent.GetComponent<life>();
    }
    
    void Update() {
        transform.forward = Camera.main.transform.forward;

        //update life bar
        healthSlider.value = lifeManager.health / lifeManager.maxHealth;
    }
}
