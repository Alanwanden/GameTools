using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;
[CreateAssetMenu(fileName ="New Warior Data",menuName ="Character Menu/Worior")]
public class WoriorData : ScriptableObject
{
    public WariorWeaponType WariorWeaponType;
    public WariorClassType WariorClassType;
}
