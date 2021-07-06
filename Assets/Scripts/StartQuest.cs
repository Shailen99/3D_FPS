using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class StartQuest : MonoBehaviour
{

  public GameObject NPCDialogueManager;
  public Text NPCDialogueText;
  public string[] EntryDialogueLines;

  public GameObject QuestIndicator;
  public GameObject RewardIndicator;

  public bool LocationQuestActivated = false;

  int currentLine = 0;

  public PackageFound PackageActivated;
  public MoneyManager PlayerMM;

  public bool isPackageFound = false;
  public bool isStartingDialogueFinished = false;

  private void OnTriggerEnter(Collider NPC)
  {
    if(NPC.tag == "VillagerLocationQuest")
    {
      if (isPackageFound == false && isStartingDialogueFinished == false)
      {
      NPCDialogueManager.SetActive(true);
      QuestIndicator.SetActive(false);
      LocationQuestActivated = true;

      NPCDialogueText.text = EntryDialogueLines[currentLine] + " (Press X to Continue)";
    }

    if (isPackageFound == true && isStartingDialogueFinished == true  )
    {
      NPCDialogueManager.SetActive(true);
      NPCDialogueText.text = "Thanks for finding the package, here's your reward.";
      StartCoroutine(WaitToSetFalse());
      PlayerMM.AddMoney(1000);
      isPackageFound = false;
      RewardIndicator.SetActive(false);
    }
    }
  }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.X))
      {
        if(LocationQuestActivated )
        {
        currentLine++;
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
          //Activate Package
          LocationQuestActivated = false;
          PackageActivated.ActivatePackage();
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
