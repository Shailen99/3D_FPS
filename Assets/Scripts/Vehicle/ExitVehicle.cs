using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitVehicle : MonoBehaviour
{
  [Header("GUIs")]
  public GameObject UserGUI;
  public GameObject DrivingGUI;


  [Header("CarObjects")]
  public GameObject Car;
  public GameObject CarCamera;
  public EnterVehicle VehicleEnter;
  [Header("Misc")]
  public GameObject Player;


    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.E) && Car.gameObject.GetComponent<CarController>().enabled == true)
      {
        Vector3 carPosition = Car.transform.position;
        VehicleEnter.CanDrive = false;
        Car.gameObject.GetComponent<CarController>().enabled = false;
        CarCamera.SetActive(false);
        //set player to true
        Player.transform.position = new Vector3(Car.transform.position.x-5,Car.transform.position.y,Car.transform.position.z-5);
        Player.SetActive(true);
        UserGUI.SetActive(true);
        DrivingGUI.SetActive(false);


      }

    }
}
