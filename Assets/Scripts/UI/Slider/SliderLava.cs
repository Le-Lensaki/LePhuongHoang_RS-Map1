using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderLava : SliderBase
{
    
    public float speed1 = 15f;
    public float speed2 = 40f;
    private float startPosition = 0f;
    private float endPosition = 400f;
    private float currentPosition;
    protected override void Start()
    {

        if (slider != null)
        {
            slider.minValue = startPosition;
            slider.maxValue = endPosition;
            currentPosition = -150f;
            slider.value = startPosition;
        }
    }
    void Update()
    {
        UpdateProgressLava();
    }

    protected virtual void UpdateProgressLava()
    {
        if(slider == null) return;
        if (currentPosition > endPosition) return;

        currentPosition = LavaController.Instance.transform.position.z;
        currentPosition += 174f;
        if (currentPosition < 0) return;

        SetValue(Mathf.Clamp(currentPosition, 0f, 400f));
    }    


    protected override void OnChanged(float valueChanged)
    {

    }
}
