using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinny : MonoBehaviour
{
    [Header("Spinny Axises (Axes?) idk man")]
    public bool doXSpinnies;
    public bool doYSpinnies;
    public bool doZSpinnies;
    [Header("Rates of Spinnies")]
    [Range(0f, 1f)]
    public float xSpinRate;
    [Range(0f, 1f)]
    public float ySpinRate;
    [Range(0f, 1f)]
    public float zSpinRate;


    // Update is called once per frame
    void Update() {
        if(doXSpinnies) {
            transform.Rotate(Vector3.right, xSpinRate);
        }
        if(doYSpinnies) {
            transform.Rotate(Vector3.up, ySpinRate);
        }
        if(doZSpinnies) {
            transform.Rotate(Vector3.forward, zSpinRate);
        }
    }
}
