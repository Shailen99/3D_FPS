using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationQuestAI : MonoBehaviour
{

//Give money
public MoneyManager theMM;
public int value;
public Text moneyText;

//Dialogue manager
    public GameObject QuestNPC;

    public GameObject DialogueBox;
    public GameObject QuestIndicator;
    public Text DialogueText;
    public bool isDialogueActive = false;
    public bool isQuestActive = false;
    public string[] DialogueLines;
    public int currentLine = 0;
    public GameObject isPackageCollected;

    public bool DialogueEnding = false;

    //Package for client
    public GameObject packageObject;

  private void OnTriggerEnter(Collider NPC)
 {
   isPackageCollected.SetActive(false);

   //Quest Introduction
   if(NPC.tag == "VillagerLocationQuest")
   {
     if(DialogueEnding == false)
     {
      //Set Quest Indicator off and make quest active
      QuestIndicator.SetActive(false);
      isQuestActive = true;
      //Introduce Dialogue for telling player about quest
      isDialogueActive =true;
      DialogueBox.SetActive(true);
      DialogueText.text = DialogueLines[currentLine];
     }
     else if(isPackageCollected.activeSelf)
     {
       isDialogueActive =true;
       DialogueBox.SetActive(true);
       DialogueText.text = "Thanks for finding my package. Here's some money for your troubles.";
       theMM.AddMoney(value);
     }

   }
 }

 public void Update()
 {

   //Check if player pressed continue
   if (Input.GetKeyDown(KeyCode.X) && isQuestActive)
   {
     if(isQuestActive == true && isDialogueActive == true)
     {
       currentLine++;
       if(currentLine >= DialogueLines.Length)
       {
         DialogueBox.SetActive(false);
         isDialogueActive = false;
         DialogueEnding = true;
         packageObject.SetActive(true);
       }
       else
       {
         DialogueText.text = DialogueLines[currentLine];
       }
     }
     else if(isPackageCollected.activeSelf)
     {
       DialogueBox.SetActive(false);
       isPackageCollected.SetActive(false);
      // Destroy(isPackageCollected);
       isQuestActive = false;
       isDialogueActive = false;

     }
   }
 }
}
