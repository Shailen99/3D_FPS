using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowQuestInfo : MonoBehaviour
{
  public Button QuestButton;
  public Text QuestText; //Button Text
  //Quest Description Elements
  public Text Description;
  public Text Quest_Title;
  public Text Quest_Task;

  public QuestManager questManager;
    // Start is called before the first frame update
    void Start()
    {
      Button btn = QuestButton.GetComponent<Button>();
      btn.onClick.AddListener(ShowInfoOnClick);

    }

//Show QuestInFO
    public void ShowInfoOnClick()
  {
    Quest_Title.text = QuestText.text;
    //Change Description
    int QuestCount = questManager.CheckQuestIndex(QuestText.text);

    Description.text = questManager.Quests[QuestCount].questDescription;
    Quest_Task.text = questManager.Quests[QuestCount].questTasks;

  }
}
