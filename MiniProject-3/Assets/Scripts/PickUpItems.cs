using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    [SerializeField] GameObject pickUp;
    [SerializeField] GameObject PickUpMesseage;
    private bool pickUpActive=false;
    [Tooltip("1=apple,2=battery,3=knife,4=bat,5=axe,6=gun")]
    [SerializeField]int pickUpType;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            pickUpActive = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpActive = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(pickUpActive==true)
        {
            if(Save.canPickup==true)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    PickUpMesseage.SetActive(false);
                    pickupCheck();
                    
                }
            }
        }
    }
    void pickupCheck()
    {
        if (pickUpType == 1)
        {
            Save.PlayerHealth += 10;
            if(Save.PlayerHealth>100)
            {
                Save.PlayerHealth = 100;
            }
            Save.DisplayPlayerHealth = true;
            Destroy(pickUp, 0.2f);
        }
        else if (pickUpType==3)
        {
            Save.haveKnife = true;
            Destroy(pickUp, 0.2f);
        }
      else  if (pickUpType == 4)
        {
            Save.haveBat = true;
            Destroy(pickUp, 0.2f);
        }
       else if (pickUpType == 5)
        {
            Save.haveaxe = true;
            Destroy(pickUp, 0.2f);
        }
       else if (pickUpType == 6)
        {
            Save.haveGun= true;
            Destroy(pickUp, 0.2f);
        }
    }
}
