using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartArcadeGame : MonoBehaviour
{
  public GameObject ArcadeGameManager;
  public GameObject Player;
  public Canvas UserGUI;
  private void OnTriggerEnter(Collider Bartender)
 {
   if(Bartender.tag == "ArcadeMachine")
   {
     ArcadeGameManager.SetActive(true);
   }
 }


    // Update is called once per frame
    void Update()
    {
      if(ArcadeGameManager.activeSelf)
      {
        Player.SetActive(false);
      }
      else if(ArcadeGameManager.activeSelf != true)
      {
        Player.SetActive(true);

      }
    }
}
