using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Ingrediants")]
public class IngrediantsObject : ScriptableObject
{
    [SerializeField] public Mesh unchoppedMesh;
    [SerializeField] public Mesh choppedMesh;
    [SerializeField] public float totalChopTime;
    [SerializeField] public float currentChopTimeStatus;
    [SerializeField] public bool chopStatus;

    public Slider slider;
    public Gradient gradient;
    public Image fill;


    [SerializeField] public float currentSliderStatus;

    private void Awake(){
        currentChopTimeStatus = 0;
        chopStatus=false;
        currentSliderStatus = 0;
    }

    public void SetMaxSlider(float chop)
	{
		slider.maxValue = chop;
		slider.value = chop;

		fill.color = gradient.Evaluate(1f);
	}

    public void SetSlider(float chop)
	{
		slider.value = chop;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
    private void OnEnable(){}
    private void OnDisable(){}
    private void OnDestroy(){}
}
