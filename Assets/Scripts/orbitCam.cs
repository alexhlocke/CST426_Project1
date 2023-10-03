using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Clamp camera angle/position (doing this by angle feels most simple)
//TODO: Implement panning when holding down mmb, this should be limited to x/z axis

//TODO MAYBE: Lerp with easing to new target

public class orbitCam : MonoBehaviour
{
    [Header("References")]
    public Transform target;

    [Header("Values")]
    [Range(0f,10f)]
    public float rotationSpeed = 5f;
    public float iDistance; //initial distance
    public float maxDist;
    public float minDist;
    [Range(0f,20f)]
    public float zoomSpeed;
    [Range(0f,5f)]
    public float yOffset = 3f;

    private float distance; 
    private Vector3 offset; //offset from target to camera
    private CameraManager camManager;

    private void Start()
    {
        distance = iDistance;
        offset = transform.position - target.position;

        camManager = Camera.main.gameObject.GetComponent<CameraManager>();
    }

    public void setTarget(Transform newTarget) {
        target = newTarget;
        //maybe make this smoother
    }

    private void Update() {
        //if rmb
        if (Input.GetMouseButton(1)) {
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

        //if lmb
        if (Input.GetMouseButtonDown(0)) {
            // Ray cast from cam
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Debug.Log("ID: " + hit.transform.name);

                target = hit.transform;

                //lol i tried ok
                // //if right tags do some shit
                // if (hit.transform.CompareTag("troop") || hit.transform.CompareTag("enemy")) {
                //     //move camera
                //     target = hit.transform;

                //     //set orbit cam as highest priority
                //     camManager.setPriority("orbit");
                // }
            }
        }
    }

    private void updateCamPos() {
        //clamp distnace
        distance = Mathf.Clamp(distance, minDist, maxDist); 

        //do them calculations
        offset = offset.normalized * distance;
        transform.position = target.position + offset;
        transform.LookAt(target);

        //y offset
        Vector3 camPos = transform.position;
        camPos.y += yOffset;
        transform.position = camPos; 
    }
}
