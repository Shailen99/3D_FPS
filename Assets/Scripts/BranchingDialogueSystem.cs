using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.IO;

public class BranchingDialogueSystem : MonoBehaviour
{
  [Header("DialogueManager")]

  public string[] EntryDialogueLines;
  public Text NPCDialogueBox;
  public Text PlayerTextBox1;
  public Text PlayerTextBox2;
  public Text PlayerTextBox3;

  [Header("DialogueTools")]
  public int currentLine = 0;
  public bool DialogueSystemIsActive = false;
  public GameObject DialogueManager;
  public bool isEntryBranchOpen = false;

  public bool exitBranchOpen = false;
  public bool isSecondaryBranchOpen = false;
  //Text Options

  public void Update()
  {
    if(DialogueSystemIsActive && !isEntryBranchOpen)
    {
      DialogueManager.SetActive(true);      //dialogue system is now open
      RunOpeningLines();
      isEntryBranchOpen = true;
    }
    //Check if opening system is pressed
      if(isEntryBranchOpen && Input.GetKeyDown(KeyCode.Alpha1) && !isSecondaryBranchOpen)
      {
          NPCDialogueBox.text = "Nice to meet you, what are you doing in this town";
          PlayerTextBox1.text = "A. Don’t know just woke up here";
          PlayerTextBox2.text = "B. Here to start a new life";
          PlayerTextBox3.text = "";
          isSecondaryBranchOpen = true;
      }
      //Second Branch
      else if (isEntryBranchOpen && Input.GetKeyDown(KeyCode.Alpha2) && !isSecondaryBranchOpen)
      {
        NPCDialogueBox.text = "Right there at the bartender";
        PlayerTextBox1.text = "Thanks and Goodbye!";
        PlayerTextBox2.text = "";
        PlayerTextBox3.text = "";
        StartCoroutine(WaitToSetFalse());
      }
      else if (isEntryBranchOpen && Input.GetKeyDown(KeyCode.Alpha3) && !isSecondaryBranchOpen)
      {
        NPCDialogueBox.text = "A few, some transporters are near the gas station and the mayors alway looking for more minimum wage workers.";
        PlayerTextBox1.text = "Thanks and Goodbye!";
        PlayerTextBox2.text = "";
        PlayerTextBox3.text = "";
        StartCoroutine(WaitToSetFalse());
      }


        if (isEntryBranchOpen && Input.GetKeyDown(KeyCode.A) && isSecondaryBranchOpen)
        {
          RunSecondLineBranch();
        }
         if (isEntryBranchOpen && Input.GetKeyDown(KeyCode.B) && isSecondaryBranchOpen)
        {
          RunThirdLineBranch();
        }
  }

  public void RunOpeningLines()
  {
    NPCDialogueBox.text = EntryDialogueLines[0];
    PlayerTextBox1.text = "1." + EntryDialogueLines[1];
    PlayerTextBox2.text = "2." + EntryDialogueLines[2];
    PlayerTextBox3.text = "3." + EntryDialogueLines[3];
  }

  public void RunSecondLineBranch()
  {
    NPCDialogueBox.text = "Oh, maybe, you need to talk to the mayor, he knows what to with all the drifters";
    PlayerTextBox1.text = "Thanks and Goodbye!";
    PlayerTextBox2.text = "";
    PlayerTextBox3.text = "";
    StartCoroutine(WaitToSetFalse());
  }

  public void RunThirdLineBranch()
  {
  NPCDialogueBox.text = "Well then, go to the mayor to figure it out.";
  PlayerTextBox1.text = "Thanks and Goodbye!";
  PlayerTextBox2.text = "";
  PlayerTextBox3.text = "";
  StartCoroutine(WaitToSetFalse());
  }

  IEnumerator WaitToSetFalse()
  {
   //yield on a new YieldInstruction that waits for 5 seconds.
   yield return new WaitForSeconds(3);
   DialogueManager.SetActive(false);
   isEntryBranchOpen = false;
   isSecondaryBranchOpen = false;
   DialogueSystemIsActive = false;
   }

}
