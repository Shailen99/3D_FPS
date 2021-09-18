using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RadioStation
{
  public string stationName;
  public string genreType;

    // Start is called before the first frame update
    public RadioStation(string _stationName, string _genreType)
    {
      genreType = _genreType;
      stationName = _stationName;

    }
}
