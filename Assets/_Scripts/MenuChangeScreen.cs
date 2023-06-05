using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuChangeScreen : MonoBehaviour
{
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

    private void Update()
    {
        
    }

}
