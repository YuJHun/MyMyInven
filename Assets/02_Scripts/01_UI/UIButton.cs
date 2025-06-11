using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField] private UIStatus _uiStatus;
    [SerializeField] private UIMainMenu _uiMainMenu;
    [SerializeField] private GameObject _uiInventory;

    public Button mainMenuButton1;
    public Button mainMenuButton2;
    public Button statusButton1;
    public Button inventoryButton1;
    //public Button backButton1;
    // Start is called before the first frame update
    void Start()
    {
        mainMenuButton1.onClick.AddListener(OpenMainMenu);
        mainMenuButton2.onClick.AddListener(OpenMainMenu);
        statusButton1.onClick.AddListener(OpenStatus);
        inventoryButton1.onClick.AddListener(OpenInventory);
    }
    public void OpenMainMenu()
    {
        CloseAll();
        UIManager.Instance.statusUpdate();
        _uiMainMenu.gameObject.SetActive(true);
    }
    public void OpenStatus()
    {
        CloseAll();
        _uiStatus.gameObject.SetActive(true);
        _uiStatus.UpdateStatus(GameManager.Instance.playerCharacter);
    }

    public void OpenInventory()
    {
        CloseAll();
        _uiInventory.gameObject.SetActive(true);
    }

    public void CloseAll()
    {
        _uiMainMenu.gameObject.SetActive(false);
        _uiStatus.gameObject.SetActive(false);
        _uiInventory.gameObject.SetActive(false);
    }
}
