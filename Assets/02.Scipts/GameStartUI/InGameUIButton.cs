using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject ScorePanel;
    public GameObject OptionPanel;

    //������ ���� ��ư
    public void ScorePanelOn()
    {
        ScorePanel.SetActive(true);
    }
    //������ �ݴ� ��ư
    public void ScorePanelOff()
    {
        ScorePanel.SetActive(false);
    }
    //�ɼ� ���� ��ư
    public void OptionPanelOn()
    {
        OptionPanel.SetActive(true);
    }
    //�ɼ� �ݴ� ��ư
    public void OptionPanelOff()
    {
        OptionPanel.SetActive(false);
    }
}
