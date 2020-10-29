using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Return)) {
            SceneManager.LoadScene("Game Menu");
        }
    }
}
