using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMotelRoom : MonoBehaviour
{
  public GameObject DialogueBox;
  public Text DialogueText;

  public MoneyManager PlayerMM;
  public bool isBuyingRoomActive = false;
  public GameObject Door;


  private void OnTriggerEnter(Collider HotelOwner)
 {
   if(HotelOwner.tag == "HotelOwner" && !isBuyingRoomActive)
   {
     //Introduce Dialogue for telling players to buy drinks
     DialogueBox.SetActive(true);
     DialogueText.text = "Hey, you interested in a room? Costs just $100. (Press Y to buy or N to decline)";
     isBuyingRoomActive = true;

   }

 }


    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Y))
      {
        //Check if they have enough money
        if(PlayerMM.currentGold >= 100)
        {
          if(isBuyingRoomActive)
          {
          PlayerMM.RemoveMoney(100);
          StartCoroutine(WaitToBuyRoom());
          //Turn Door off
        }
      }
      else
      {
        if(isBuyingRoomActive)
        {
 //       yield return new WaitForSeconds(10);
         StartCoroutine(WaitToSetFalse());

       }
   //     DialogueBox.SetActive(false);
      }
    }
    else if(Input.GetKeyDown(KeyCode.N))
    {
      DialogueBox.SetActive(false);
      isBuyingRoomActive = false;

    }
  }

  IEnumerator WaitToSetFalse()
  {
    DialogueText.text = "Sorry, you gotta pay to stay";

   //yield on a new YieldInstruction that waits for 3 seconds.
   yield return new WaitForSeconds(3);
   DialogueBox.SetActive(false);
   isBuyingRoomActive = false;

   }

   IEnumerator WaitToBuyRoom()
   {
     DialogueText.text = "Your room is to the next door at the right. Have a nice stay";

    //yield on a new YieldInstruction that waits for 3 seconds.
    yield return new WaitForSeconds(3);
    DialogueBox.SetActive(false);
    Door.SetActive(false);
    }
  }
