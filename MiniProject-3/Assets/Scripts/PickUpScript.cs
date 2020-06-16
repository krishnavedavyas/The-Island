using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    [SerializeField] float distance = 8.0f;
    [SerializeField] LayerMask ignoreLayer;
    [SerializeField] GameObject pickUpMesseage;
    RaycastHit hit;
   [SerializeField] Transform selected;
    [SerializeField] Transform selection;
    // Update is called once per frame
    void Update()
    {
        if(selection!=null)
        {
            pickUpMesseage.SetActive(false);
            selection = null;
        }
        if (selected==null)
        {
            pickUpMesseage.SetActive(false);
            Save.canPickup = false;
        }
        if(Physics.Raycast(transform.position,transform.forward,out hit,distance,~ignoreLayer))
        {
            selected = hit.transform;
            if(selected.transform.tag=="Pickups")
            {
                pickUpMesseage.SetActive(true);
                Save.canPickup = true;
            }
            selection = selected;
        }
    }
}
