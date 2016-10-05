using UnityEngine;
using System.Collections;

// This class is for projectile behaviors.
public class ProjectileController : MonoBehaviour
{
    // Speed of the projectile. Default value of 1 can be overwritten in Unity's inspector panel.
    public float speed = 1;
    public Spawner spawner;

    // Use this for initialization
    void Start()
    {
        // Rigidbody components control physics behaviors of objects.
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    // If the projectile collides with a target, destroy the target and projectile gameobjects
    // and spawn a new target to replace the one that was destroyed.
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Target")
        {
            Destroy(c.gameObject);
            Destroy(gameObject);
            spawner.SpawnTarget();
        }
    }
}
