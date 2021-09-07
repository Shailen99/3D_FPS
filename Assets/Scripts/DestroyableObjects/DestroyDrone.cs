using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDrone : MonoBehaviour
{
  public GameObject Drone;
  public ParticleSystem Drone_Explosion;
  public AudioSource DroneExplosionSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void BlowUpDrone()
    {
      Drone.SetActive(false);
      Drone_Explosion.Play();
    //  Debug.Log(DroneExplosionSound.clip);
      DroneExplosionSound.Play(0);
    }
}
