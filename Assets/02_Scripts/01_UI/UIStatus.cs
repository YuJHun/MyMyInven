using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _atText;
    [SerializeField] private TextMeshProUGUI _dfText;
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private TextMeshProUGUI _crText;

    public void UpdateStatus(Character character)
    {
        if (character == null)
        {
            Debug.LogError("UIStatus: 캐릭터 정보가 없습니다!");
            return;
        }
        //atText.text = $"At: {character.baseHp}";
        _atText.text = $"At: {character.TotalAt}";
        _dfText.text = $"Df: {character.TotalDf}";
        _hpText.text = $"HP: {character.TotalHp}";
        _crText.text = $"CR: {character.TotalCr}";
    }
}
