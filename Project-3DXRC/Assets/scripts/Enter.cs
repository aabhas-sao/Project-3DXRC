using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter : MonoBehaviour
{
    private AudioManager audioManager;

    void Start() {
        GameObject.FindObjectOfType<AudioManager>().Play("ui");
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Return)) {
            SceneManager.LoadScene("Game Menu");
        }
    }
}
