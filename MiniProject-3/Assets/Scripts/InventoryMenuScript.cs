using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject KnifeBlank;
    [SerializeField] private GameObject BatBlank;
    [SerializeField] private GameObject AxeBlank;
    [SerializeField] private GameObject GunBlank;
    bool panel = false;
    
    void Start()
    {
        inventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
        {
            if (panel == false)
            {
                inventoryCheck();
                Time.timeScale = 0f;
                inventoryPanel.SetActive(true);
                panel = true;
                Cursor.visible = true;

            }

            else if (panel == true)
            {
                
                
                    Time.timeScale = 1f;
                    inventoryPanel.SetActive(false);
                    panel = false;
                    Cursor.visible = false;
                
            }

        }

    }
    public void OnKnife()
    {
        Save.weaponID = 1;
        Save.weaponChange = true;
    }
    public void OnBat()
    {
        Save.weaponID = 2;
        Save.weaponChange = true;
    }
    public void OnAxe()
    {
        Save.weaponID = 3;
        Save.weaponChange = true;
    }
    public void OnGun()
    {
        Save.weaponID = 4;
        Save.weaponChange = true;
    }
    void inventoryCheck()
    {
        if(Save.haveKnife==true)
        {
            KnifeBlank.SetActive(false);
        }
        if (Save.haveKnife == false)
        {
            KnifeBlank.SetActive(true);
        }
        if (Save.haveBat == true)
        {
            BatBlank.SetActive(false);
        }
        if (Save.haveBat == false)
        {
            BatBlank.SetActive(true);
        }
        if (Save.haveaxe == true)
        {
            AxeBlank.SetActive(false);
        }
        if (Save.haveaxe == false)
        {
            AxeBlank.SetActive(true);
        }
        if (Save.haveGun == true)
        {
            GunBlank.SetActive(false);
        }
        if (Save.haveGun == false)
        {
            GunBlank.SetActive(true);
        }
    }
}
