using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pause_ui, settings_ui, score_ui, game_over_ui, player;
    public bool alive;
    public int isPaused, explosions, multiplier;
    float timer, score;
    public Text score_live, score_end, explosion_count, total;

    void Start()
    {
        isPaused = 0;
        multiplier = 1;
        timer = 0f;
        pause_ui = GameObject.FindWithTag("pause_menu");
        settings_ui = GameObject.FindWithTag("settings_ui");
        score_ui = GameObject.FindWithTag("score_ui");
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(alive)
        {
            timer += Time.deltaTime * multiplier;
            score_ui.SetActive(true);
            score_live.text = (timer).ToString("0");
        }
        else
        {
            game_over_ui.SetActive(true);
            score_end.text = (timer).ToString("0");
            explosion_count.text = explosions.ToString("0");
            total.text = (timer + explosions).ToString("0");
        }
    }

    public void Pause()
    {
        if(isPaused==0 || isPaused==2)
        {
            settings_ui = GameObject.FindWithTag("settings_ui");
            Debug.Log("Paused (PauseMenu)");
            Time.timeScale = 0f;
            pause_ui.SetActive(true);
            score_ui.SetActive(false);
            settings_ui.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if(isPaused==1)
        {
            isPaused = 0;
            Debug.Log("Resumed");
            pause_ui.SetActive(false);
            score_ui.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Restart()
    {
        Debug.Log("Restarted");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Settings()
    {
        Debug.Log("Settings");
        settings_ui.SetActive(true);
        pause_ui.SetActive(false);
        isPaused=2;
    }

    public void MainMenu()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Debug.Log("Exit");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
