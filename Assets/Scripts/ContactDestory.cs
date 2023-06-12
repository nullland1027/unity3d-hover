using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestory : MonoBehaviour
{   
    public GameObject explosion;
    public static ContactDestory instance;
    private GameController controller;
    
    // private void Awake() {
    //     if (instance == null)
    //         instance = this;
    //     else
    //     {
    //         Destroy(this);
    //     }
    // }

    // Start is called before the first frame update
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

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("EnemyBullet") || other.tag == "Wall") {
            return;
        }
        if (other.CompareTag("Player")) {
            GameObject tmp = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(tmp, 1);
            controller.EndGame();
        }
        if (other.CompareTag("Bullet")) {
            GameObject tmp = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
            Destroy(gameObject);
            Destroy(tmp, 1);
            controller.AddScore(10);
        }
        
        
        
    }
}
