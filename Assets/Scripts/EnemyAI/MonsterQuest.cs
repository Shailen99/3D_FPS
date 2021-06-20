using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterQuest : MonoBehaviour
{
  public GameObject DialogueBox;
  public Text DialogueText;
  public bool QuestActivated = false;
  public bool QuestFinished = false;
  public GameObject EnemyEventActivator;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider BountyBoard)
   {
     if(BountyBoard.tag == "BountyBoard")
     {
       if(!QuestActivated && !QuestFinished)
       {
         //Introduce Dialogue for telling players to buy drinks
         DialogueBox.SetActive(true);
         DialogueText.text = "Accept Monster Quest at Village Entrance (Press Y to Accept or N to leave)";
         QuestActivated = true;
      //   DialogueConfirmText.text = "Press Y to buy a drink or N to leave";
    }
     }
   }


    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Y))
      {
          DialogueBox.SetActive(false);
          EnemyEventActivator.SetActive(true);
        }

      else if(Input.GetKeyDown(KeyCode.N))
      {
        DialogueBox.SetActive(false);
      }

    }
}
