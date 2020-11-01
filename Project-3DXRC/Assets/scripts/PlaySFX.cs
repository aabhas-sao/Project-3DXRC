using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaySFX : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData) {
        FindObjectOfType<AudioManager>().Play("hoverVFX");
    }

    public void OnPointerDown(PointerEventData eventData) {
        FindObjectOfType<AudioManager>().Play("click");
        Debug.Log("click");
    }
}
