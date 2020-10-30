using UnityEngine;  
using System.Collections;  
using UnityEngine.EventSystems;  
using UnityEngine.UI;
 
public class colorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Text theText;
    public Color red;
    public Color blue;

    public void OnPointerEnter(PointerEventData eventData)
    {
        theText.color = red; //Or however you do your color
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = blue; //Or however you do your color
    }
 }