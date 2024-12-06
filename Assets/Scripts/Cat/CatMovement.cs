using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : LensakiMonoBehaviour
{
    [SerializeField] protected Rigidbody rigidbodyCat;
    [SerializeField] protected Animator anim;
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected Vector3 direction;
    [SerializeField] protected float movementRadius = 20f;
    [SerializeField] protected float detectionDistance = 7f;
    private Vector3 initialPosition;
    private bool isMoving = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref rigidbodyCat);
        LoadAnimator();
    }
    protected void LoadAnimator()
    {
        if (anim != null) return;
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    protected override void Start()
    {
        base.Start();
        initialPosition = transform.position;
        SetDirection(Vector3.right);
    }
    public void StartMove(bool isMove)
    {
        isMoving = isMove;
        SetDirection(Vector3.right);
    }
    public void StopMove()
    {
        isMoving = false;
        rigidbodyCat.isKinematic = true;
        SetDirection(Vector3.zero);
        PlayAnimationIdle();
    }
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    private void FixedUpdate()
    {
        if (isMoving)
            this.Movement();
    }

    protected void Movement()
    {
        PlayAnimationIdle();
        if (direction.magnitude < 0.1f) return;

        PlayAnimationMovement();
        

        float distanceFromStart = transform.position.x - initialPosition.x;
        if (Mathf.Abs(distanceFromStart) >= movementRadius)
        {
            direction = -direction;
        }
        
        if(CheckObstacle())
        {
            direction = -direction;
        }    

        direction.Normalize();
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        float rotationSpeed = 20f;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        rigidbodyCat.velocity = direction * speed;
    }

    private bool CheckObstacle()
    {
        Vector3 startPosition = transform.position + Vector3.up * 5f;
        Ray ray = new Ray(startPosition, direction);
        int layerMask = 1 << LayerMask.NameToLayer("Obstacle");

        Debug.DrawRay(startPosition, direction * detectionDistance, Color.red);
        if (Physics.Raycast(ray, detectionDistance, layerMask))
        {
            return true; 
        }
        return false;
    }
    protected void PlayAnimationIdle()
    {
        if (!anim.GetBool("Run")) return;

        anim.SetBool("Run", false);
        anim.SetFloat("Movement Speed", 0f);
        rigidbodyCat.velocity = Vector3.zero;
    }
    protected void PlayAnimationMovement()
    {
        if (anim.GetBool("Run")) return;

        anim.SetBool("Run", true);
        anim.SetFloat("Movement Speed", 1f);
    }
}
