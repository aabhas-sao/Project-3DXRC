using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowCursor : MonoBehaviour
{
    private TrailRenderer trail;
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            trail.startColor = Color.white;
        }
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
    }
}
