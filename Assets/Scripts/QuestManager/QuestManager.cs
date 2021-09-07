using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
  public GameObject[] Buttons;
  public Text[] ButtonText; //QuestTitle


  //Quest Description Elements
  public Text Description;
  public Text Quest_Title;

  public List<Quest> Quests = new List<Quest>();     // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
      int questCount = 0;
      foreach(Quest quest in Quests)
      {
        Buttons[questCount].SetActive(true);
        questCount++;
      }
//Rename all quest buttons
      for(int i = 0; i < Quests.Count; i++)
      {
        ButtonText[i].text = Quests[i].questTitle; //Rename buttons to quest
      }
    }

  public void AddQuest(Quest quest)
    {
      Quests.Add(quest);
    }
    public void RemoveQuest(Quest quest)
    {
      Quests.Remove(quest);

    }

    public int CheckQuestIndex(string questName)
    {
      int x = 0;
      foreach(Quest quest in Quests)
      {
        if(questName == Quests[x].questTitle)
        {
          return x;
        }
        x++;
      }
      return x;
    }
}
