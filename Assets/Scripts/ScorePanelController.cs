using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScorePanelController : MonoBehaviour {
    public ScoreController scoreCtrl;
    public float displayTime;
    public Text scoreText;

    public void Initialize()
    {
        transform.LookAt(Vector3.zero);
        scoreText.text = scoreCtrl.GetScore().ToString();
        StartCoroutine(DelayedDestroy());
    }
    // Waits for a period of time before destroying the score panel.
    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(displayTime);
        Destroy(gameObject);
    }
}
