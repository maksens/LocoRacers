using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player", order = 1)]

public class PlayerStats : ScriptableObject
{
    [SerializeField]
    public Color CarColor = new Color(1, 1, 1);
    [SerializeField]
    public string PlayerName;
}
