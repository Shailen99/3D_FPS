using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
  
  public int damageToGive;
  private void OnTriggerEnter(Collider Enemy)
{
  if(Enemy.tag == "Enemy")
  {
    Enemy.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
  }
}

}
