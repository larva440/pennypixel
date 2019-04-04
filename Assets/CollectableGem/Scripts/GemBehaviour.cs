using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GemBehaviour : MonoBehaviour
{
	[Header("References")]
	public GameObject gemVisuals;
	public GameObject collectedParticleSystem;
	public CircleCollider2D gemCollider2D;

	private float durationOfCollectedParticleSystem;


	void Start()
	{
		durationOfCollectedParticleSystem = collectedParticleSystem.GetComponent<ParticleSystem>().main.duration;
        ScoreHolder.TotalGems++;

    }

    void OnTriggerEnter2D(Collider2D theCollider)
    {
        if (theCollider.CompareTag("Player"))
        {
            GemCollected();
            ScoreHolder.RestartPosition = this.transform.position;
            if (this.gameObject.CompareTag("Exit"))
            {
                Invoke("YouWin", durationOfCollectedParticleSystem);
            }
        }
    }


    void YouWin()
    {
        ScoreHolder.Message = $"You win this game!\nSecret passphrase: BUYBTCORREGRET\nGems collected {ScoreHolder.Score} / {ScoreHolder.TotalGems}";
        SceneManager.LoadScene(0);
    }


    void GemCollected()
	{
		gemCollider2D.enabled = false;
		gemVisuals.SetActive (false);
		collectedParticleSystem.SetActive (true);

        ScoreHolder.Score += 1;
		Invoke ("DeactivateGemGameObject", durationOfCollectedParticleSystem);

	}

	void DeactivateGemGameObject()
	{
		gameObject.SetActive (false);
	}
}
