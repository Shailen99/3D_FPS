using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemyFight : MonoBehaviour
{
  public GameObject Barrier1;
  public GameObject Barrier2;

  public GameObject Enemy;
  public EnemyHealthManager EnemyHealth;

  public MoneyManager PlayerMM;
  public MonsterQuest CheckQuest;

  private void OnTriggerEnter(Collider EventActivator)
  {
    if(EventActivator.tag == "EnemyEvent")
    {
      Barrier1.SetActive(true);
      Barrier2.SetActive(true);
      Enemy.SetActive(true);
    }
  }


    // Update is called once per frame
    void Update()
    {
      if(EnemyHealth.killEnemy == true)
      {
        Barrier1.SetActive(false);
        Barrier2.SetActive(false);
        CheckQuest.EnemyEventActivator.SetActive(false);
        if(CheckQuest.QuestActivated == true && CheckQuest.QuestFinished == false)
        {
          PlayerMM.AddMoney(200);
          CheckQuest.QuestFinished = true;
        }
      }

    }
}
