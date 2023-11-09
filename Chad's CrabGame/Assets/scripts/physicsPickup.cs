using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicsPickup : MonoBehaviour
{
    [SerializeField] private LayerMask pickupMask;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform pickupTarget;
    [Space]
    [SerializeField] private float pickupRange;
    [SerializeField] private Rigidbody currentObject;
    //public for now cause I dont know how to code
    private bool hasObject;
    
    void Start(){
        //Debug.Log("started Script");
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            if(currentObject){
                currentObject.useGravity = true;
                currentObject.GetComponent<Collider>().isTrigger = false;
                SetCurrentObjectNull();
                return;
            }

            Ray CameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f,.5f, 0f));
            if(Physics.Raycast(CameraRay, out RaycastHit HitInfo, pickupRange, pickupMask)){
                currentObject = HitInfo.rigidbody;
                currentObject.useGravity = false;
                currentObject.GetComponent<Collider>().isTrigger = true;
            }
        }
    }

    void FixedUpdate(){
        if(currentObject){
            Vector3 DirectionToPoint = pickupTarget.position - currentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;
            
            currentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;
        }
    }

    public bool GetHoldingStatus(){
        //Debug.Log("entersthis");
        if(currentObject == null){return false;}else return true;
        //Debug.Log("Exits");
    }

    private void SetCurrentObjectNull(){
        currentObject =null;
    }

    public Rigidbody GetPlayerObject(){
        Rigidbody tempCurrentIngrediant = currentObject;
        SetCurrentObjectNull();
        return tempCurrentIngrediant;
    }
}
