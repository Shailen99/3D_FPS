using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
  public Transform target;
  public GameObject bullet;
  public Transform bulletPoint;

  [Header("General")]

	public float range = 15f;

  [Header("Unity Setup Fields")]

	public string playerTag = "Player";

	public Transform partToRotate;
	public float turnSpeed = 10f;

  	[Header("Use Bullets (default)")]
  	public GameObject bulletPrefab;
  	public float fireRate = 1f;
  	private float fireCountdown = 0f;
    public Transform firePoint;

	//public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
      InvokeRepeating("UpdateTarget", 0f, 0.5f);

    }

  	void UpdateTarget ()
  	{
  		GameObject[] Players = GameObject.FindGameObjectsWithTag(playerTag);
  		float shortestDistance = Mathf.Infinity;
  		GameObject nearestPlayer = null;
  		foreach (GameObject player in Players)
  		{
  			float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
  			if (distanceToPlayer < shortestDistance)
  			{
  				shortestDistance = distanceToPlayer;
  				nearestPlayer = player;
  			}
  		}

  		if (nearestPlayer != null && shortestDistance <= range)
  		{
  			target = nearestPlayer.transform;
  		} else
  		{
  			target = null;
  		}

  	}

    // Update is called once per frame
    void Update()
    {
      if (target == null)
      {
        return;
      }

      if (fireCountdown <= 0f)
			{
				Shoot();
				fireCountdown = 1f / fireRate;
			}

			fireCountdown -= Time.deltaTime;
    }
    void Shoot()
    {
      Vector3 playerPos = new Vector3(target.position.x, target.position.y + 1, target.position.z);
      bulletPoint.rotation = Quaternion.LookRotation(playerPos);

      Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
      bullet.transform.position += bullet.transform.forward * fireRate * Time.deltaTime;
    }
    void LockOnTarget()
    {
      Vector3 dir = target.position - transform.position;
      Quaternion lookRotation = Quaternion.LookRotation(dir);
      Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
      partToRotate.rotation = Quaternion.Euler(-90f, rotation.y, -65.56f);

    }

    void OnDrawGizmosSelected ()
    	{
    		Gizmos.color = Color.red;
    		Gizmos.DrawWireSphere(transform.position, range);
    	}

}
