using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ingrediants")]
public class IngrediantsObject : ScriptableObject
{
    [SerializeField] public Mesh unchoppedMesh;
    [SerializeField] public Mesh choppedMesh;
    


    private void Awake(){}
    private void OnEnable(){}
    private void OnDisable(){}
    private void OnDestroy(){}
}
