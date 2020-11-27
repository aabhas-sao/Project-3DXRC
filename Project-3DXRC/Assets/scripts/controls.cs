using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour
{
    public GameObject main_menu, controls_ui, help_ui;

    public void ShowControls() {
        main_menu.SetActive(false);
        controls_ui.SetActive(true);
    }
    public void ShowHelp() {
        main_menu.SetActive(false);
        help_ui.SetActive(true);
    }
}
