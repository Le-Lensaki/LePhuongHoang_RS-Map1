using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : LensakiMonoBehaviour
{
    
    [SerializeField] protected Rigidbody rigidbodyPlayer;
    [SerializeField] protected Animator anim;
    [SerializeField] protected SliderSpeed sliderSpeed;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float speedUpgrade = 0f;
    private float countDownSpeedUp = 0;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref rigidbodyPlayer);
        LoadComponent(ref anim);
        LoadComponentByName(ref sliderSpeed, "SliderSpeed");
    }

    protected override void Start()
    {
        base.Start();
        SetUIMaxSpeed();
    }
    public void SetUIMaxSpeed()
    {
        if (sliderSpeed == null) return;
        float maxSpeed = Mathf.Round((PlayerController.Instance.GetSpeedPlayer() + speed + speedUpgrade - PlayerController.Instance.NumberCatRescue() * 0.9f)*10)/10;
        
        sliderSpeed.SetMaxSpeed(maxSpeed);
    }

    public void UpgradeSpeed(float speedUp)
    {
        speedUpgrade += speedUp;
        SetUIMaxSpeed();
    }

    private void Update()
    {
        if(speedUpgrade > 0)
        {
            if(GameManager.Instance.gameStart)
            {
                if (GameManager.Instance.gameRunToFinish) return;

                countDownSpeedUp += Time.deltaTime;
                if (countDownSpeedUp >= 3)
                {
                    speedUpgrade = 0;
                    SetUIMaxSpeed();
                }
            }     
        }    
        
    }


    private void FixedUpdate()
    {
        this.Movement();
    }

    protected void Movement()
    {
        Vector3 direction = InputManager.Instance.InputVector;
        PlayAnimationIdle();
        if (direction.magnitude < 0.1f) return;
        PlayAnimationMovement();
        direction.Normalize();
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        float rotationSpeed = 10f;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        rigidbodyPlayer.velocity = direction* (speed+PlayerController.Instance.GetSpeedPlayer()+ speedUpgrade - PlayerController.Instance.NumberCatRescue() * 0.9f);
    }

    protected void PlayAnimationIdle()
    {
        if (InputManager.Instance.InputVector.magnitude > 0.1f) return;
        if (!anim.GetBool("Run")) return;

        anim.SetBool("Run", false);
        anim.SetFloat("Movement", 0f);
        rigidbodyPlayer.velocity = Vector3.zero;
        StartCoroutine(ChangeSliderSpeed(0f, 0.5f));
    }
    protected void PlayAnimationMovement()
    {
        if (InputManager.Instance.InputVector.magnitude < 0.1f) return;
        if (anim.GetBool("Run")) return;

        anim.SetBool("Run", true);
        anim.SetFloat("Movement", 1f);
       
        StartCoroutine(ChangeSliderSpeed(1f, 0.5f));
    }

    protected IEnumerator ChangeSliderSpeed(float targetValue, float duration)
    {
        float startValue = sliderSpeed.Slider.value;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            sliderSpeed.SetValue(Mathf.Lerp(startValue, targetValue, time / duration));
            yield return null; 
        }
        sliderSpeed.SetValue(targetValue);
    }

}
