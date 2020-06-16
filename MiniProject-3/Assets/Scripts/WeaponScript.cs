using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] GameObject knife;
    [SerializeField] GameObject BaseBallBat;
    [SerializeField] GameObject Axe;
    [SerializeField] GameObject Gun;
    Animator anim;
    bool weaponVisible = false;
    private int currentWeapon;
    bool attack = true;
    float waitTime;
    void Start()
    {
        Save.weaponChange = false;
        currentWeapon = Save.weaponID;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Save.weaponChange==true)
        {
            assignWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
        {
            if (weaponVisible == true)
            {
                weaponVisible = false;
                anim.SetBool("ready", false);
            }
        }
            if (currentWeapon>0&&currentWeapon<4)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (weaponVisible == false)
                {
                    weaponVisible = true;
                    anim.SetBool("ready", true);
                }
                else if (weaponVisible == true)
                {
                    weaponVisible = false;
                    anim.SetBool("ready", false);
                }
            }
            if(Input.GetMouseButtonDown(0))
            {
                if(attack==true)
                {
                    if (currentWeapon == 1)
                    {
                        anim.SetInteger("weaponstrike", 1);
                        attack = false;
                        StartCoroutine(pauseAttack());
                    }
                    else if (currentWeapon == 2)
                    {
                        anim.SetInteger("weaponstrike", 2);
                        attack = false;
                        StartCoroutine(pauseAttack());
                    }
                    else if (currentWeapon == 3)
                    {
                        anim.SetInteger("weaponstrike", 3);
                        attack = false;
                        StartCoroutine(pauseAttack());
                    }
                }
            }
       
        }
        if(currentWeapon==4)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (weaponVisible == false)
                {
                    weaponVisible = true;
                    anim.SetBool("gun", true);
                }
                else if (weaponVisible == true)
                {
                    weaponVisible = false;
                    anim.SetBool("gun", false);
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (attack == true)
                {
                    if (currentWeapon == 4)
                    {
                        anim.SetInteger("weaponstrike", 4);
                        attack = false;
                        StartCoroutine(pauseAttack());
                    }

                }
            }
        }
        
    }
    IEnumerator pauseAttack()
    {
        yield return new WaitForSeconds(waitTime);
        attack = true;
        anim.SetInteger("weaponstrike", 0);
    }
    void assignWeapon()
    {
        Save.weaponChange = false;
        currentWeapon = Save.weaponID;
        if(currentWeapon==0)
        {
            knife.gameObject.SetActive(false);
            BaseBallBat.gameObject.SetActive(false);
            Axe.gameObject.SetActive(false);
            Gun.gameObject.SetActive(false);
        }
        if (currentWeapon == 1)
        {
            knife.gameObject.SetActive(true);
            BaseBallBat.gameObject.SetActive(false);
            Axe.gameObject.SetActive(false);
            Gun.gameObject.SetActive(false);
            waitTime = 1.5f;
        }
        if (currentWeapon == 2)
        {
            knife.gameObject.SetActive(false);
            BaseBallBat.gameObject.SetActive(true);
            Axe.gameObject.SetActive(false);
            Gun.gameObject.SetActive(false);
            waitTime = 1.2f;
        }
        if (currentWeapon == 3)
        {
            knife.gameObject.SetActive(false);
            BaseBallBat.gameObject.SetActive(false);
            Axe.gameObject.SetActive(true);
            Gun.gameObject.SetActive(false);
            waitTime = 1.6f;
        }
        if (currentWeapon == 4)
        {
            knife.gameObject.SetActive(false);
            BaseBallBat.gameObject.SetActive(false);
            Axe.gameObject.SetActive(false);
            Gun.gameObject.SetActive(true);
            waitTime = 0.5f;
        }
    }
}
