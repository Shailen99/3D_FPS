using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
  public GameObject HealthSliderUI;
  public Slider HealthSlider;
  public int MaxHealth;
public int CurrentHealth;
public bool killEnemy = false;
void Start () {
  CurrentHealth = MaxHealth;
  }

    // Update is called once per frame
    void Update()
    {
      HealthSlider.maxValue	 = MaxHealth;

      if(CurrentHealth < 0 )
      {
        gameObject.SetActive(false);
        killEnemy = true;
      }
       if(CurrentHealth > MaxHealth)
      {
        CurrentHealth = MaxHealth;
      }
      HealthSlider.value	 = CurrentHealth;
    }

	public void HurtEnemy(int damageToGive)
	{
		CurrentHealth -= damageToGive;
    HealthSlider.value	 = CurrentHealth;

	}
}
