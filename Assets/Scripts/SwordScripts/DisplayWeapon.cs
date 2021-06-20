using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWeapon : MonoBehaviour
{
  public GameObject ActiveSword;
  public GameObject WorldSword;
  public Text DisplaySwordText;

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.I))
      {
            if(WorldSword.activeSelf == false)
            {
                if(ActiveSword.activeSelf)
                {
                  ActiveSword.SetActive(false);
                  DisplaySwordText.text = "Press I to Show Weapon";
                }
                else
                {
                  ActiveSword.SetActive(true);
                  DisplaySwordText.text = "Press I to Hide Weapon";
                }
              }
            }

          }
      //check if sword is active
    /*  if(refScript.SwordActive == true)
      {
        Debug.Log("hello");
      }*/

}
