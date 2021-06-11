using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{

  public Text moneyText;
  public int currentGold;
    // Start is called before the first frame update
    void Start()
    {
      currentGold = 20;

    moneyText.text = "Wallet: $" + currentGold;
    }

    public void AddMoney(int goldToAdd)
    {
      currentGold += goldToAdd;
      moneyText.text = "Wallet: $" + currentGold;
    }

        public void RemoveMoney(int goldToAdd)
        {
          currentGold -= goldToAdd;
          moneyText.text = "Wallet: $" + currentGold;
        }
}
