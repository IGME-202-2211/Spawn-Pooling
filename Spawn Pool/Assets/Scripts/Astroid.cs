using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    #region Movement Vectors
    Vector3 vehiclePosition;
    Vector3 direction = Vector3.right;
    Vector3 velocity = Vector3.zero;
    #endregion

    #region Movement properties
    [SerializeField]
    float maxSpeed = 10f;
    [SerializeField]
    float minSpeed = 5f;
    [SerializeField]
    float speed;
    #endregion

    #region Screen wrapping variables
    Vector3 cameraPosition;
    Vector2 halfCameraSize = Vector2.zero;
    #endregion

    public AstroidSpawnManager manager;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = Camera.main.transform.position;

        //  Calcuale the half size of the Camera
        halfCameraSize.y = Camera.main.orthographicSize;
        halfCameraSize.x = halfCameraSize.y * Camera.main.aspect;
    }

    private void OnEnable()
    {
        //  Set the starting vehicle position to the current position of the GameObject
        vehiclePosition = transform.position;

        //  Set a new random speed
        speed = Random.Range(minSpeed, maxSpeed);

        //  Set a new random direction
        direction = Random.insideUnitCircle;
        direction.Normalize();

        //  Calculate the velocity of this astroid
        velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Add a scaled velocity to position
        vehiclePosition += velocity * Time.deltaTime;

        //  Check to make sure the Vehicle is still on the screen
        if(CheckIfOffScreen())
        {
            manager.ReturnAstroid(this);
        }
        else
        {
            // Draw the vehicle at that position
            transform.position = vehiclePosition;

            // Set the vehicle’s rotation to match the direction
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
    }

    /// <summary>
    /// Check if the GameObject has gone off the screen.
    /// </summary>
    /// <returns>A bool of if it is off the screen</returns>
    bool CheckIfOffScreen()
    {
        if (vehiclePosition.x > cameraPosition.x + halfCameraSize.x ||
            vehiclePosition.x < cameraPosition.x - halfCameraSize.x ||
            vehiclePosition.y > cameraPosition.y + halfCameraSize.y ||
            vehiclePosition.y < cameraPosition.y - halfCameraSize.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
