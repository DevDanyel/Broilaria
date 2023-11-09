using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onion : MonoBehaviour
{
    public IngrediantsObject IngrediantsObject;
    public MeshFilter onionMeshFilter;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Start(){
        IngrediantsObject.chopStatus = false;
        IngrediantsObject.slider = slider;
        IngrediantsObject.gradient = gradient;
        IngrediantsObject.fill = fill;
        onionMeshFilter = this.gameObject.GetComponent<MeshFilter>();
        onionMeshFilter.mesh = IngrediantsObject.unchoppedMesh;
        IngrediantsObject.totalChopTime = 120f;
        IngrediantsObject.SetMaxSlider(IngrediantsObject.totalChopTime);
        IngrediantsObject.currentChopTimeStatus = 0;
        IngrediantsObject.currentSliderStatus = 0;
        IngrediantsObject.SetSlider(0);
    }

    void Update(){

    }

    public void ChangeMeshToChopped(){
        Debug.Log("changing mesh");
        onionMeshFilter.mesh = IngrediantsObject.choppedMesh;
    }

    public void IncreaseCutStatus(){
        if(IngrediantsObject.totalChopTime >= IngrediantsObject.currentChopTimeStatus){
            IngrediantsObject.currentChopTimeStatus +=10f;
            IngrediantsObject.SetSlider(IngrediantsObject.currentChopTimeStatus);
            StartCoroutine(ExampleCoroutine());
        }else{
            IngrediantsObject.chopStatus=true;
            //ChangeMeshToChopped();

        }
    }
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
       // Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }



}
