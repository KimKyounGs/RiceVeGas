using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    [Tooltip("�г���")]
    string _name;

    [Tooltip("�ֻ���")]
    Dice _dice; 
    
    [Tooltip("��")]
    bool _turn;
    Player(string name, Dice dice, bool turn)
    {
        _name = name;
        _dice = dice;
        _turn = turn;
    }
}
