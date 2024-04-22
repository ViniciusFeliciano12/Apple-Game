using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public int totalScore;
    public int maxScore;
    public Text scoreText;
    public Text scoreAlcançado;
    public static GameController instance;
    public GameObject gameOver;
    public GameObject nextLevel;
    public GameObject nextLevelImage;
    public GameObject pauseScreen;
    private bool jogoPausado = false;


    void Start()
    {
        instance = this;
    }

    void Update(){
        PauseGame();
    }

    void PauseGame(){
        if (Input.GetKeyDown(KeyCode.Escape) 
            && SceneManager.GetActiveScene().name != "menu"
            && !gameOver.activeInHierarchy)
            {
                if (jogoPausado)
                {
                    ContinuarJogo();
                }
                else
                {
                    PausarJogo();
                }
            }
    }

    public void UpdateScoreText(int score){
        totalScore += score;
        if (totalScore == maxScore){
            nextLevelImage.SetActive(true);
        }
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
        ContinuarJogo();
    }

    public void ShowNextLevel(){
        nextLevel.SetActive(true);
        scoreAlcançado.text += scoreText.text;
    }

    void PausarJogo()
    {
        Time.timeScale = 0f;
        jogoPausado = true;
        pauseScreen.SetActive(true);
    }
    void ContinuarJogo()
    {
        Time.timeScale = 1f; 
        jogoPausado = false;
        pauseScreen.SetActive(false);
    }

    public void FecharJogo(){
        Application.Quit();
    }
}
