using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core;
using UnityEditor;
using UnityEngine;

public class CreateCharacterWizard : ScriptableWizard
{
    public Texture2D portraitTexture;
    public Color color;
    public string nickname="default";
    
    [MenuItem("GameTools/CreateCharacterWizard")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<CreateCharacterWizard>("CreateCharacter","Create new ","Update Character");
    }
   
    void OnWizardCreate()
    {
        GameObject characterGO = new GameObject();

        Character characterComponent = characterGO.AddComponent<Character>();
        characterComponent.portrait = portraitTexture;
        characterComponent.color = color;
        characterComponent.nickname = nickname;

        PlayerController playerController = characterGO.AddComponent<PlayerController>();
        characterComponent.playerController = playerController;
        characterGO.name = nickname;
        characterGO.tag="enemy";
        
    }
    

    void OnWizardOtherButton()
    {
        if (Selection.activeTransform != null)
        {
            Character characterComponent = Selection.activeTransform.GetComponent<Character>();

            if (characterComponent != null)
            {
                characterComponent.portrait = portraitTexture;
                characterComponent.color = color;
                characterComponent.nickname = nickname;
            }
        }
    }

    void OnWizardUpdate()
    {
        helpString = "Enter character details";
    }

}