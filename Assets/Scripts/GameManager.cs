using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject startMenu;
    private int score = 0;
    public bool isGameActive { get; private set; }
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance!=null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 0f;
        isGameActive = false;
        startMenu.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        isGameActive = true;
        startMenu.SetActive(false);
        scoreText.gameObject.SetActive(true);
        score = 0;
        UpdateScore();
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScore();
    }
    public void GameOver()
    {
        isGameActive = false;
        Time.timeScale = 0f;
        startMenu.SetActive(true);
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

}
