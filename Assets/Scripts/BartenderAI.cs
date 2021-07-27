using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BartenderAI : MonoBehaviour
{
  public GameObject DialogueBox;
  public Text DialogueText;

  public MoneyManager PlayerMM;
  public bool isBuyingDrink = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider Bartender)
   {
     if(Bartender.tag == "Bartender")
     {
         //Introduce Dialogue for telling players to buy drinks
         DialogueBox.SetActive(true);
         DialogueText.text = "Hey, what can I get you? A drink is $5. (Press Y to buy a drink or N to leave)";
         isBuyingDrink = true;
      //   DialogueConfirmText.text = "Press Y to buy a drink or N to leave";
     }
   }

   public void Update()
   {

     if (Input.GetKeyDown(KeyCode.Y))
     {
       //Check if they have enough money
       if(PlayerMM.currentGold >= 5)
       {
         if(isBuyingDrink == true)
         {
         PlayerMM.RemoveMoney(5);
         DialogueBox.SetActive(false);
         isBuyingDrink = false;

       }
       }
       else if(PlayerMM.currentGold < 5)
       {
         if(isBuyingDrink == true)
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

     }
   }

   IEnumerator WaitToSetFalse()
   {
    //yield on a new YieldInstruction that waits for 5 seconds.
    yield return new WaitForSeconds(5);
    DialogueBox.SetActive(false);

    }

}
