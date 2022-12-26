using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcInputSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<PlayerControl>().Move(Input.GetAxis("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<PlayerControl>().Jump();
        }
        if(Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<PlayerControl>().Attack();
        }
    }
}   
