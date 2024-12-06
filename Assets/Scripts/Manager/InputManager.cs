using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] protected Vector3 inputVector;
    public Vector3 InputVector => inputVector;

    [SerializeField] protected Vector3 inputTouch;
    public Vector3 InputTouch => inputTouch;

    [SerializeField] protected JoystickController joystick;

    [SerializeField] public RectTransform parentCanvas;

    

    private void Update()
    {
        TouchUpgrade();
        GetInputTouchJoyStick();
        GetVectorInput();
    }
    void GetVectorInput()
    {
        if(joystick != null)
        {
            if (GameManager.Instance.gameRunToFinish) return;
            inputVector = joystick.InputVector;
        }
        //inputVector.x = Input.GetAxisRaw("Horizontal");
        //inputVector.z = Input.GetAxisRaw("Vertical");
    }

    public void StopInput()
    {
        joystick.StopDrag();
    }
    public void RunToFinish()
    {
        inputVector = new Vector3(0, 0, 1f);
    }

    void TouchUpgrade()
    {
        if (!GameManager.Instance.canTouch) return;
        if (Input.touchCount <= 0) return;
        if (GameManager.Instance.enableJoyStick) return;

        Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began)
        {
            PlayerController.Instance.UseStaminaUpgradeSpeed();
        }
        
    }
  
    void GetInputTouchJoyStick()
    {
        if (!GameManager.Instance.canTouch) return;
        if (!GameManager.Instance.enableJoyStick) return;
        if (Input.touchCount <= 0) return;
        if(joystick == null) return;

        Touch touch = Input.GetTouch(0);
        switch(touch.phase)
        {
            case TouchPhase.Began:
                if (!IsTouchOnUI(touch))
                {
                    SetPositionShowJoystick(touch);
                }
                break;
            case TouchPhase.Moved:
                joystick.Drag(touch);
                break;
            case TouchPhase.Ended:
                joystick.StopDrag();
                break;
        }
    }

    private bool IsTouchOnUI(Touch touch)
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
        {
            position = touch.position
        };

        var results = new List<RaycastResult>();

        EventSystem.current.RaycastAll(pointerEventData, results);

        return results.Count > 0;
    }

    protected void SetPositionShowJoystick(Touch touch)
    {
        Vector2 localPoint;

        joystick.ShowJoystick();

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystick.transform.parent.GetComponent<RectTransform>(),
            touch.position,
            null,
            out localPoint
        );

        joystick.transform.localPosition = localPoint;
    }    

}
