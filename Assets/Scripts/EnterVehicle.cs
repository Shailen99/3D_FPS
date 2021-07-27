using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterVehicle : MonoBehaviour
{
  public GameObject Player;
  public GameObject UserGUI;
  public GameObject DrivingGUI;
  public GameObject Car;
  public GameObject CarCamera;
  public bool isDrivingActive = false;
  //ActivateSign
  public GameObject ActivateSign;
  public Text ActiveText;
  public bool CanDrive = false;
  private void OnTriggerEnter(Collider Car)
  {
    if(Car.tag == "DrivableVehicle")
    {
      ActivateSign.SetActive(true);
      ActiveText.text = "Press X to Drive Vehicle";
      CanDrive = true;
    }
  }

  private void OnTriggerExit(Collider Car)
{
  if(Car.tag == "DrivableVehicle")
  {
    ActivateSign.SetActive(false);
    CanDrive = false;
  }
}

  void Start()
  {
    Car.gameObject.GetComponent<CarController>().enabled = false;

  }
    // Update is called once per frame
    void Update()
    {
    //  carController.enabled = carController.!enabled;

      if (Input.GetKeyDown(KeyCode.X) && CanDrive == true)
      {
        ActivateSign.SetActive(false);
        isDrivingActive = true;
        if(isDrivingActive)
        {
          CarCamera.SetActive(true);
          //set player to false
          Player.SetActive(false);
          UserGUI.SetActive(false);
          DrivingGUI.SetActive(true);
          Car.gameObject.GetComponent<CarController>().enabled = true;

        }
      }

    }
}
