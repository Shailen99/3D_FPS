using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
  public int MaxHealth;
public int CurrentHealth;
public bool killEnemy = false;
void Start () {
CurrentHealth = MaxHealth;
}

    // Update is called once per frame
    void Update()
    {
      if (CurrentHealth < 0) {
  			Destroy (gameObject);
        killEnemy = true;
      }
    }


	public void HurtEnemy(int damageToGive)
	{
		CurrentHealth -= damageToGive;
	}
}
