using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI goldText1;
    [SerializeField] private Character character; // 캐릭터 정보가 필요할 경우 사용
    [SerializeField]private Image expFillImage; // 경험치 게이지 이미지
    private void Start()
    {
        
    }
    public void UpdateMainInfo(Character character)
    {
        if (character == null)
        {
            Debug.LogError("UIMainMenu: 캐릭터 정보가 없습니다!");
            return;
        }

        nameText.text = $"{character.characterName}";
        levelText.text = $"{character.characterLevel}";
        expText.text = $"{character.characterExp+" / "+character.characterMaxExp}";
        // fillAmount 설정 (0.0 ~ 1.0 범위의 값)
        expFillImage.fillAmount = (float)character.characterExp / character.characterMaxExp;
        goldText1.text = $"{character.characterGold}"; 
    }
   
}
