using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using CodeMonkey.MonoBehaviours;

public class GameHandler_Setup : MonoBehaviour {

    [SerializeField] private CameraFollow cameraFollow;
    private Vector3 cameraPosition;
    private float orthoSize = 80f;
    private float maxX = 170.0f;
    private float maxY = 120.0f;
    private float minX = -20.0f;
    private float minY = 20.0f;

    private void Start() {
        cameraPosition = new Vector3(74, 70);
        cameraFollow.Setup(() => cameraPosition, () => orthoSize, true, true);
    }

    private void Update() {
        float cameraSpeed = 100f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            if (cameraPosition.x >= minX)
            {
              cameraPosition += new Vector3(-1, 0) * cameraSpeed * Time.deltaTime;  
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            if (cameraPosition.x <= maxX)
            {
                cameraPosition += new Vector3(+1, 0) * cameraSpeed * Time.deltaTime;
            }
        }
            
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            if (cameraPosition.y <= maxY)
            {
                cameraPosition += new Vector3(0, +1) * cameraSpeed * Time.deltaTime;
            }
            
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            if (cameraPosition.y >= minY)
            {
                cameraPosition += new Vector3(0, -1) * cameraSpeed * Time.deltaTime;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.KeypadPlus)) {
            if(orthoSize>40)
            orthoSize -= 10f;
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus)) {
            if(orthoSize <80)
            orthoSize += 10f;
        }
    }

    private bool camLimit(Vector3 camPosition)
    {
        if(camPosition.x <=175 && camPosition.x >=-20)
        {
            return true;
        }
        return false;
    }

}
