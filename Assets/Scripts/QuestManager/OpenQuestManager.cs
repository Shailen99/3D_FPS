using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenQuestManager : MonoBehaviour
{
  public GameObject QuestManager;
  public Text QuestText;
  public GameObject QuestTextHolder;

  //Deactivate Main Camera movement
  public GameObject CameraActivate;


    // Start is called before the first frame update
    void Start()
    {
      QuestText.text = "Press Q to Open Questbook";
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Q) && QuestTextHolder.activeSelf)
      {
      if(!QuestManager.activeSelf)
      {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        QuestManager.SetActive(true);
        QuestText.text = "Press Q to Close Questbook";
        //Deactivate Camera movement
        CameraActivate.GetComponent<MouseLook>().enabled = false;

      }
      else
      {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        QuestManager.SetActive(false);
        QuestText.text = "Press Q to Open Questbook";
        //Activate Camera movement

        CameraActivate.GetComponent<MouseLook>().enabled = true;

      }
    }
  }
}
