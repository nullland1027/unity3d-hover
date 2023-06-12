using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // public GameObject player;
    // public float distance;
    // public float rotationDamping; 
    // public GameObject mainCam;
    

    public Transform target;
    public float distanceUp=5f;
    public float distanceAway = 20f;
    public float smooth = 20f;//位置平滑移动值
    public float camDepthSmooth = 50f;

    void Start()
    {
        // player = GameObject.Find("Player");
        // mainCam = GameObject.Find("Main Camera");
        // rotationDamping = 1;
        // Vector3 player_position = player.transform.position;
        // Vector3 cam_position = mainCam.transform.position;

        // distance = Mathf.Pow(Mathf.Pow(player_position[0] - cam_position[0], 2) 
        // + Mathf.Pow(player_position[1] - cam_position[1], 2)
        // + Mathf.Pow(player_position[2] - cam_position[2], 2), 0.5f);

        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // float wantedRotationAngle = player.transform.eulerAngles.y;
        // float currentRotationAngle = transform.eulerAngles.y;

        // currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // transform.position = player.transform.position;
        // transform.position -= currentRotation * Vector3.forward * distance;
        
        // Vector3 newPosition = new Vector3(transform.position.x, transform.position.z);
        // transform.position = newPosition;

        // transform.LookAt(player.transform);

        if ((Input.mouseScrollDelta.y < 0 && Camera.main.fieldOfView >= 3) || Input.mouseScrollDelta.y > 0 && Camera.main.fieldOfView <= 80)
        {
            Camera.main.fieldOfView += Input.mouseScrollDelta.y * camDepthSmooth * Time.deltaTime;
        }

    }
    void LateUpdate()
    {
       //相机的位置
        Vector3 disPos = target.position + Vector3.up * distanceUp - target.forward * distanceAway + new Vector3(0f, -10f, 0f);   
        transform.position=Vector3.Lerp(transform.position, disPos, Time.deltaTime*smooth);
        //相机的角度
        transform.LookAt(target.position);
    }
}
