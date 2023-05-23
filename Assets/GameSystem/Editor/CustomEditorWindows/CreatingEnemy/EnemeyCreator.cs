using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using PlasticGui.WorkspaceWindow.CodeReview;
using System.Runtime.Remoting.Messaging;
using Types;

public class EnemeyCreator : EditorWindow
{
    Texture2D headerSectionTexture;
    Texture2D mageSectionTexture;
    Texture2D voriorSectionTexture;
    Texture2D rogueSectionTexture;

    Rect headerSection;
    Rect mageSection;
    Rect voriorSection;
    Rect rogueSection;
    static MageData mageData;
    static WoriorData woriorData;
    static RogueData rogueData;


    public static MageData mageInfo  {get { return mageData; }}
    public static WoriorData woriorInfo { get { return woriorData; }}
    public static RogueData rogueInfo { get { return rogueData; }}
    
    Color headerSectionColor=new Color(13/255,32/255,44/255,1f);
   [MenuItem("Window/EnemeyCreator")]
   static void OpenedCodeReviewWindows()
    {
        EnemeyCreator window=(EnemeyCreator)GetWindow(typeof(EnemeyCreator));
        window.minSize = new Vector2(600, 300);
        window.Show();
        
    }
    private void OnEnable()
    {
        InItTexture();
        IntData();
    }
    private static void IntData()
    {
        mageData=(MageData)ScriptableObject.CreateInstance(typeof(MageData));
        woriorData=(WoriorData)ScriptableObject.CreateInstance(typeof(WoriorData));
        rogueData=(RogueData)ScriptableObject.CreateInstance(typeof(RogueData));    

    }
    private void InItTexture()
    {   //header
        headerSectionTexture=new Texture2D(1,1);
        headerSectionTexture.SetPixel(0, 0, headerSectionColor);
        headerSectionTexture.Apply();
        //mage
        mageSectionTexture = Resources.Load<Texture2D>("icons/m");
        voriorSectionTexture = Resources.Load<Texture2D>("icons/v");
        rogueSectionTexture = Resources.Load<Texture2D>("icons/r");


    }
    private void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
        MageSettings();
        VoriorSettings();
        RogueSettings();
    }
    void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width=Screen.width;
        headerSection.height=50;

        mageSection.x = 0;
        mageSection.y = 50;
        mageSection.width = Screen.width / 3f;
        mageSection.height = Screen.width - 50; 

        voriorSection.x = Screen.width/3f;
        voriorSection.y = 50;
        voriorSection.width = Screen.width / 3f;
        voriorSection.height = Screen.width - 50;

        rogueSection.x = (Screen.width/3f)*2;
        rogueSection.y = 50;
        rogueSection.width = Screen.width / 3f;
        rogueSection.height = Screen.width - 50;


        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture (mageSection, mageSectionTexture); 
        GUI.DrawTexture(voriorSection, voriorSectionTexture);
        GUI.DrawTexture(rogueSection, rogueSectionTexture);

    }
    void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);
        GUILayout.Label("header");
        GUILayout.EndArea();
    }
    void MageSettings()
    {
        GUILayout.BeginArea(mageSection);
        GUILayout.Label("mage");
        GUILayout.BeginHorizontal();
        GUILayout.Label("Damage");
        mageData.mageDamageType=(MageDamageType)EditorGUILayout.EnumPopup(mageData.mageDamageType);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label("Weapon");
        mageData.mageWeaponType = (MageWeaponType)EditorGUILayout.EnumPopup(mageData.mageWeaponType);
     
        GUILayout.EndHorizontal();
        
        GUILayout.EndArea();

    }
    void VoriorSettings()
    {   GUILayout.BeginArea(voriorSection);
        GUILayout.Label("Vorior");
        GUILayout.BeginHorizontal();
        GUILayout.Label("Warior");
        woriorData.WariorClassType=(WariorClassType)EditorGUILayout.EnumPopup(woriorData.WariorClassType);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Weapon");
        woriorData.WariorWeaponType = (WariorWeaponType)EditorGUILayout.EnumPopup(woriorData.WariorWeaponType);
        GUILayout.EndHorizontal();
        GUILayout.EndArea();

    }
    void RogueSettings()
    {
        GUILayout.BeginArea(rogueSection);
        GUILayout.Label("Rogue");

       
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Strategy");
        rogueData.RogueStrategyType=(RogueStrategyType)EditorGUILayout.EnumPopup(rogueData.RogueStrategyType);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Weapon");
        rogueData.RogueWeaponType = (RogueWeaponType)EditorGUILayout.EnumPopup(rogueData.RogueWeaponType);
        GUILayout.EndHorizontal();

        GUILayout.EndArea();

    }
}
