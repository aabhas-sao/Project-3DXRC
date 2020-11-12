using UnityEngine;
using UnityEngine.UI;


public class SetHighScore : MonoBehaviour
{
    public Text high_score, police_cars;
    public GameObject main_menu, high_score_ui;
    
    void Start() {
        SetScore();
    }

    void SetScore()
    {    
        high_score.text = PlayerPrefs.GetInt("TotalScore", 0).ToString();
        
        police_cars.text = PlayerPrefs.GetInt("PoliceCars", 0).ToString();
    }

    public void ShowHighScoreUI() {
        main_menu.SetActive(false);
        high_score_ui.SetActive(true);
    }

    public void Reset() {
        PlayerPrefs.DeleteAll();
        SetScore();
    }
}
