using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public List<GameObject> targetList;
    float spawnRate = 1f;

    public GameObject[] panels;
    public Text scoreText;
    int score;
    public Text lifeText;
    public int life;
    public bool gameOver;
    public bool gameISActive;
    public GameObject nextWaveNotif;
    public Text nextWaveNotifIndex;
    public bool spawnEnemiesNow=false;
    public GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        life = 5;
        ActivePanel(0);
        gameISActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckLifeValidity();
    }
    public void NotifyNextWave(int waveIndex)
    {
        nextWaveNotifIndex.text = "Wave " + waveIndex ;
        nextWaveNotif.SetActive(true);
        Invoke(nameof(NextWaveNotifClose), 3f);
    }
    public void NextWaveNotifClose()
    {
        spawnEnemiesNow = true;
        nextWaveNotif.SetActive(false);
    }
    public void SetSpawnEnemynabler(bool spawnEnemiesNow)
    {
        this.spawnEnemiesNow = spawnEnemiesNow;
    }

    public void ActivePanel(int panelIndex)
    {
        DeavtivePanels();
        panels[panelIndex].SetActive(true);
    }
    void DeavtivePanels()
    {
        foreach (GameObject panel in panels)
            panel.SetActive(false);
    }
    private void CheckLifeValidity()
    {
        if (life <= 0)
            GameOver();
    }
    public void GameOver()
    {
        gameOver = true;
        ActivePanel(4);
        Time.timeScale = 0;
    }

    //public int GetLife()
    //{
    //    return life;
    //}

     void UpdateScore(int scoreToUpdate)
    {
        scoreText.text = "Score:" + score.ToString();
    }
    public void IncreaseScore()
    {
        score++;
        UpdateScore(score);
    }
    public void DecreaseScore()
    {
        score--;
        UpdateScore(score);
    }
    public void DecreaseLife()
    {
        life--;
        UpdateLife(life);
    }
    void UpdateLife(int lifeToUpdate)
    {
        //score += scoreToUpdate;
        lifeText.text = "Life:" + life.ToString();
    }

    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void StartGame(int difficulty)
    {
        gameOver = false;
        gameISActive = true;
        spawnRate /= difficulty;
        ActivePanel(3);
       // StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLife(life);
    }
}
