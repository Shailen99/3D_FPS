using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitVehicle : MonoBehaviour
{
  public GameObject Player;
  public GameObject UserGUI;
  public GameObject DrivingGUI;
  public GameObject Car;
  public GameObject CarCamera;
  public EnterVehicle VehicleEnter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.E) && Car.gameObject.GetComponent<CarController>().enabled == true)
      {
        Vector3 carPosition = Car.transform.position;

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
