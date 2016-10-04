using UnityEngine;
using System.Collections;

// This class is for projectile behaviors.
public class ProjectileController : MonoBehaviour {
    // Speed of the projectile. Default value of 1 can be overwritten in Unity's inspector panel.
    public float speed = 1;

	// Use this for initialization
	void Start () {
        // Rigidbody components control physics behaviors of objects.
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
