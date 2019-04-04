using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Text Score;

    public PlayerPlatformerController controller;

    public float runSpeed = 1f;
    public float sensitivity = 1000f;

    float hMove = 0f;
    bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        ScoreHolder.RestartPosition =  this.transform.position;
    }


    bool left = false;
    bool right = false;
    bool up = false;

    bool lt = false;
    bool rt = false;

   
    public static string dbg = "";

    public static bool IsDoubleTap()
    {
        bool result = false;
        float MaxTimeWait = 1;
        float VariancePosition = 1;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float DeltaTime = Input.GetTouch(0).deltaTime;
            float DeltaPositionLenght = Input.GetTouch(0).deltaPosition.magnitude;

            if ((DeltaTime > 0.003) && (DeltaTime < MaxTimeWait) && (DeltaPositionLenght < VariancePosition))
            {
         //       dbg = $"DeltaPositionLenght {DeltaPositionLenght} variance {VariancePosition} dtime {DeltaTime}";
                result = true;
            }
            else dbg = "";
        }
        return result;
    }

    bool dbltap = false;
    float lt_lasttime = 0;
    float rt_lasttime = 0;
    bool dt = false;
    void Update()
    {
        jump = false;
        hMove = 0;
        
        var nlt = Input.touches.Any(t => t.position.x < Screen.width / 2 && t.phase < TouchPhase.Ended);
        var nrt = Input.touches.Any(t => t.position.x > Screen.width / 2 && t.phase < TouchPhase.Ended);

        dt = false;
        float dblckltime = 0.5f;

        if (nlt != lt)
        {
            lt = nlt;
            if (lt && Time.fixedTime - lt_lasttime < dblckltime) dt = true;
        }

        if (nrt != rt)
        {
            rt = nrt;
            if (rt && Time.fixedTime - rt_lasttime < dblckltime) dt = true;
        }

        if (lt) lt_lasttime = Time.fixedTime;
        if (rt) rt_lasttime = Time.fixedTime;


        if (dt)
        {
        //    hMove = 0;
            dbltap = true;
            jump = true;
        }

        Score.text = $"Gems {ScoreHolder.Score} / {ScoreHolder.TotalGems}  Lives: {ScoreHolder.Lives}";
  //      Debug.Log($" {lt_lasttime} {rt_lasttime}  {dbg}   leftTouch: {lt}   rightTouch: {rt}   doubleTouch: {dt}   LEFT: {left}    RIGHT: {right}    dbl {dbltap}");

        if (lt || rt || dt)
        {

            if (lt && (!(left || right)))
                left = true;

            if (rt && (!(left || right)))
                right = true;

            if (left)
            {
                up = rt;
            };

            if (right)
            {
                up = lt;
            };

            if (left) hMove = -runSpeed;
            if (right) hMove = runSpeed;



            //  if (dbltap) hMove = 0;
            if (up || dbltap) jump = true;
        }
        else
        {
        //    Debug.Log($"NO TOUCH!");
            left = false;
            right = false;
            up = false;
            dbltap = false;
        }
        controller.key_Jump = jump;
        controller.key_hMove = Mathf.MoveTowards(controller.key_hMove, hMove, sensitivity * Time.deltaTime);
       // Debug.Log(sensitivity * Time.deltaTime+ " " +sensitivity);
        //       hMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        if (this.transform.position.y < -15)
        {
            if (ScoreHolder.Lives > 0)
            {
                ScoreHolder.Lives--;
                this.transform.position = ScoreHolder.RestartPosition;
            } else
            {
                ScoreHolder.Message = $"You are lost! Gems collected {ScoreHolder.Score} / {ScoreHolder.TotalGems}";
                SceneManager.LoadScene(0);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      //  Debug.Log("move: " + dbltap + " jump: " +jump);
     //   controller.Move(hMove*Time.fixedDeltaTime, false, jump);
    }
}
