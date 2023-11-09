using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onion : MonoBehaviour
{
    public IngrediantsObject IngrediantsObject;
    public MeshFilter onionMeshFilter;

    void Start(){
        onionMeshFilter = this.gameObject.GetComponent<MeshFilter>();
    }

    public void ChangeMeshToChopped(){
        Debug.Log("changing mesh");
        onionMeshFilter.mesh = IngrediantsObject.choppedMesh;
    }

}
