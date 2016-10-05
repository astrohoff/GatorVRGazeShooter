using UnityEngine;
using System.Collections;

// This class is for player behaviors. 
public class PlayerController : MonoBehaviour
{
    public GvrViewer gvrViewer;
    public GameObject projectilePrefab;
    public Spawner spawner;

    // Use this for initialization.

    // Update is called once per frame.
    void Update()
    {
        // If the Cardboard trigger is pressed (also if screen is touched, and simulated by mouse click in Unity editor),
        // spawn a new projectile at the camera's position.
        // Projectile is also given the camera's rotation so that it can just move forward once it has been created.
        if(gvrViewer.Triggered)
        {
            spawner.SpawnProjectile(transform.position, transform.rotation);
        }
    }
}
