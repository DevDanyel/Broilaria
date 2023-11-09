using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Appliances")]
public class ApplianceObject : ScriptableObject
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    //[SerializeField] public float MaxSliderAmount = 100f;
    [SerializeField] public float currentSliderStatus;

    void Awake(){
        currentSliderStatus = 0;
    }

    public void SetMaxSlider(int chop)
	{
		slider.maxValue = chop;
		slider.value = chop;

		fill.color = gradient.Evaluate(1f);
	}

    public void SetSlider(int chop)
	{
		slider.value = chop;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

    
}
