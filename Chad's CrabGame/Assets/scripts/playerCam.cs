using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCam : MonoBehaviour
{
    public float senseX;
    public float senseY;

    public Transform orientation;

    float xRotation;
    float yRotation;



    private void Start(){
        //locks curser in place
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    private void Update(){
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senseX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senseY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        //rotate cam and orentation
        transform.rotation = Quaternion.Euler(xRotation,yRotation,0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }


}
