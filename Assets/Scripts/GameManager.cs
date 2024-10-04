using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText; 
    public GameObject titleScreen;
    public bool isGameActive;
    public Button restartButton;
    private int spawnRate = 3;
    private int score;
    // Start is called before the first frame update
    void Start()
    {   

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTargets(){

        while(isGameActive){

            int index = Random.Range(0, targets.Count);
            //UpdateScore(5);
            Instantiate(targets[index]);
            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void UpdateScore(int scoreToAdd){

        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver(){
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty){
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        StartCoroutine(SpawnTargets());
    }
}
