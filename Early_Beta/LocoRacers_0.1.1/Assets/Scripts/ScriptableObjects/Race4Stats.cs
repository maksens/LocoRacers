using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RaceData #4", menuName = "Data/Race#4", order = 1)]
public class Race4Stats : ScriptableObject
{
    [SerializeField]
    public float RecordTime = 30.00f;

    public float FirstPositionTimer;
    public float SecondPositionTimer;
    public float ThirdPositionTimer;
    public float FourthPositionTimer;

    public string FirstPosition;
    public string SecondPosition;
    public string ThirdPosition;
    public string FourthPosition;
}
