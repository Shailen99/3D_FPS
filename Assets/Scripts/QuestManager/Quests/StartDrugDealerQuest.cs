using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDrugDealerQuest : MonoBehaviour
{
  public Quest drugDealerQuest;
  public QuestManager questManager;

  public GameObject NPCDialogueManager;
  public Text NPCDialogueText;
  public string[] EntryDialogueLines;

  public bool DrugDealerQuestActivated = false;
  public bool isStartingDialogueFinished = false;
  public bool hasReachedTarget = false;
  public bool DrugDealerTouched = false;
  public MoneyManager PlayerMM;

  int currentLine = 0;

  private void OnTriggerEnter(Collider NPC)
  {
    if(NPC.tag == "DrugDealerQuest")
    {
      if (isStartingDialogueFinished == false)
      {
        NPCDialogueManager.SetActive(true);
        DrugDealerQuestActivated = true;
        NPCDialogueText.text = EntryDialogueLines[currentLine] + " (Press X to Continue)";
      }
      else if(hasReachedTarget && DrugDealerQuestActivated)
      {
        NPCDialogueManager.SetActive(true);

        NPCDialogueText.text = "Thanks kid, here's your money. We'll call you the next time we need a delivery boy.";
        StartCoroutine(WaitToSetFalse());
        int questindex = questManager.CheckQuestIndex("To Make Bank");
        questManager.Quests[questindex].questTasks = "Quest is finished.";
        PlayerMM.AddMoney(500);

      }
    }
    else if(NPC.tag == "DrugReceiverQuest")
    {
      if(DrugDealerQuestActivated && !hasReachedTarget)
      {
        NPCDialogueManager.SetActive(true);
        hasReachedTarget = true;
        NPCDialogueText.text = "Good work kid, head back to the boss for the reward";
        int questindex = questManager.CheckQuestIndex("To Make Bank");
        questManager.Quests[questindex].questTasks = "Head Back to Dealer for reward";
        StartCoroutine(WaitToSetFalse());

      }
    }
  }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.X))
      {
        if(DrugDealerQuestActivated && isStartingDialogueFinished == false)
        {
          if(currentLine < 2)
          {
            currentLine++;
          }
        if(currentLine == 1)
        {
          NPCDialogueText.text = EntryDialogueLines[currentLine] + " (Press X to Continue)";
        }
        else{
          NPCDialogueText.text = EntryDialogueLines[currentLine];
        }
        if(NPCDialogueText.text == EntryDialogueLines[2])
        {
          isStartingDialogueFinished = true;
          StartCoroutine(WaitToSetFalse());
          //Activate NPC And Police
          //Add to Quest Manager
          drugDealerQuest = new Quest("To Make Bank","Deliver package to man  for money","Go behind the bar and deliver the package" );
          questManager.AddQuest(drugDealerQuest);

        }
      }
    }
  }


  IEnumerator WaitToSetFalse()
  {
 //yield on a new YieldInstruction that waits for 5 seconds.
 yield return new WaitForSeconds(3);
 NPCDialogueManager.SetActive(false);
  }

}
