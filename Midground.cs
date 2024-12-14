using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidgroundLayer : MonoBehaviour
{
    public float parallaxEffectMultiplier; // Set this in the Inspector for each layer
    private Vector3 lastCameraPosition;

    void Start()
    {
        // Initialize lastCameraPosition with the camera's initial position
        lastCameraPosition = Camera.main.transform.position;
    }

    void Update()
    {
        // Calculate the camera's movement
        Vector3 cameraMovement = Camera.main.transform.position - lastCameraPosition;

        // Apply the parallax effect
        Vector3 newPosition = transform.position + new Vector3(cameraMovement.x * parallaxEffectMultiplier, 0, 0);

        // Update the position of the midground layer
        transform.position = newPosition;

        // Update lastCameraPosition
        lastCameraPosition = Camera.main.transform.position;
    }
}