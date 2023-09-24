using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TroopUI : MonoBehaviour
{
    [Header("References")]
    public GameObject troopParent;
    public Slider healthSlider;
    public GameObject deadIcon;
    public GameObject moldIcon;
    public GameObject moldPercent;
    public GameObject cookedIcon;
    public GameObject cookedPercent;

    private life lifeManager;

    private bool isMolded = false; 
    private TextMeshProUGUI moldP;
    private TextMeshProUGUI cookedP;
    private bool isDead = false; 
    private bool isCooked = false;  
    

    void Awake() {
        //Get ref to life component
        lifeManager = troopParent.GetComponent<life>();

        //Get refs to percentages of mold/cooked
        moldP = moldPercent.GetComponent<TextMeshProUGUI>();
        cookedP = cookedPercent.GetComponent<TextMeshProUGUI>();

        //Turn status icons off
        deadIcon.SetActive(false);
        moldIcon.SetActive(false);
        cookedIcon.SetActive(false);
    }
    
    void Update() {
        // transform.forward = Camera.main.transform.forward;

        //update life bar
        healthSlider.value = lifeManager.health / lifeManager.maxHealth;

        //Check for status icon updates
        if (!isMolded && lifeManager.moldPercent > 0f) {
            moldIcon.SetActive(true);
            isMolded = true;
        }
         if (!isDead && lifeManager.isDead()) {
            deadIcon.SetActive(true);
            isDead = true;
        }
         if (!isCooked && lifeManager.cookedPercent > 0f) {
            cookedIcon.SetActive(true);
            isCooked = true;
        }

        //Update mold/cooked percentages
        if (isMolded) {
            moldP.text = ((int)lifeManager.moldPercent).ToString();
        }
        if (isCooked) {
            cookedP.text = ((int)lifeManager.cookedPercent).ToString();
        }
    }
}
