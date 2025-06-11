using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Weapon,
    Armor,
    Consumable,
    Quest,
    Etc
}
public class Item 
{

    // 필드 - 내부 데이터 저장용: Unity Inspector에서 설정 가능하며, 클래스 내부에서만 직접 접근
    [SerializeField] private Sprite _itemIcon; 
    [SerializeField] private string _itemName; 
    [SerializeField] private int _itemCount;
    [SerializeField] private ItemType _itemType;

    // 장착 가능한 아이템 전용 스탯
    [SerializeField] private int _itemAttack;  
    [SerializeField] private int _itemDefense; 
    [SerializeField] private int _itemHp;      
    [SerializeField] private int _itemCritical;

    //[SerializeField] private bool _isEquippable; //장착가능여부 확인
   // 프로퍼티 - 외부 접근용: 외부에서는 이 프로퍼티들을 통해 값을 '읽을' 수만 있음 (읽기 전용)
    public Sprite Icon
    {
        get { return _itemIcon; }            // 아이템의 아이콘을 가져옵니다.
    }
    public string ItemName => _itemName;    // 아이템의 이름을 가져옵니다.
    public int ItemCount => _itemCount;         // 아이템의 현재 개수를 가져옵니다.
    public ItemType Type => _itemType;      // 아이템의 종류를 가져옵니다.

    public int ItemAttack => _itemAttack;       // 아이템의 공격력 스탯을 가져옵니다.
    public int ItemDefense => _itemDefense;     // 아이템의 방어력 스탯을 가져옵니다.
    public int ItemHP => _itemHp;               // 아이템의 체력 스탯을 가져옵니다.
    public int ItemCritical => _itemCritical;   // 아이템의 치명타 스탯을 가져옵니다.

    // 생성자 - Item 객체 생성 시 초기값 세팅
    public Item(Sprite icon, string name, int count, ItemType type, int attack = 0, int defense = 0, int hp = 0, int critical = 0)
    {
        // 'this.' 키워드를 사용하여 필드와 매개변수 이름이 같을 때 구별합니다.
        // 또는 필드 이름을 명확히 변경하여 구별합니다. (여기서는 _ 접두사로 구별)
        _itemIcon = icon;
        _itemName = name;
        _itemCount = count;
        _itemType = type;
        _itemAttack = attack;
        _itemDefense = defense;
        _itemHp = hp;
        _itemCritical = critical;
    }
    // 아이템이 장착 가능한 타입인지 여부를 반환하는 메서드
    public bool IsEquippable()
    {
        return _itemType == ItemType.Weapon || _itemType == ItemType.Armor;
    }

}
