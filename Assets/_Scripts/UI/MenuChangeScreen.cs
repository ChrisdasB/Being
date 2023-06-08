using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuChangeScreen : MonoBehaviour
{
    // Closes one and opens another UI panel
    [SerializeField] GameObject screenToClose;
    [SerializeField] GameObject screenToOpen;


    Button button;
    // Start is called before the first frame update

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeScreen);
    }

    public void ChangeScreen()
    {
        screenToOpen.SetActive(true);
        screenToClose.SetActive(false);                
    }
}
