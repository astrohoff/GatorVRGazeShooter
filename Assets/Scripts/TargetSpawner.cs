using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour {
    public GameObject targetPrefab;
    float minDistance = 2;
    float maxDistance = 7;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // Use cardboard trigger pull to test target spawning for now.
        if (GvrViewer.Instance.Triggered)
        {
            SpawnTarget();
        }
	}
    // Spawn a new target.
    public void SpawnTarget() {
        // Spawn the target at a random position.
        Vector3 spawnPosition = GetRandomPosition();
        GameObject target = (GameObject)Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
        // Point it at the origin.
        target.transform.up = Vector3.zero - spawnPosition;
    }
    Vector3 GetRandomPosition()
    {
        Vector3 spherePosition = Random.onUnitSphere;
        float distance = Random.Range(minDistance, maxDistance);
        return spherePosition * distance;
    }
}
