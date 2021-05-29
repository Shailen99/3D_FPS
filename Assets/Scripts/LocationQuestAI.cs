using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationQuestAI : MonoBehaviour
{

  public GameObject QuestNPC;
  public GameObject DialogueBox;
  public Text DialogueText;
  public bool isDialogueActive = false;
  private void OnTriggerEnter(Collider NPC)
 {


   if(NPC.tag == "VillagerLocationQuest")
   {
    // QuestNPC.SetActive(false);
    //Introduce Dialogue for telling player about quest
    Debug.Log("Hello");
    isDialogueActive =true;
    DialogueBox.SetActive(true);
    DialogueText.text = "Hello";


   }
 }
}
