using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [Header("슬롯 프리팹 & 부모")]
    [SerializeField] private UISlot slotPrefab;
    [SerializeField] private Transform slotParent;

    [Header("장비 해제 버튼")]
    [SerializeField] private Button unEquipButton;

    private List<UISlot> slotList = new List<UISlot>();

    private Character _currentCharacter;
    private void Start()
    {
        unEquipButton.onClick.AddListener(OnUnEquipButtonClick);
        _currentCharacter=GameManager.Instance.playerCharacter;
    }
    public void UpdateInventory(Character character)
    {
        //슬록 목록을 초기화하고 새로고침
        foreach (var slot in slotList)
        {
            Destroy(slot.gameObject);
        }

        // 슬롯 목록을 비웁니다.
        slotList.Clear();

        // 현재 캐릭터가 null인지 확인
        foreach (Item item in character.Inventory)
        {
            UISlot newSlot = Instantiate(slotPrefab, slotParent);
            newSlot.SetItem(item, character.EquippedItem);
            slotList.Add(newSlot);
        }
        //_currentCharacter = character;
    }


    // 장착 해제 버튼 클릭 시 호출되는 메서드
    private void OnUnEquipButtonClick()
    {
        Debug.Log("OnUnEquipButtonClick 클릭");
        if (_currentCharacter != null)
        {
            Debug.Log($"UIInventory: _currentCharacter가 설정되어 있습니다: {_currentCharacter.characterName}");
            _currentCharacter.UnEquip();
            UpdateInventory(_currentCharacter);
        }
        else
        {
            Debug.LogWarning("UIInventory: 현재 캐릭터가 설정되지 않아 아이템을 해제할 수 없습니다.");
        }
        // UIManager.Instance.UIInventory.UpdateInventory(GameManager.Instance.playerCharacter);
    }
}
