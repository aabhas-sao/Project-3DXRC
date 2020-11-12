using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayHover()
    {
        FindObjectOfType<AudioManager>().Play("hoverSFX");
        Debug.Log("hover");
    }
}
