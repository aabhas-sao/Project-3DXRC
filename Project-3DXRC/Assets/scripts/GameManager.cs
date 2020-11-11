using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private GameObject pause_ui, score_ui, game_over_ui, player;
    [SerializeField] private GameObject settings_ui;
    public static bool alive = true;
    public int isPaused = 1, explosions =0, multiplier = 10, multiplierPowerUp = 1, per_car_multiplier=5;
    float timer, score;
    public Text score_live, score_end, explosion_count, total, game_over_explosion;
    static GameManager instance;
    [SerializeField]private EnemyCollision enemyCollision;

    public bool isInvincible = false; // checking if invincible powerup is active
    public float powerupActiveTime = 10f; // for how longer powerups is in effect

    public float currentEnemyMotorForce = -2000f;
    public float defaultEnemyMotorForce = -2000f;

    void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }
        enemyCollision = GameObject.FindObjectOfType<EnemyCollision>();
    }

    void Start()
    {
        currentEnemyMotorForce = defaultEnemyMotorForce;
        // DontDestroyOnLoad(gameObject);
        Time.timeScale = 1f;
        isPaused = 0;
        timer = 0f;
        explosion_count.text = "0";
        game_over_explosion.text ="0";
        
        // settings_ui = GameObject.FindWithTag("settings_ui");

        score_ui.SetActive(true);
        game_over_ui.SetActive(false);
        pause_ui.SetActive(false);
        
        alive = true;
    }

    void Update()
    {
        if(alive)
        {
            if(Input.GetKeyDown(KeyCode.Escape)) {
                Pause();
            }

            timer += Time.deltaTime * multiplier * multiplierPowerUp;
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

    // toggles the pause ui
    public void Pause()
    {
        if(isPaused==0 || isPaused==2)
        {
            // settings_ui = GameObject.FindWithTag("settings_ui");
            Debug.Log("Paused (PauseMenu)");
            score_ui.SetActive(false);
            isPaused = 1;
            Time.timeScale = 0f;
            pause_ui.SetActive(true);
            // settings_ui.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if(isPaused==1)
        {
            Time.timeScale = 1f;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        game_over_ui.SetActive(false);
    }

    // public void Settings()
    // {
    //     Debug.Log("Settings");
    //     settings_ui.SetActive(true);
    //     pause_ui.SetActive(false);
    //     isPaused=2;
    // }

    public void MainMenu()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadScene("Game Menu");
    }
    
    public void PlayGame() {
        SceneManager.LoadScene("City");
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
