using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsAppliance : MonoBehaviour
{
    [SerializeField] private LayerMask applianceMask;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform applianceTarget;
    [Space]
    [SerializeField] private float applianceRange;
    [SerializeField] private Rigidbody currentObject;

    void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            //if not holding anything then do this 
            Ray CameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f,.5f, 0f));
            if(Physics.Raycast(CameraRay, out RaycastHit HitInfo, applianceRange, applianceMask)){
                //Debug.Log("I want to start Chopping");
                //in here call to the chopping board to let it know to take the item and place it in current Ingrediant Position Or to take from currentIngrediantPosition which might not need
            }
        }
    }

}
