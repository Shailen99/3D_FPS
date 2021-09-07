using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
  public float TargetDistance = 100.0f;
  //ActivateGame
  [Header("NPC")]
  public GameObject ActivateSign;
  public Text ActiveText;

  public bool isNPCDialogueActive = false;
  public float timer = 5.0f;
  public BranchingDialogueSystem dialogue;

  public bool isDialogueAlreadyActive = false;
   void Update()
  {
  //  Vector3 fwd = fpsCamera.transform.TransformDirection(Vector3.forward);
  //Check if raycast hit

  if ( Input.GetMouseButtonDown (0)){
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (Physics.Raycast (ray,out hit,TargetDistance)) {
         Debug.Log("You selected the " + hit.transform.name); // check you picked right object

//TalkableNPC
         //Check if NPC is interacted with
         if(hit.transform.tag == "TalkableNPC" && !isDialogueAlreadyActive)
         {
           ActivateSign.SetActive(true);
           ActiveText.text = "Press X to Talk";
           isDialogueAlreadyActive = true;
           }
         }
       }
      if (Input.GetKeyDown(KeyCode.X) && ActivateSign.activeSelf && ActiveText.text == "Press X to Talk")
        {
        ActivateSign.SetActive(false);
        //Activate Dialogue
        dialogue.DialogueSystemIsActive = true;
      }
    }
  }

/*   IEnumerator ScaleMe(Transform objTr) {
    objTr.localScale *= 1.2f;
    yield return new WaitForSeconds(0.5f);
    objTr.localScale /= 1.2f;
}*/
