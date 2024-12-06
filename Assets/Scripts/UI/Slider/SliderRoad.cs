using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderRoad : SliderBase
{
    private float startPosition = 0f;
    private float endPosition = 400f;
    private float currentPosition;
    protected override void Start()
    {

        if (slider != null)
        {
            slider.minValue = startPosition;
            slider.maxValue = endPosition;
            currentPosition = 0f;
            slider.value = startPosition;
        }
    }
    void Update()
    {
        UpdateProgressLava();
    }

    protected virtual void UpdateProgressLava()
    {
        if (slider == null) return;
        if (currentPosition > endPosition) return;

        currentPosition = PlayerController.Instance.transform.position.z;
        SetValue(Mathf.Clamp(currentPosition, 0f, 400f));
    }


    protected override void OnChanged(float valueChanged)
    {
       
    }
}
