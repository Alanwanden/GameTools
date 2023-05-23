using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Character", menuName ="Character")]
public class Characters : ScriptableObject
{
    public string CharacterName;
    public string CharacterType;

    public float mana;
    public float healt;
    public float damage;
    public float speed;
    public float hitSpeed;
    public float Shield;


    
}
