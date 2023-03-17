using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    public static int score;
    static ScoreKeeper instance;

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            var player = FindObjectOfType<CharacterController>();
            if (player != null)
            {
                var startPoint = Vector3.zero;
                UpdateScore(player, startPoint);
            }
        }
        else if (scene.buildIndex == 0)
        {
            var scoreTextObject = GameObject.Find("ScoreText");
            if (scoreTextObject != null)
            {
                var scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
                scoreText.text = "Score: " + score.ToString();
            }
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            var player = FindObjectOfType<CharacterController>();
            if (player != null)
            {
                var startPoint =Vector3.zero;
                UpdateScore(player, startPoint);
            }
        }
    }

    void UpdateScore(CharacterController player, Vector3 startPoint)
    {
        if (Mathf.Abs(player.GetPlayerPos().y - startPoint.y) > 5f)
        {
            score = Convert.ToInt32(Mathf.Abs(player.GetPlayerPos().y - startPoint.y)) * 5;
            var scoreText = FindObjectOfType<TextMeshProUGUI>();
            if (scoreText != null) // added check for null
            {
                scoreText.text = "Score: " + score.ToString();
            }
        }
    }
}
