using UnityEngine.SceneManagement;
using UnityEngine;

public class GoToMenu : MonoBehaviour
{
    public void OpenMenu() {
        SceneManager.LoadScene("Game Menu");
    }
}
