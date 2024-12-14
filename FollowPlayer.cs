using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float parallaxEffectMultiplier = 0.1f; // Multiplier for parallax effect
    private Vector3 offset = new Vector3(1.0f, 0, -5.0f);
    private Vector3 lastPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPlayerPosition = player.transform.position; // Initialize last player position
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Cameramovement();
    }

    void Cameramovement()
    {
        // Calculate the movement delta
        float deltaX = player.transform.position.x - lastPlayerPosition.x;

        // Apply the parallax effect
        Vector3 parallax = new Vector3(deltaX * parallaxEffectMultiplier, 0, 0);

        // Update camera position with parallax effect
        transform.position = player.transform.position + offset + parallax;

        // Update last player position
        lastPlayerPosition = player.transform.position;
    }
}