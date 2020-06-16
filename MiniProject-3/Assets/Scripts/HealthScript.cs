using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] Text PHtext;
    void Start()
    {
        PHtext.text = Save.PlayerHealth + "%";
    }

    // Update is called once per frame
    void Update()
    {
        //temp
        if(Input.GetKeyDown(KeyCode.H))
        {
            Save.PlayerHealth -= 10;
            PHtext.text = Save.PlayerHealth + "%";
        }
        if(Save.DisplayPlayerHealth==true)
        {
            Save.DisplayPlayerHealth = false;
            PHtext.text = Save.PlayerHealth + "%";
        }
    }
}
