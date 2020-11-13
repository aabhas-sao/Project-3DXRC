using UnityEngine.SceneManagement;
using UnityEngine;

public class GoToCredits : MonoBehaviour
{
    public void OpenCredits() {
        SceneManager.LoadScene("Credits");

    }
}
