using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
  public string questTitle;
  public string questDescription;

  public string questTasks;

  public bool isQuestActive;
  public bool isQuestFinished;

  public Quest(string _questTitle,string _questDescription, string _questTasks)
  {
    questTitle = _questTitle;
    questDescription = _questDescription;
    questTasks = _questTasks;
  }
}
