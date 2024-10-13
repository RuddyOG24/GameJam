using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private const int NUM_LEVELS = 2;  // Número de niveles

    public int level { get; private set; } = 0;
    public int lives { get; private set; } = 3;
    public int score { get; private set; } = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void NewGame()
    {
        lives = 3;
        score = 0;

        LoadLevel(1);
    }

    private void LoadLevel(int level)
    {
        this.level = level;

        if (level > NUM_LEVELS)
        {
            // Si completaste todos los niveles, ir a la escena "Lobby"
            SceneManager.LoadScene("Lobby");
            return;
        }

        Camera camera = Camera.main;

        // No renderiza nada mientras se carga la siguiente escena para crear
        // un efecto de transición simple entre escenas
        if (camera != null)
        {
            camera.cullingMask = 0;
        }

        Invoke(nameof(LoadScene), 1f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene($"Level{level}");
    }

    public void LevelComplete()
    {
        score += 1000;
        LoadLevel(level + 1);
    }

    public void LevelFailed()
    {
        lives--;

        if (lives <= 0)
        {
            // Si las vidas llegan a 0, ir a la escena "Lobby"
            SceneManager.LoadScene("Lobby");
        }
        else
        {
            LoadLevel(level);
        }
    }
}
