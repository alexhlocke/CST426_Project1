using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    void LateUpdate() {
        transform.forward = Camera.main.transform.forward;
    }
}
