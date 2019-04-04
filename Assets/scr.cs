using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scr : MonoBehaviour
{
    public Text msg;

    // Start is called before the first frame update
    void Start()
    {
        if (ScoreHolder.Message != null)
        {
            msg.text = ScoreHolder.Message;

        }
        else msg.text = "...";
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0 || Input.GetButtonDown("Jump"))
        {
            ScoreHolder.Lives = 3;
            ScoreHolder.Score = 0;
            ScoreHolder.TotalGems = 0;

            Debug.Log("GO!");
            SceneManager.LoadScene(1);

        }
    }
}
