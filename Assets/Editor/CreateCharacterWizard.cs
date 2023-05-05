using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateCharacterWizard : ScriptableWizard
{
    public Texture2D portraitTexture;
    public Color color;
    public string nick="default";
    [MenuItem("GameTools/CreateCharacterWizard")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<CreateCharacterWizard>("CreateCharacter","Create new ","Update Character");
    }
}
