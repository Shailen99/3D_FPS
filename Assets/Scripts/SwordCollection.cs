using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollection : MonoBehaviour
{
  public GameObject UnusedSword;
  public GameObject userSword;
  public static bool SwordActive;
  public GameObject UIDisplay;

  private void OnTriggerEnter(Collider sword)
 {
   if(sword.tag == "Sword")
   {
    // Debug.Log("hi");
     UnusedSword.SetActive(false);
     userSword.SetActive(true);
     SwordActive = true;

     UIDisplay.SetActive(true);

   }
 }
}
