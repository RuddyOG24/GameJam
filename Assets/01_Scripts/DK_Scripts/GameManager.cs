using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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
        // Aquí podrías inicializar cualquier cosa si es necesario
    }

    public void NewGame()
    {
        lives = 3;
        score = 0;

        LoadLevel();
    }

    private void LoadLevel()
    {
        // Cargar el único nivel disponible
        SceneManager.LoadScene("DonkeyKong"); // Asegúrate de que el nombre de tu nivel sea "Level1"
    }

    public void LevelComplete()
    {
        score += 1000;
        LoadLobby();
    }

    public void LevelFailed()
    {
        lives--;

        if (lives <= 0)
        {
            LoadLobby();
        }
        else
        {
            LoadLevel(); // Reinicia el nivel actual
        }
    }

    private void LoadLobby()
    {
        SceneManager.LoadScene("Lobby"); // Asegúrate de que el nombre de tu lobby sea "Lobby"
    }
}
