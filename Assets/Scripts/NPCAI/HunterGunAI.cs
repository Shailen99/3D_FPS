using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HunterGunAI : MonoBehaviour
{
  public PlayerMovement playerMovement;

  public GameObject DialogueBox;
  public Text DialogueText;
  public MoneyManager PlayerMM;
  public bool isBuyingWeapon = false;
  public GameObject UserPistol;
  public bool GunBought = false;

  public GameObject GunHolder;

  //Check if Sword is Open
  public DisplayWeapon SwordCheck;

  private void OnTriggerEnter(Collider Hunter)
 {
   if(Hunter.tag == "NPCHunter")
   {
     if(GunBought == false)
     {

     DialogueBox.SetActive(true);
     DialogueText.text = "Hey buddy, you look like a tough guy. I can get you a nice pistol for just a grand. (Press Y to buy a weapon or N to leave)";
     isBuyingWeapon = true;
   }
   }

 }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Y))
         {
           //Check if they have enough money
           if(PlayerMM.currentGold >= 1000)
           {
             if(isBuyingWeapon)
             {
             PlayerMM.RemoveMoney(1000);
             DialogueBox.SetActive(false);
             if(SwordCheck.ActiveSword.activeSelf == true)
             {
             UserPistol.SetActive(true);
             GunHolder.SetActive(true);
             SwordCheck.ActiveSword.SetActive(false);
             playerMovement.walkSpeed = 8f;
             playerMovement.sprintSpeed = 12f;

            }
            else{
              UserPistol.SetActive(true);
              GunHolder.SetActive(true);
              SwordCheck.ActiveSword.SetActive(false);
              playerMovement.walkSpeed = 8f;
              playerMovement.sprintSpeed = 12f;

            }
             GunBought = true;
           }
           }
           else if(PlayerMM.currentGold < 1000)
           {
             if(isBuyingWeapon)
             {
             DialogueText.text = "Dont try and scam me mate, you don't have enough money for a sandwich, let alone a gun.";
              StartCoroutine(WaitToSetFalse());
              playerMovement.walkSpeed = 8f;
              playerMovement.sprintSpeed = 12f;

              }
           }
         }
         else if(Input.GetKeyDown(KeyCode.N))
         {
           DialogueBox.SetActive(false);
           playerMovement.walkSpeed = 8f;
           playerMovement.sprintSpeed = 12f;

         }
       }

       IEnumerator WaitToSetFalse()
       {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        DialogueBox.SetActive(false);

        }

    }
