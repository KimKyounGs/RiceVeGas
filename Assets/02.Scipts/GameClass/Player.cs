using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    [Tooltip("닉네임")]
    string _name;

    [Tooltip("주사위")]
    Dice _dice; 
    
    [Tooltip("턴")]
    bool _turn;
    Player(string name, Dice dice, bool turn)
    {
        _name = name;
        _dice = dice;
        _turn = turn;
    }
}
