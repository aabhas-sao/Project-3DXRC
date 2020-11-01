using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTerrain : MonoBehaviour
{
    public void OpenTerrain() {
        SceneManager.LoadScene("Terrains");
    }
}
