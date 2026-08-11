using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class GameManeger : MonoBehaviour
{
    private float spwanRate = 1.2f;
    private int score = 0;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    public List<GameObject> targets;
    public bool isgameActive;
    public Button restartButton;
    public GameObject title;


    void Start()
    {
       
        
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTargets()
    {
        while (isgameActive)
        {
            yield return new WaitForSeconds(spwanRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
    
    }


   public  void UpdateScore(int scoretoAdd)
    {

        score += scoretoAdd;
        scoreText.text = "Score:" + score;

    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameoverText.gameObject.SetActive(true);
        isgameActive = false;


    }

    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }


    public void StartGame(int difficulty)
    {
        spwanRate /= difficulty;
        isgameActive = true;
        title.gameObject.SetActive(false);
        score = 0;
        StartCoroutine(SpawnTargets());
        UpdateScore(0);

    }
}
