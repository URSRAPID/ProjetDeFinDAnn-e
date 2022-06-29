using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelSelectionManager : MonoBehaviour
{
    public Button[] lvlButtons;
    public TextMeshProUGUI[] recordText;

    void Start()
    {
        SaveData data = SaveDataScript.LoadData();
        lvlButtons[1].interactable = data.accesLVL2;
        lvlButtons[2].interactable = data.accesLVL3;
        recordText[0].text = "Best Score:" + data.bestScoreLVL1.ToString();
        recordText[1].text = "Best Score:" + data.bestScoreLVL2.ToString();
        recordText[2].text = "Best Score:" + data.bestScoreLVL3.ToString();
    }

}
