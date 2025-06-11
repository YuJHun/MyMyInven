using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;               // 아이템 아이콘 이미지 컴포넌트
    [SerializeField] private TextMeshProUGUI _itemCountText; // 아이템 개수를 표시하는 텍스트
    [SerializeField] private GameObject _equipMark;           // 장착 상태를 표시하는 "E" 오브젝트

    private Item currentItem1; // 현재 슬롯에 들어 있는 아이템 참조

    void Start()
    {
        // 버튼 클릭 시 OnClickSlot 메서드를 실행하도록 이벤트 등록
        GetComponent<Button>().onClick.AddListener(OnClickSlot);
    }


    private void OnClickSlot()
    {
        // 해당 아이템을 플레이어에게 장착
        GameManager.Instance.playerCharacter.Equip(currentItem1);
        // 인벤토리 UI를 새로 갱신 (장착 표시 등 업데이트됨)
        UIManager.Instance.UIInventory.UpdateInventory(GameManager.Instance.playerCharacter);
    }
    // 아이템을 슬롯에 세팅하고 UI에 표시
    public void SetItem(Item item, Item equippedItem)
    {
        currentItem1 = item;    // 현재 아이템 저장
        RefreshUI();            // UI 요소 초기화 및 표시

        _equipMark.SetActive(item == equippedItem);               // 현재 장착 아이템이면 E 표시 활성화
    }
    // UI 요소를 현재 아이템 정보에 맞게 반영
    private void RefreshUI()
    {
        if (currentItem1 != null)
        {
            _itemIcon.sprite = currentItem1.Icon;                // 아이콘 설정
            _itemIcon.enabled = true;                            // 이미지 보이게 함
            _itemCountText.text = currentItem1.ItemCount > 1 ? currentItem1.ItemCount.ToString() : "";// 2개 이상일 때만 숫자 표시
        }
        else
        {
            _itemIcon.sprite = null;     // 이미지 제거
            _itemIcon.enabled = false;   // 아이콘 숨김
            _itemCountText.text = "";    // 텍스트 비우기
        }

    }
}
