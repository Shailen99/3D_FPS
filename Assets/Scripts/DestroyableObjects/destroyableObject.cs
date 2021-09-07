using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyableObject : MonoBehaviour
{
  public GameObject originalObject;
  public GameObject fracture;
  public GameObject objectToDeactivate;
  public float breakForce;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void destroyTheObject()
    {
      GameObject fracturedObject = Instantiate(fracture,transform.position,transform.rotation);

      foreach(Rigidbody rb in fracturedObject.GetComponentsInChildren<Rigidbody>())
      {
        Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
        rb.AddForce(force);
      }
      originalObject.SetActive(false);
      StartCoroutine(WaitToSetFalse(fracturedObject));
    }

    IEnumerator WaitToSetFalse(GameObject fracturedObjectToDeactivate)
    {
     //yield on a new YieldInstruction that waits for 5 seconds.
     yield return new WaitForSeconds(2);
     objectToDeactivate.SetActive(false);
     fracturedObjectToDeactivate.SetActive(false);

     }
}
