using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PaotaiController : MonoBehaviour
{
    public float fireRate;
    private float nextFire;
    public Transform enemySpawn;
    public GameObject shot;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, enemySpawn.position, enemySpawn.rotation);
        }
    }
}
