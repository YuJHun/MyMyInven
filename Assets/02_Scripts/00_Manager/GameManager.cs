using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // 1. 플레이어 캐릭터
    public Character playerCharacter { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //  게임 시작 시 초기 데이터 세팅
    private void Start()
    {
        SetData();// 플레이어 데이터 및 UI 초기화

    }

    // 2. 데이터 초기화 메서드
    public void SetData()
    {
        // 예시 데이터로 Player 생성
        //playerCharacter = new Character(11, "기사", 1, 1, 50, 0, 0, 0);
        //playerCharacter = new Character(이름, 직업, 레벨, 경험치, 공격력,방어력, 체력, 치명타);

        //Resources에서 아이콘 불러오기(파일은 Resources / Icons 폴더에 있어야 함)
        Sprite potionIcon = Resources.Load<Sprite>("04_Sprites/Icons/Medisine");
        Sprite swordIcon = Resources.Load<Sprite>("04_Sprites/Icons/Weapon");

        //아이템 생성자 통해 아이템 리스트 만들기
        //아이콘,이름, 개수, 타입,공격력, 방어력, 체력, 치명타
        List<Item> initialItems = new List<Item> {
            new Item(potionIcon, "회복약", 3,ItemType.Consumable),
            new Item(swordIcon, "낡은 검", 1, ItemType.Weapon,5,10,50,50),
            new Item(potionIcon, "회복약", 3,ItemType.Consumable),
            new Item(swordIcon, "낡은 검", 1, ItemType.Weapon,5,10,50,50),
            new Item(potionIcon, "회복약", 3,ItemType.Consumable),
            new Item(swordIcon, "낡은 검", 1, ItemType.Weapon,5,10,50,50),
            new Item(potionIcon, "회복약", 3,ItemType.Consumable),
            new Item(swordIcon, "낡은 검", 1, ItemType.Weapon,5,10,50,50),
            new Item(potionIcon, "회복약", 3,ItemType.Consumable),
            new Item(swordIcon, "낡은 검", 1, ItemType.Weapon,5,10,50,50),
            new Item(potionIcon, "회복약", 3,ItemType.Consumable),
            new Item(swordIcon, "낡은 검", 1, ItemType.Weapon,5,10,50,50),
        };
        //  아이템 포함해서 캐릭터 생성
        playerCharacter = new Character(
            gold1: 11,
            name1: "기사",
            level1: 1,
            exp1: 1,
            at1: 50,
            df1: 10,
            hp1: 10,
            cr1: 10,
            initialInventory: initialItems //  아이템 리스트 전달
        );
       
        // 테스트용 아이템 아이콘 불러오기
        Sprite bowIcon = Resources.Load<Sprite>("04_Sprites/Icons/Bow");

        // 아이템 인스턴스 생성
        Item testItem = new Item(bowIcon, "테스트용 활", 1, ItemType.Weapon,100,200,300,100);

        // 플레이어 인벤토리에 추가
        playerCharacter.AddItem(testItem);

        // 5. 모든 캐릭터 데이터 설정이 완료된 후, UI를 한 번에 업데이트
        if (UIManager.Instance != null)
        {
            Debug.Log("GameManager: UIManager.Instance 존재. UI 업데이트 시작.");

            // UIMainMenu 업데이트
            if (UIManager.Instance.UIMainMenu != null)
            {
                // UIMainMenu가 UIMainMenu 스크립트 타입이라면 직접 호출
                UIManager.Instance.UIMainMenu.UpdateMainInfo(playerCharacter);
                // 만약 UIMainMenu가 GameObject 타입이라면 GetComponent<UIMainMenu>()?.UpdateMainInfo(playerCharacter);
            }
            else
            {
                Debug.LogWarning("GameManager: UIManager.Instance.UIMainMenu가 null입니다. Inspector 할당 확인.");
            }

            // UIStatus 업데이트
            if (UIManager.Instance.UIStatus != null)
            {
                // UIManager.Instance.UIStatus가 GameObject 타입이므로 GetComponent로 스크립트 참조
                UIManager.Instance.UIStatus.GetComponent<UIStatus>()?.UpdateStatus(playerCharacter);
            }
            else
            {
                Debug.LogWarning("GameManager: UIManager.Instance.UIStatus가 null입니다. Inspector 할당 확인.");
            }

            // UIInventory 업데이트 (가장 중요)
            if (UIManager.Instance.UIInventory != null)
            {
                // **여기서 playerCharacter가 null이 아님을 보장**
                UIManager.Instance.UIInventory.UpdateInventory(playerCharacter);
                Debug.Log("GameManager: UIInventory.UpdateInventory 호출 완료.");

                // 인벤토리 UI가 꺼져있다면 켜주는 메서드 호출 (UIManager에 구현되어 있어야 함)
                //UIManager.Instance.OpenInventoryUI?.Invoke(); // Null Conditional Operator 사용
            }
            else
            {
                Debug.LogWarning("GameManager: UIManager.Instance.UIInventory가 null입니다. UIManager 인스펙터 할당 확인 필요.");
            }
        }
        else
        {
            Debug.LogWarning("GameManager: UIManager.Instance가 존재하지 않습니다. UI 업데이트 건너뜀.");
        }

        Debug.Log("GameManager: SetData - 데이터 초기화 및 초기 UI 업데이트 완료.");
    }
}

