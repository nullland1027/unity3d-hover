using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{   
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //AxisLookAt(transform, new Vector3(90, 0, 0), new Vector3(0, 0, 0));
        transform.LookAt(player.transform);
    }
}
