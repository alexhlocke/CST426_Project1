using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Clamp camera angle/position (doing this by angle feels most simple)
//TODO: Implement panning when holding down mmb, this should be limited to x/z axis

//TODO MAYBE: Lerp with easing to new target

public class orbitCam : MonoBehaviour
{
    public Transform target;
    [Range(0f,10f)]
    public float rotationSpeed = 5f;
    public float iDistance; //initial distance
    public float maxDist;
    public float minDist;
    [Range(0f,20f)]
    public float zoomSpeed;

    private float distance; 
    private Vector3 offset; //offset from target to camera

    private void Start()
    {
        distance = iDistance;
        offset = transform.position - target.position;
    }

    public void setTarget(Transform newTarget) {
        target = newTarget;
        //maybe make this smoother
    }

    private void Update() {
        //if rmb
        if (Input.GetMouseButton(1))
        {
            //get mouse movement
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            //rotate the camera based on mouse movement
            Quaternion horizontalRotation = Quaternion.AngleAxis(mouseX * rotationSpeed, Vector3.up);
            Quaternion verticalRotation = Quaternion.AngleAxis(-mouseY * rotationSpeed, transform.right);

            offset = verticalRotation * horizontalRotation * offset;
        }

        //if scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0) {
            distance -= scroll * zoomSpeed;
        }

        updateCamPos();
    }

    private void updateCamPos() {
        //clamp distnace
        distance = Mathf.Clamp(distance, minDist, maxDist); 

        //do them calculations
        offset = offset.normalized * distance;
        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}
