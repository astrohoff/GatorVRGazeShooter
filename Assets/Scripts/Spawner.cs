using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public int targetCount = 3;
    public GameObject projectilePrefab;
    public float targetMinDistance = 2;
    public float targetMaxDistance = 7;
    public GameObject scorePanelPrefab;
    public ScoreController scoreCtrl;

    // Use this for initialization
    void Start()
    {
        // Spawn inital targets.
        for(int i = 0; i < targetCount; i++)
        {
            SpawnTarget();
        }
    }
    // Spawn a new target.
    public void SpawnTarget()
    {
        // Spawn the target at a random position.
        Vector3 spawnPosition = GetRandomPosition();
        GameObject target = (GameObject)Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
        // Point it at the origin.
        target.transform.up = Vector3.zero - spawnPosition;
    }
    // Get a random position for the target to spawn at.
    // Position can be in any direction from the origin, but is contrained to the range of distances
    // specified by minDistance and maxDistance.
    Vector3 GetRandomPosition()
    {
        Vector3 spherePosition = Random.onUnitSphere;
        float distance = Random.Range(targetMinDistance, targetMaxDistance);
        return spherePosition * distance;
    }
    // Spawn a new projectile at the specified position with the specified rotation.
    public void SpawnProjectile(Vector3 position, Quaternion rotation)
    {
        GameObject projectile = (GameObject)Instantiate(projectilePrefab, position, rotation);
        ProjectileController projectileCtrl = projectile.GetComponent<ProjectileController>();
        // Set the projectile's reference to this script.
        projectileCtrl.spawner = this;
        // Set the projectile's reference to the score controller.
        projectileCtrl.scoreCtrl = scoreCtrl;
    }
    public void SpawnScorePanel(Vector3 position, Quaternion rotation)
    {
        GameObject scorePanel = (GameObject)Instantiate(scorePanelPrefab, position, rotation);
        ScorePanelController scorePanelCtrl = scorePanel.GetComponent<ScorePanelController>();
        scorePanelCtrl.scoreCtrl = scoreCtrl;
        scorePanelCtrl.Initialize();
    }
}
