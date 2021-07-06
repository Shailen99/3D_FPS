using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWeapon : MonoBehaviour
{

  //Sword
  public GameObject ActiveSword;
  public GameObject SwordIcon;
  public SwordCollection SwordCollect;

  //Gun
  public GameObject ActiveGun;
  public GameObject GunIcon;
  public HunterGunAI GunCheck;


  //Bools
  public bool isSwordActive;
  public bool isGunActive;

    // Update is called once per frame
    void Update()
    {
      //SwordDisplay
      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
        if(SwordCollect.SwordActive == true)
            {
                if(ActiveSword.activeSelf)
                {
                  SwordIcon.SetActive(true);
                  ActiveSword.SetActive(false);
                }
                else
                {
                  if(ActiveGun.activeSelf == false)
                    {
                  ActiveSword.SetActive(true);
                  SwordIcon.SetActive(false);
                  }
                }

          }
        }



        //GunDisplay

      if (Input.GetKeyDown(KeyCode.Alpha2))
        {
          if(ActiveSword.activeSelf == false)
          {
          if(GunCheck.GunBought == true)
          {
              if(ActiveGun.activeSelf)
              {
                GunIcon.SetActive(true);
                ActiveGun.SetActive(false);
              }
              else
              {
                ActiveGun.SetActive(true);
                GunIcon.SetActive(false);
              }
            }
          }
        }
      }
}
