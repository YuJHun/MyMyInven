using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[System.Serializable]
public class Character
{
    public string characterName { get; private set; }
    public int characterLevel { get; private set; }
    public int characterExp { get; private set; }
    public int characterMaxExp;
    public int characterBaseAt { get; private set; }
    public int characterBaseDf { get; private set; }
    public int characterBaseHp { get; private set; }
    public int characterBaseCr { get; private set; }
    public int characterGold { get; private set; }

    // 인벤토리와 장착 아이템
    public List<Item> Inventory { get; private set; }
    public Item EquippedItem { get; private set; }

    // 현재 총 스탯 (기본 + 장비 포함)
    public int TotalAt => characterBaseAt + (EquippedItem?.ItemAttack ?? 0);
    public int TotalDf => characterBaseDf + (EquippedItem?.ItemDefense ?? 0);
    public int TotalHp => characterBaseHp + (EquippedItem?.ItemHP ?? 0);
    public int TotalCr => characterBaseCr + (EquippedItem?.ItemCritical ?? 0);

    public Character(int gold1, string name1, int level1,int exp1,int at1 ,int df1,int hp1,int cr1, List<Item> initialInventory = null)
    {
        characterGold = gold1;
        characterName = name1;
        characterLevel = level1;
        characterExp = exp1;
        characterMaxExp = 12;  
        characterBaseAt = at1;
        characterBaseDf = df1;
        characterBaseHp = hp1;
        characterBaseCr = cr1;

        //Inventory = initialInventory ?? new List<Item>();
        if (initialInventory != null)
        {
            Inventory = initialInventory;
        }
        else
        {
            Inventory = new List<Item>();
        }
        EquippedItem = null;
    }
    // 아이템 추가
    public void AddItem(Item item)
    {
        Inventory.Add(item);
        Debug.Log($"{item.ItemName} 을(를) 인벤토리에 추가했습니다.");
    }

    //  장비 장착
    public void Equip(Item item)
    {
        if (!item.IsEquippable())
        {
            Debug.LogWarning($"{item.ItemName}은(는) 장착할 수 없는 아이템입니다.");
            return;
        }

        if (Inventory.Contains(item))
        {
            EquippedItem = item;
            Debug.Log($"{item.ItemName} 을(를) 장착했습니다.");
        }
        else
        {
            Debug.LogWarning("해당 아이템은 인벤토리에 없습니다.");
        }
    }
    public void UnEquip()
    {
        Debug.Log($"Character.UnEquip 호출됨. 현재 EquippedItem: {(EquippedItem != null ? EquippedItem.ItemName : "null")}");

        if (EquippedItem != null)
        {
            Debug.Log($"UnEquip: EquippedItem이 null이 아님. 이름: {EquippedItem.ItemName}");

            // 더 이상 baseAt 등을 직접 뺄 필요가 없습니다.
            // EquippedItem이 null로 설정되면 TotalAt 등의 프로퍼티가 자동으로 갱신됩니다.

            //Inventory.Add(EquippedItem); // 인벤토리로 다시 추가
            EquippedItem = null; // 장착 해제
            Debug.Log($"{characterName}이(가) 아이템을 해제했습니다.");
        }
        else
        {
            Debug.LogWarning($"{characterName}은(는 장착된 아이템이 없습니다.");
        }
    }
   

    public void AddExp(int amount)
    {
        characterExp += amount;
        while (characterExp >= characterMaxExp)
        {
            characterExp -= characterMaxExp; // 남은 경험치 이월
            LevelUp();
        }
    }

    public void LevelUp()
    {
        characterLevel++;
        Debug.Log($"{characterName} 레벨 업! 현재 레벨: {characterLevel}");
    }
}
