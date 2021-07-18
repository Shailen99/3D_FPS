using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
  public bool CanDrive = false;
  private void OnTriggerEnter(Collider Car)
  {
    if(Car.tag == "DrivableVehicle")
    {
      ActivateSign.SetActive(true);
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
