using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWeapon : MonoBehaviour
{
  public GameObject ActiveSword;
  public GameObject WorldSword;
  public Text DisplaySwordText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
            if(WorldSword.activeSelf == true)
            {

            }
            else if(WorldSword.activeSelf == false)
            {

                if(ActiveSword.activeSelf)
                {
                  ActiveSword.SetActive(false);
                  DisplaySwordText.text = "Press E to Show Weapon";
                }
                else
                {
                  ActiveSword.SetActive(true);
                  DisplaySwordText.text = "Press E to Hide Weapon";
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
