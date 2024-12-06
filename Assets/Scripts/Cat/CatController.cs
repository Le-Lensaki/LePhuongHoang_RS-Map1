using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatController : LensakiMonoBehaviour
{
    [SerializeField] protected CatMovement movement;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref movement);
    }

    public void StartMove(bool isMove)
    {
        movement.StartMove(isMove);
    }    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Zone")
        {
            other.GetComponent<ZoneController>().ShowZone();
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
        if(other.gameObject.name == "ZoneLoot")
        {
            movement.StopMove();
            
            transform.parent = PlayerController.Instance.transform;
            Vector3 newPos = PlayerController.Instance.transform.position;
            PlayerController.Instance.UpNubmerCatRescue();
            int numberCat = PlayerController.Instance.NumberCatRescue();
            newPos.y += 18f + 2f * numberCat;
            transform.SetPositionAndRotation(newPos, PlayerController.Instance.transform.rotation);
            transform.Find("Tutorial Arrow").gameObject.SetActive(false);
            GameManager.Instance.RunToFinish();
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Zone")
        {
            other.GetComponent<ZoneController>().HideZone();
            other.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
