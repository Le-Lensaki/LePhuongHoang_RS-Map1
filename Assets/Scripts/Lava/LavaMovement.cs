using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMovement : LensakiMonoBehaviour
{
    [SerializeField] protected Rigidbody rigidbodyLava;
    [SerializeField] protected float speed1 = 10f;
    [SerializeField] protected float speed2 = 40f;
    [SerializeField] protected bool StopMove = true;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref rigidbodyLava);
    }

    public void StartLavaMove()
    {
        StopMove = false;
    }

    private void FixedUpdate()
    {
        this.LavaMove();
    }

    protected void LavaMove()
    {
        if (StopMove) return;
        Vector3 vector = new Vector3(0, 0, 1);
        vector.Normalize();
        if (transform.position.z < 226f)
        {
            rigidbodyLava.velocity = vector * speed1;
        }
        if(GameManager.Instance.gameRunToFinish)
        {
            rigidbodyLava.velocity = vector * speed2;
        }    
        if(transform.position.z >= 1226)
        {
            StopMove = false;
            rigidbodyLava.velocity = Vector3.zero;
        }    
        
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            StopLava();
            GameManager.Instance.StopGame();
        }

    }
    public void StopLava()
    {
        StopMove = true;
        rigidbodyLava.velocity = Vector3.zero;
    }
}
