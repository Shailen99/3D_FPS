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
    Debug.Log("Hello");
    Enemy.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
  }
}

}
