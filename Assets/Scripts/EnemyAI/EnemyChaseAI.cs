using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseAI : MonoBehaviour
{
  public Transform target;
  public float speed = 4f;
  Rigidbody rigBody;

    // Update is called once per frame
    void Update()
    {
      Vector3 localPosition = target.position - transform.position;
        localPosition = localPosition.normalized; // The normalized direction in LOCAL space
        transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y, localPosition.z * Time.deltaTime * speed);
      //  transform.LookAt(target);
    }


}
