using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [Header("References")]
    public CinemachineVirtualCamera selectCam;
    public CinemachineVirtualCamera orbitCam;
    public CinemachineVirtualCamera overheadCam;


    void Update() {
        //If push tab, swap cams
        if (Input.GetKeyDown(KeyCode.Tab)) {
            swapCams();
        }
        
        //--DEBUGGING--
        if (Input.GetKeyDown(KeyCode.Space)) {
            setPriority("overhead");
        }
    }

    public void setPriority(string camName) {
        //set priority of selected cam
        switch(camName) {
            case "orbit":
                zeroPriority();
                orbitCam.Priority = 1;
                return;
            case "select":
                zeroPriority();
                selectCam.Priority = 1;
                return;
            case "overhead":
                zeroPriority();
                overheadCam.Priority = 1;
                return;
            default:
                Debug.Log("Camera Manager: Invalid Camera Name");
                return;
        }        
    }

    //Set all priority to 0
    private void zeroPriority() {
        selectCam.Priority = 0;
        orbitCam.Priority = 0;
        overheadCam.Priority = 0;
    }

    //Swap vcams via priority
    private void swapCams() {
        if (selectCam.Priority > 0) {
            setPriority("orbit");
        } else {
            setPriority("select");
        }
    }
}
