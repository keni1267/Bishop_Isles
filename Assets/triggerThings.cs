using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerThings : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera mainCamera;
    private bool isCameraFrozen = false;
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        
    }
    public BoxCollider2D enter;

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            enter.isTrigger = false;
            //CameraFollow fs  = mainCamera.GetComponent<CameraFollow>();
            //fs.enabled = false;


        }


    }
    private void FreezeCamera()
    {
        if (mainCamera != null && !isCameraFrozen)
        {
            // Store the current position and rotation of the camera
            Vector3 originalPosition = mainCamera.transform.position;
            Quaternion originalRotation = mainCamera.transform.rotation;
            mainCamera.transform.position = originalPosition;

            // Update the flag to indicate that the camera is frozen
            isCameraFrozen = true;

            // Optional: You can also disable other components like CameraMovement scripts
            // mainCamera.GetComponent<YourCameraMovementScript>().enabled = false;

            // Print a message to the console
            Debug.Log("Main Camera frozen.");

            // You can also perform additional actions here if needed

            // To unfreeze the camera, you can use a similar approach and reset the position and rotation
            // mainCamera.transform.position = originalPosition;
            // mainCamera.transform.rotation = originalRotation;
        }
    }
}
