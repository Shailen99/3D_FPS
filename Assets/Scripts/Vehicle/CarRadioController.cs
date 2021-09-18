using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarRadioController : MonoBehaviour
{
  public GameObject Car;
  public Text CurrentRadioStationText;
  public List<RadioStation> radioStations = new List<RadioStation>();
  public int currentLine = 0;

  public AudioSource radio;

  public AudioClip[] JPROSongs;
    // Start is called before the first frame update
    void Start()
    {
      //Add Preliminary Stations
      RadioStation RockStation = new RadioStation("Rock FM", "Rock");
      RadioStation RapStation = new RadioStation("Rap FM", "Rap");
      RadioStation PopStation = new RadioStation("Pop FM", "Pop");
      RadioStation JPROStation = new RadioStation("JPRO FM", "JPRO");

      AddRadioStation(RockStation);
      AddRadioStation(RapStation);
      AddRadioStation(PopStation);
      AddRadioStation(JPROStation);

    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Period	))
      {
        if(Car.gameObject.GetComponent<CarController>().enabled == true)
          {
            //Change Radio Station
            if(currentLine > 3)
              {
                currentLine = 0;
              }
            CurrentRadioStationText.text = "Current Station: " + radioStations[currentLine].stationName;
            //Play RadioStation
          //  radioStations[currentLine].playRadio(radio);
            currentLine++;
              //Check Audio
            if(radioStations[currentLine].genreType == "Rock")
            {
          //    PlayRockGenre(radio);
          Debug.Log("Rock");
            }
            else if(radioStations[currentLine].genreType == "Rap")
            {
        //      PlayRapGenre(radio);
          Debug.Log("Rap");
            }
            else if(radioStations[currentLine].genreType == "Pop")
            {
            Debug.Log("Pop");
            }
            else if(radioStations[currentLine].genreType == "JPRO")
            {
              int songCount = 0;
                radio.clip = JPROSongs[songCount];
                Debug.Log("JPRO");
                radio.Play();
                songCount++;

        }
      }
    }
  }
    public void AddRadioStation(RadioStation radioStation)
      {
        radioStations.Add(radioStation);
      }

}
