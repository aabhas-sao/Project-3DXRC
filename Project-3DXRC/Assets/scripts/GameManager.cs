using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pause_ui, settings_ui, score_ui, game_over_ui, player;
    public static bool alive = true;
    public int isPaused, explosions =0, multiplier = 10, multiplierPowerUp = 1, per_car_multiplier=5;
    float timer, score;
    public Text score_live, score_end, explosion_count, total, game_over_explosion;
    static GameManager instance;
    [SerializeField]private EnemyCollision enemyCollision;

    void Awake() {
        enemyCollision = GameObject.FindObjectOfType<EnemyCollision>();
    }

    void Start()
    {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }
        
        // DontDestroyOnLoad(gameObject);
        Time.timeScale = 1f;
        isPaused = 0;
        timer = 0f;
        explosion_count.text = "0";
        game_over_explosion.text ="0";
        // pause_ui = GameObject.FindWithTag("pause_menu");
        // settings_ui = GameObject.FindWithTag("settings_ui");
        game_over_ui = GameObject.FindWithTag("game_over_ui");
        game_over_ui.SetActive(false);
        score_ui = GameObject.FindWithTag("score_ui");
        player = GameObject.FindWithTag("player");
        alive = true;
        Debug.Log("alive ko true toh kiya tha");
    }

    void Update()
    {
        if(alive)
        {
            timer += Time.deltaTime * multiplier * multiplierPowerUp;
            score_ui.SetActive(true);
            score_live.text = (timer).ToString("0");
        }
        else
        {
            Time.timeScale = 0f;
            game_over_ui.SetActive(true);
            score_ui.SetActive(false);  
            score_end.text = (timer).ToString("0");
            game_over_explosion.text = explosions.ToString("0");
            total.text = (timer + explosions * per_car_multiplier).ToString("0");
        }
    }

    public void ExplosionCount() {
        explosion_count.text = explosions.ToString();
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
        SceneManager.LoadScene("City");
        game_over_ui.SetActive(false);
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
        SceneManager.LoadScene("Game Menu");
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
