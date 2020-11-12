using UnityEngine;
using UnityEngine.EventSystems;

public class PlaySFX2 : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    private AudioManager audioManager;
    void Start() {
        audioManager = (AudioManager) FindObjectOfType(typeof(AudioManager));
    }

    public void OnPointerEnter(PointerEventData eventData) {
        audioManager.Play("hoverSFX");
    }

    public void OnPointerClick(PointerEventData eventData) {
        audioManager.Play("carStartSFX");
    }
}
