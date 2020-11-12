using UnityEngine;
using UnityEngine.UI;

public class powerupUI : MonoBehaviour
{
    public float totalTime = 10;
    public float currentTime;
    public Image powerUPCircle;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        totalTime = gameManager.powerupActiveTime;
        currentTime = totalTime;        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime > 0) {
            currentTime -= Time.deltaTime;
        }
        CircleFiller();
        ColorChanger();
    }

    void CircleFiller() {
        powerUPCircle.fillAmount = currentTime/totalTime;
    }

    void ColorChanger() {
        powerUPCircle.color = Color.Lerp(Color.red, Color.green, currentTime/totalTime);
    }

}
