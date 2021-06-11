using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationQuestPackage : MonoBehaviour
{
  public GameObject Package;
  public GameObject DialogueBox;
  public Text DialogueText;
  public GameObject isPackageCollected;

  private void OnTriggerEnter(Collider Package)
 {
   //Quest Introduction
   if(Package.tag == "LocationQuestPackage")
   {
     DialogueBox.SetActive(true);
     DialogueText.text = "You have found the package!";
     isPackageCollected.SetActive(true);

}
}

public void Update()
{
  if (Input.GetKeyDown(KeyCode.X))
  {
    if(Package.activeSelf)
    {
      DialogueBox.SetActive(false);
      Package.SetActive(false);
    }
}
}
}
