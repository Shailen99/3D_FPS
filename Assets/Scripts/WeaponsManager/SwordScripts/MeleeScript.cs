using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{
  public AudioSource cameraAudio;
  public AudioClip hitSound;
  public bool quickAttack_Active = false;
  public bool chargedAttack_Active = false;

  Animator anim;
  public float ChargeSwordTimer;
    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
          if(Input.GetMouseButtonDown(0))
          {
            ChargeSwordTimer = Time.time;
            chargedAttack_Active = false;
            quickAttack_Active = false;

          }
          if(Input.GetMouseButtonUp(0))
          {
            cameraAudio.clip = hitSound;
            checkTime();
          }
    }

    public void checkTime()
    {
      float heldTime = Time.time - ChargeSwordTimer;
      Debug.Log(heldTime);
      if(heldTime > 2)
      {
        Debug.Log("ChargedAttack");
        anim.Play("Base Layer.ChargedAttack", 0, 0.0f);
        cameraAudio.Play();
        chargedAttack_Active = true;
      }
      else
      {
        Debug.Log("quickAttack");
        anim.Play("Base Layer.QuickAttack", 0, 0.0f);
        cameraAudio.Play();
        quickAttack_Active = true;

      }
      ChargeSwordTimer = 0;
    }

    public int WhatDamageToGive()
    {
      if(chargedAttack_Active)
      {
        return 15;
      }
      else if(quickAttack_Active)
      {
        return 10;
      }
      return 0;
    }


    }
