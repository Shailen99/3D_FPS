using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{

  public int Damage = 10;
  public float Range = 100f;
  public float fireRate = 15f;
  public Camera fpsCamera;
//  public GameObject MuzzleFlashActivate;
  public ParticleSystem MuzzleFlash;

  private float timeToFire = 0.2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetButtonDown("Fire1") && Time.time >= timeToFire)
      {
        timeToFire = Time.time + 1f/timeToFire;
        Shoot();
      }
    }


    void Shoot()
    {

      RaycastHit hit;
      MuzzleFlash.Play();
        if( Physics.Raycast(fpsCamera.transform.position,fpsCamera.transform.forward, out hit, Range))
        {
          EnemyHealthManager target = hit.transform.GetComponent<EnemyHealthManager>();
          if(target != null)
          {
            target.HurtEnemy(Damage);
          }
        }
    }
}
