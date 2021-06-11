using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BartenderAI : MonoBehaviour
{
  public GameObject DialogueBox;
  public Text DialogueText;

  public MoneyManager PlayerMM;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider Bartender)
   {
     if(Bartender.tag == "Bartender")
     {
         //Introduce Dialogue for telling players to buy drinks
         DialogueBox.SetActive(true);
         DialogueText.text = "Hey, what can I get you? A drink is $5. (Press Y to buy a drink or N to leave)";
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
         PlayerMM.RemoveMoney(5);
         DialogueBox.SetActive(false);
       }
       else if(PlayerMM.currentGold < 5)
       {
         DialogueText.text = "Sorry, you don't have enough money.";
  //       yield return new WaitForSeconds(10);
          StartCoroutine(WaitToSetFalse());

    //     DialogueBox.SetActive(false);

       }
     }
     else if(Input.GetKeyDown(KeyCode.N))
     {
       Debug.Log("You have not bought a drink and left");
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
