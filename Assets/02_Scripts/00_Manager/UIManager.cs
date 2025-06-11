using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance { get; private set; }

    //에디터 인스펙터 창에서는 노출되고, 스크립트 밖에서는 보호되는 구조
    [SerializeField] private UIMainMenu _uiMainMenu;
    [SerializeField] private UIStatus _uiStatus;
    [SerializeField] private UIInventory _uiInventory;


    //C#의 프로퍼티(get-only property) 문법을 활용, 목적은 private 필드에 대한 안전한 외부 접근을 제공
    public UIMainMenu UIMainMenu
    {
        get { return _uiMainMenu; }
    }
    public UIStatus UIStatus => _uiStatus;
    public UIInventory UIInventory => _uiInventory;
    private IEnumerator Start()
    {
        yield return null; // 한 프레임 기다리기
        statusUpdate();
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    public void statusUpdate()
    {
        // 캐릭터 정보 업데이트
        if (GameManager.Instance != null && GameManager.Instance.playerCharacter != null)
        {
            UIMainMenu mainMenu = UIManager.Instance.UIMainMenu;
            mainMenu.UpdateMainInfo(GameManager.Instance.playerCharacter);

            // 상태창도 동시에 미리 업데이트 (필요 시)
            UIManager.Instance.UIStatus.UpdateStatus(GameManager.Instance.playerCharacter);
        }
        else
        {
            Debug.LogError(" GameManager 또는 playerCharacter가 null입니다.");
        }
    }

}
