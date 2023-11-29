using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject ScorePanel;
    public GameObject OptionPanel;

    //점수판 여는 버튼
    public void ScorePanelOn()
    {
        ScorePanel.SetActive(true);
    }
    //점수판 닫는 버튼
    public void ScorePanelOff()
    {
        ScorePanel.SetActive(false);
    }
    //옵션 여는 버튼
    public void OptionPanelOn()
    {
        OptionPanel.SetActive(true);
    }
    //옵션 닫는 버튼
    public void OptionPanelOff()
    {
        OptionPanel.SetActive(false);
    }
}
