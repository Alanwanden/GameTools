using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;
[CreateAssetMenu(fileName ="New Mage Data",menuName ="Character Menu/Mage")]
public class MageData : ScriptableObject
{
   public MageDamageType mageDamageType;
   public MageWeaponType mageWeaponType;
}
