using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
  public MeleeScript MeleeScript;
  public int quickAttack_DamageToGive;
  public int chargedAttack_DamageToGive;

  private void OnTriggerEnter(Collider Enemy)
{
  if(Enemy.tag == "Enemy")
  {
    Enemy.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(MeleeScript.WhatDamageToGive());
    StartCoroutine(WaitForMoreDamage());
  }
}
  IEnumerator WaitForMoreDamage()
  {
   //yield on a new YieldInstruction that waits for 2 seconds.
   yield return new WaitForSeconds(3);
   }
}
