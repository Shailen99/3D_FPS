using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class StartQuest : MonoBehaviour
{
  public PlayerMovement playerMovement;
  public Quest startQuest;
  public QuestManager questManager;
  public GameObject NPCDialogueManager;
  public Text NPCDialogueText;
  public string[] EntryDialogueLines;

  public GameObject QuestIndicator;
  public GameObject RewardIndicator;

  public bool LocationQuestActivated = false;
  public bool collision = false;//Check if objects have collided
  int currentLine = 0;

  public PackageFound PackageActivated;
  public MoneyManager PlayerMM;

  public bool isPackageFound = false;
  public bool isStartingDialogueFinished = false;

  string[] PackageQuesttasks = {"Hi", "Hello"};

  private void OnTriggerEnter(Collider NPC)
  {
    if(NPC.tag == "VillagerLocationQuest")
    {
      if (isPackageFound == false && isStartingDialogueFinished == false)
      {
        collision = true;
      NPCDialogueManager.SetActive(true);
      QuestIndicator.SetActive(false);
      LocationQuestActivated = true;

      NPCDialogueText.text = EntryDialogueLines[currentLine] + " (Press X to Continue)";
    }
    else if (isPackageFound == true && isStartingDialogueFinished == true  )
    {
      NPCDialogueManager.SetActive(true);
      NPCDialogueText.text = "Thanks for finding the package, here's your reward.";
      StartCoroutine(WaitToSetFalse());
      PlayerMM.AddMoney(1000);
      isPackageFound = false;
      RewardIndicator.SetActive(false);
      int questindex = questManager.CheckQuestIndex("Find Package");
      questManager.Quests[questindex].questTasks = "Quest is Finished";
      collision = true;
    }
  }
}

    // Update is called once per frame
    void Update()
    {
      currentLine = 0;
      if (Input.GetKeyDown(KeyCode.X))
      {
        if(LocationQuestActivated && isPackageFound == false && isStartingDialogueFinished == false)
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
        /*  playerMovement.walkSpeed = 8f;
          playerMovement.sprintSpeed = 12f;
*/
          StartCoroutine(WaitToSetFalse());
          //Activate Package
          LocationQuestActivated = false;
          PackageActivated.ActivatePackage();
          //Add to Quest Manager
          startQuest = new Quest("Find Package","Find a package near the top of the mountain","Go to the Giant Skull and Get the Package" );
          questManager.AddQuest(startQuest);

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
