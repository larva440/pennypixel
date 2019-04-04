using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START EXIT!!!!!!!!!!!!");
    }

    void OnTriggerEnter2D(Collider2D theCollider)
    {
        Debug.Log("ENTER EXIT!!!!!!!!!!!!");
        if (theCollider.CompareTag("Player"))
        {
            ScoreHolder.Message = $"You win this game!     Secret passphrase: BUYBTCORREGRET   Gems collected {ScoreHolder.Score} / {ScoreHolder.TotalGems}";
            SceneManager.LoadScene(0);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("ENTER EXIT!!!!!!!!!!!!");
        if (col.gameObject.CompareTag("Player"))
        {
            ScoreHolder.Message = $"You win this game!     Secret passphrase: BUYBTCORREGRET   Gems collected {ScoreHolder.Score} / {ScoreHolder.TotalGems}";
            SceneManager.LoadScene(0);
        }
    }

    // Destroy everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER EXIT!!!!!!!!!!!!");
        if (other.CompareTag("Player"))
        {
            ScoreHolder.Message = $"You win this game!     Secret passphrase: BUYBTCORREGRET   Gems collected {ScoreHolder.Score} / {ScoreHolder.TotalGems}";
            SceneManager.LoadScene(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
