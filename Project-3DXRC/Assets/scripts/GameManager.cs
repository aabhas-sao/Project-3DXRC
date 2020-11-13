using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameManager singleton
    static GameManager instance;
    
    [SerializeField]private GameObject pause_ui, score_ui, game_over_ui, player;
    
    public static bool alive = true; // check if player is alive
    public int isPaused = 1, explosions =0, multiplier = 10, multiplierPowerUp = 1, per_car_multiplier=5;
    float timer, score, final_score;
    int final_score_int;
    public Text score_live, score_end, explosion_count, total, game_over_explosion;
    [SerializeField]private EnemyCollision enemyCollision;

    public bool isInvincible = false; // checking if invincible powerup is active
    public float powerupActiveTime = 10f; // for how longer powerups is in effect

    public float currentEnemyMotorForce = -2000f;
    public float defaultEnemyMotorForce = -2000f;

    private AudioManager audioManager;
    
    public float powerupCooldown = 30f; // after how much time a new powerup should be spawned
    [SerializeField] private float currentPowerupCooldown;
    private SpawnPowerUp spawnPowerUp;
     
    void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        // set ref for pause_ui, score_ui, game_over_ui
        pause_ui = GameObject.FindWithTag("pause_ui");
        score_ui = GameObject.FindWithTag("score_ui");
        game_over_ui = GameObject.FindWithTag("game_over_ui");

        enemyCollision = GameObject.FindObjectOfType<EnemyCollision>();
        audioManager = (AudioManager)FindObjectOfType(typeof(AudioManager));
        audioManager.StopPlaying("ui");
        audioManager.Play("game");

        spawnPowerUp = GameObject.FindObjectOfType<SpawnPowerUp>();
    }

    void Start()
    {
        currentEnemyMotorForce = defaultEnemyMotorForce;
        currentPowerupCooldown = powerupCooldown;
        // DontDestroyOnLoad(gameObject);
        Time.timeScale = 1f;
        isPaused = 0;
        timer = 0f;
        explosion_count.text = "0";
        game_over_explosion.text ="0";

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
            
            currentPowerupCooldown -= Time.deltaTime;

            if(currentPowerupCooldown <= 0) {
                spawnPowerUp.PowerUpPos(); // spawn a powerup after cooldown
                currentPowerupCooldown = powerupCooldown;
            }
        }
        // when player loses
        else
        {
            audioManager.StopPlaying("game");
            audioManager.StopPlaying("engineCut");
            audioManager.StopPlaying("tireSqueal");
            Time.timeScale = 0f;
            game_over_ui.SetActive(true);
            score_ui.SetActive(false);  
            score_end.text = (timer).ToString("0");
            game_over_explosion.text = explosions.ToString("0");
            final_score = timer + explosions * per_car_multiplier;
            total.text = (final_score).ToString("0");
            final_score_int = (int) final_score;
            
            // if score greater than highscore set highscore
            if(explosions > PlayerPrefs.GetInt("PoliceCars", 0)) {
                PlayerPrefs.SetInt("PoliceCars", explosions);
            }
            if(final_score_int > PlayerPrefs.GetInt("TotalScore", 0)) {
                PlayerPrefs.SetInt("TotalScore", final_score_int);
            }
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
            // AudioListener.pause = true;
            audioManager.StopPlaying("game");
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
            // AudioListener.pause = false;
            audioManager.Play("game");
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
        // if(AudioListener.pause) {
        //     AudioListener.pause = false;
        // }
        audioManager.StopPlaying("game");
        audioManager.Play("ui");
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
