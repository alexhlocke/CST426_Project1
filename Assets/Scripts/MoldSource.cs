using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoldSource : MonoBehaviour
{
    [Header("Properties")]
    [Range(0,10)]
    [Tooltip("Radius of effect")]
    public float radius;
    [Range(0,10)]
    [Tooltip("Rate of mold spreading")]
    public float rate;


    void Update() {

    }

    //Debugging gizmos
    void OnDrawGizmos() {
        //Draw a green sphere showing molds aoe
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("trigger entered");
        if (col.gameObject.CompareTag("troop") || col.gameObject.CompareTag("enemy"))
        {
            MoldDebuff moldManager = col.gameObject.GetComponent<MoldDebuff>();
            moldManager.ActivateScript();
            if (moldManager.duration < 0)
            {
                moldManager.duration = 10;
            }
        }
    }
}