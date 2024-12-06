using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : LensakiMonoBehaviour
{
    [SerializeField] protected RectTransform joystickBackground;
    [SerializeField] protected RectTransform joystickHandle;
    [SerializeField] protected CanvasGroup canvasGroup;
    private Vector3 inputVector;
    public Vector3 InputVector => inputVector;
    float joystickRadius;
    protected override void Awake()
    {
        base.Awake();
        joystickRadius = joystickBackground.sizeDelta.x / 2f;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref canvasGroup);
    }
    public void Drag(Touch touch)
    {
        if (canvasGroup.alpha != 1) return;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBackground,
            touch.position,
            null,
            out position
        );

        inputVector = position / joystickRadius;

        if (inputVector.magnitude > 1.0f)
        {
            inputVector = inputVector.normalized;
        }

        joystickHandle.anchoredPosition = inputVector * joystickRadius;

        inputVector = new Vector3(inputVector.x, 0, inputVector.y);
    }


    public void StopDrag()
    {
        inputVector = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero;
        HideJoystick();
    }

    public void HideJoystick()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void ShowJoystick()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}
