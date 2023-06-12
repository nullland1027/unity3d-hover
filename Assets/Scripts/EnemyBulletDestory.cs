using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDestory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explosion;
    public GameController controller;
    void Start()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("GameController");
        controller = tmp.GetComponent<GameController>();
        if (controller == null) {
            Debug.LogError("Unabel to find");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Wall" || other.tag == "Enemy") {
            return;
        } 

            Destroy(other.gameObject);
            Destroy(this.gameObject);
            
            GameObject tmp = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
            Destroy(tmp, 1);
            controller.EndGame();
    }
}
