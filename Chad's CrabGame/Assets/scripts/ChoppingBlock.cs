using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBlock : MonoBehaviour
{

    [SerializeField] private Rigidbody currentIngrediant;
    [SerializeField] private Transform currentIngrediantPos;
    //[SerializeField] private ??? currentIngrediantStatus;

    //[SerializeField] private Transform cuttingPos;
    [SerializeField] private bool isInCuttingPos;
    [SerializeField] private bool playerHasIngrediant;
    physicsPickup pp;
    onion onion;

    //bool IsInCuttingPos(){}
    //bool PlayerHasIngrediant(){}
    //void UpdateCurrentIngrediant(){}
    //StartChoping(){}
    //StopChopping(){}
    //GetItemStatus(){}


    // Start is called before the first frame update
    void Start()
    {
        pp = GameObject.FindGameObjectWithTag("PlayerHolder").GetComponent<physicsPickup>();
        //isInCuttingPos = false;
        //playerHasIngrediant = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerHasIngrediant = pp.GetHoldingStatus();
        if(isInCuttingPos){
            if(playerHasIngrediant && !currentIngrediant){
                if(Input.GetKeyDown(KeyCode.C)){
                    Debug.Log("putting thing down");
                    currentIngrediant = pp.GetPlayerObject();
                    //Get the item rigid body from the player is holding
                    //call put down function from interactPhysics (maybe change physics of item from item)
                    currentIngrediant.transform.position = currentIngrediantPos.transform.position; 
                    //currentIngrediant.transform.Quaternion = new Vector3(0,0,0);
                    //then place item in position of currentIngrediantPos
                }
                
            }
            if(!playerHasIngrediant){
                if(currentIngrediant){
                    if(Input.GetKeyDown(KeyCode.C) ){
                        onion=currentIngrediant.GetComponent<onion>();
                        onion.ChangeMeshToChopped();
                    }
                }
                //if(currentIngrediantStatus == "unchopped"){ 
                //    if(Input.GetKeyDown == Key.KeyCode("C")){
                        //StartChopping();
                //    }
                //}
                //if(currentIngrediantStatus == "chopped"){ 
                    //if(Input.GetKeyDown == Key.KeyCode("C")){
                      //  return;
                    //}
                //}
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("player in cuttin pos");
            isInCuttingPos = true;
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("player in cuttin pos");
            isInCuttingPos = false;

            //playerHasIngrediant = pp.GetHoldingStatus();//maybe move this back to the triugger functions so thats its only being called when it needs to be 
        }
    }
    


}


/*
Want to make a cutting board that if (holding ingrediant && in front of X(cuutting board)) then ingrediant will be placed on the cutting board.

Then if(ingrediant on cutting board is !isChopped && player is inCuttingPos) then if(holding down cut key) then chop the ingrediant. 

if(player inChopPos)then
No matter what the player can pick up the ingrdiant weather it is finished being chopped or not. 

Chopping board:
Hold ingrdiant 
detect if player is in front of it & differ is player is holding an choppableItem or ! 
display the chopping meter of how long befor currentIngrdiant is chopped.
Allow for player to take the ingrediant if in front of the chopping block
Restictions: 
- cant put non choppable items on the block
- cant have more than one ingrediant on the block 
- multiple players might complicate this mechanic later.(could combat by just multiplying speed of chop)

Variables:
currentIngrediant
currentIngrediantPos
cuttingPosition(use as a trigger like on trigger stay)
playerHasIngrediant (maybe use variable from player script)
currentIngrediantStatus (to keep track of if the item is chopped or not maybe call that form the items code itreself as well)

MECHANICS:
IsInCuttingPos (Detect is player is in chopping position)
PlayerHasIngrediant (detect if player has iungrediant)
StartChopping (starts to cut ingrediant)
StopSchopping (stops cutting ingrediant)
GetItemStatus (determine if currentIngrediant's status) 
*/
