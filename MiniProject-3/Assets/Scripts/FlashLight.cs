using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
   private bool lightOn=false;
    [SerializeField]private GameObject flight;
    
  

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(lightOn==false)
            {
                flight.gameObject.SetActive(true);
                lightOn = true;
            }
            else if(lightOn==true)
            {
                flight.gameObject.SetActive(false);
                lightOn = false;
            }
        }
    }
}
