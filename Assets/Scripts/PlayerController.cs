using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{
    public float turnSpeed;
    public float speed;
    public Boundary boundary;

    //shot
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;


    void Start()
    {
        // turnSpeed = 0.3f;
        // speed = 20.0f;

        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // turning
        if (moveHorizontal != 0) {
            transform.Rotate(new Vector3(0.0f, moveHorizontal * turnSpeed, 0.0f));
        }

        // forward & backward
        if (moveVertical != 0) {
            Vector3 fwd = transform.forward;
            GetComponent<Rigidbody>().velocity = fwd * speed * moveVertical;
        }

        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            3.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        
        if (Input.GetKey("space") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    
}
