 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{

  public int PlayerMaxHealth;
  public int PlayerCurrentHealth;
  public Text PlayerHealthText;

    // Start is called before the first frame update
    void Start()
    {
      PlayerCurrentHealth = PlayerMaxHealth;
      PlayerHealthText.text = "Health: " + PlayerCurrentHealth + "/" + PlayerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
      if(PlayerCurrentHealth < 0)
      {
        gameObject.SetActive(false);
      }

    }

    public void HurtPlayer(int damageToGive)
    {
      PlayerCurrentHealth -= damageToGive;

      PlayerHealthText.text = "Health: " + PlayerCurrentHealth + "/" + PlayerMaxHealth;

    }

    }
