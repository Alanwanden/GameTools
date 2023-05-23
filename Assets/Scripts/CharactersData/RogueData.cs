using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;
[CreateAssetMenu(fileName = "New Rogue Data", menuName = "Character Menu/Rogue")]
public class RogueData : ScriptableObject
{
    public RogueWeaponType RogueWeaponType;
    public RogueStrategyType RogueStrategyType;
    
}
