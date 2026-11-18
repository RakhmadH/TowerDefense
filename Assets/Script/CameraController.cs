using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class CameraController : MonoBehaviour
{
    private bool doMovement = true;
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    public float minX = 0f;
    public float maxX = 60f;

    public float minZ = -90f;
    public float maxZ = -10f;

    private Vector3 cameraMovement = new Vector3(0, 0, 0);



    private Vector2 moveInput;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        //Camera Move Using Keyboard (WASD Style)
        if (!doMovement)
            return;
        
        cameraMovement = new Vector3(moveInput.x, 0f, moveInput.y);
       
    }

    public void OnDoMove(InputValue value) 
    {
        doMovement = !doMovement;
    }

    //Zoom In / Out The Camera
    public void OnZoom(InputValue value)
    {
        if (!doMovement)
            return;
        float zoomAmount = value.Get<float>();
        //Debug.Log(zoomAmount);
        Vector3 position = transform.position;
        position.y -= zoomAmount * scrollSpeed * 100f * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;
    }

    void Update()
    {

        
        if (!doMovement)
            return;

        //Camera Movement Using Mouse
        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        {

            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);

        }

        if ( Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if ( Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if ( Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

   

        //Calculate the new position based on the movement vector, pan speed, and delta time
        Vector3 finalCamPosition = transform.position + (cameraMovement * panSpeed * Time.deltaTime);

        //Clamp the camera movement position within the defined boundaries
        finalCamPosition.x = Mathf.Clamp(finalCamPosition.x, minX, maxX);
        finalCamPosition.z = Mathf.Clamp(finalCamPosition.z, minZ, maxZ);

        Debug.Log(finalCamPosition);


        //Apply the clamped camera movement position to the camera's transform
        transform.position = finalCamPosition;




    }
}
