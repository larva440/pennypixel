using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0 || Input.GetButtonDown("Jump"))
        {
            Debug.Log("GO!");

        }
    }
}
