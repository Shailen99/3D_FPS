using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageFound : MonoBehaviour
{
  public bool isPackageActivated = false;
  public GameObject Package;
  public bool PackageCollected = false;
  public StartQuest checkPackageFound;
  public GameObject RewardIndicator;

  private void OnTriggerEnter(Collider PackageObject)
  {
    if(PackageObject.tag == "LocationQuestPackage")
    {
      Package.SetActive(false);
      PackageCollected = true;
      checkPackageFound.isPackageFound = true;
      RewardIndicator.SetActive(true);

    }
  }
    // Update is called once per frame
    public void ActivatePackage()
    {
      Package.SetActive(true);
      isPackageActivated = true;
    }
}
