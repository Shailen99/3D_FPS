using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
  public int damageToGive = 5;
  public PlayerHealthManager PlayerHealth;
  private void OnTriggerEnter(Collider Enemy)
{
  if(Enemy.tag == "Enemy")
  {
    PlayerHealth.HurtPlayer(damageToGive);
  //  Enemy.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
  StartCoroutine(WaitForMoreDamage());

  }

  IEnumerator WaitForMoreDamage()
  {
   //yield on a new YieldInstruction that waits for 5 seconds.
   yield return new WaitForSeconds(2);
   }
}



}
