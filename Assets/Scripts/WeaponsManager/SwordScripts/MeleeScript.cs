using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{
  Animator anim;
    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
  {
    bool mousePressed = Input.GetKeyDown(KeyCode.Mouse0);
    bool isAttacking = anim.GetBool("attacking");
    if(!isAttacking && mousePressed)
      {
        anim.SetBool("attacking",true);

      }
      if(isAttacking && !mousePressed)
          {
            anim.SetBool("attacking",false);

          }
    }
}
