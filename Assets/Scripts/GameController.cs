using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    
    public float spawnWait;
    public float startWait;
    public int enemyCount;
    public GameObject enemy;
    public Vector3 spawnValues;

    public Text scoreText;
    public int score;

    public Text endText;
    public bool gameEnded;
    void Start()
    {
        gameEnded = false;
        endText.gameObject.SetActive(false);
        scoreText.text = "Score: 0";
        StartCoroutine(SpawnWaves());
    }

    public void AddScore(int points) {
        score += points;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Scene level = SceneManager.GetActiveScene();
                SceneManager.LoadScene(level.name);
            }
        }
    }
    public void EndGame() {
        gameEnded = true;
        endText.gameObject.SetActive(true);
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while (true) {
            // for (int i = 0; i < enemyCount; i ++) {
                Vector3 spawnAt = new Vector3(
                    Random.Range(-spawnValues.x, spawnValues.x),
                    0.75f,
                    Random.Range(-spawnValues.z, spawnValues.z)
                );
                Instantiate<GameObject>(enemy, spawnAt, Quaternion.identity);

                yield return new WaitForSeconds(spawnWait);
            // }
        }
        
        
    }   
}
