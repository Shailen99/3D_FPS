using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
  [Range(0.0f,1.0f)]
  public float time;
  public float fullDayLength;
  public float startTime = 0.4f;
  private float timeRate;

  public Vector3 Noon;


  [Header("Sun")]
  public Light Sun;
  public Gradient SunColor;
  public AnimationCurve sunIntensity;

  [Header("Moon")]
  public Light Moon;
  public Gradient MoonColor;
  public AnimationCurve moonIntensity;

  [Header("Other Lighting")]
  public AnimationCurve lightingIntensityMultiplier;
  public AnimationCurve reflectionIntensityMultiplier;

  void Start()
  {
    timeRate = 1.0f/ fullDayLength;
    time = startTime;
  }

  void Update()
  {

    //increment time
    time += timeRate * Time.deltaTime;

    if(time >= 1.0f)
    {
      time = 0.0f;
    }


    //light rotation
    Sun.transform.eulerAngles = (time - 0.25f) * Noon * 4.0f;
    Moon.transform.eulerAngles = (time - 0.75f) * Noon * 4.0f;

    //Lighting Intensity

    Sun.intensity = sunIntensity.Evaluate(time);
    Moon.intensity = moonIntensity.Evaluate(time);

    //change colors
    Sun.color = SunColor.Evaluate(time);
    Moon.color = MoonColor.Evaluate(time);


  }

}
