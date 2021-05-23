using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

  public float mouseSensitivity = 300;
  public Transform PlayerBody;



  float xRotation = 0f;
    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
      float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
      float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;;



      //Look vertically
      xRotation -= mouseY;
      xRotation = Mathf.Clamp(xRotation,-90f, 90f);
      transform.localRotation = Quaternion.Euler(xRotation, 0f,0f);

      //Look horizontally
      PlayerBody.Rotate(Vector3.up * mouseX);
    }
}