using UnityEngine;
using UnityEngine.EventSystems;

public class PlaySFX2 : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public void OnPointerEnter(PointerEventData eventData) {
        FindObjectOfType<AudioManager>().Play("hoverSFX");
    }

    public void OnPointerClick(PointerEventData eventData) {
        FindObjectOfType<AudioManager>().Play("carStartSFX");
    }
}
