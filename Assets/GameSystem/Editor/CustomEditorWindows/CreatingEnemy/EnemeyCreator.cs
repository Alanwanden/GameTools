using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using PlasticGui.WorkspaceWindow.CodeReview;
using System.Runtime.Remoting.Messaging;
using Types;
using UnityEngine.Rendering;

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


    public static MageData MageInfo  {get { return mageData; }}
    public static WoriorData WoriorInfo { get { return woriorData; }}
    public static RogueData RogueInfo { get { return rogueData; }}
    
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

        if (GUILayout.Button("Create!",GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingTypes.MAGE);
        }
        
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

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingTypes.WARIOR);
        }
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

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingTypes.ROGUE);
        }
        GUILayout.EndArea();

    }
}
public class GeneralSettings:EditorWindow
{
    public enum SettingTypes
    {
        MAGE,
        WARIOR,
        ROGUE
    }
    static SettingTypes dataSetting;
    static GeneralSettings window;
    public static void OpenWindow(SettingTypes setting)
    {
        dataSetting = setting;
        window=(GeneralSettings)GetWindow(typeof(GeneralSettings));
        window.minSize = new Vector2(250, 200);
        window.Show();
    }
    void OnGUI()
    {
        switch (dataSetting)
        {
            
            case SettingTypes.MAGE:
                DrawSettings((CharactersData)EnemeyCreator.MageInfo);
                break;
            case SettingTypes.WARIOR:
                DrawSettings((CharactersData)EnemeyCreator.WoriorInfo);
                break;
            case SettingTypes.ROGUE:
                DrawSettings((CharactersData)EnemeyCreator.RogueInfo);
                break;
            default:
                break;
        }
    }
    void DrawSettings(CharactersData CharData)
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Prefab");
        CharData.prefab = (GameObject)EditorGUILayout.ObjectField(CharData.prefab, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Max Health");
        CharData.maxHealth=EditorGUILayout.FloatField(CharData.maxHealth);
        
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Max Energy");
        CharData.maxEnergy=EditorGUILayout.FloatField(CharData.maxEnergy);
       

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Power");
        CharData.power = EditorGUILayout.Slider(CharData.power, 0, 100);
       

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("max Speed");
        CharData.maxSpeed = EditorGUILayout.Slider(CharData.maxSpeed,0,100);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Name");
        CharData.name = EditorGUILayout.TextField(CharData.name);
        EditorGUILayout.EndHorizontal();

        if (CharData.prefab == null) { EditorGUILayout.HelpBox("character Has no prefabs yet", MessageType.Warning); }
        else if (CharData.maxHealth == 0) { EditorGUILayout.HelpBox("character has no health yet!", MessageType.Warning); }
        else if (CharData.power ==0) { EditorGUILayout.HelpBox("character power value cant be zero!",MessageType.Warning); }
        else if (CharData.maxEnergy == 0) { EditorGUILayout.HelpBox("character energy value cant be zero!", MessageType.Warning); }
        else if (CharData.maxSpeed ==0) { EditorGUILayout.HelpBox("character speed value cant be zero!",MessageType.Warning); }
        else if (CharData.name == "") { EditorGUILayout.HelpBox("character has no name yet!", MessageType.Warning); }
        else if(GUILayout.Button("Finnis And Save"))
        {
            SaveCharacterData();
            window.Close();
        }
    }
    void SaveCharacterData()
    {
        string prefabsPath;
        string newPrefabsPath = "Assets/GameSystem/prefabs/characterPrefabs";
        string dataPath = "Assets/Scripts/CharactersData/";

        switch (dataSetting)
        {
            case SettingTypes.MAGE:
                //dataPath += "mage/" + EnemeyCreator.MageInfo.name + ".asset";
                //AssetDatabase.CreateAsset(EnemeyCreator.MageInfo, dataPath);

                //newPrefabsPath+= "mage/" + EnemeyCreator.MageInfo.name + ".prefab";
                //prefabsPath = AssetDatabase.GetAssetPath(EnemeyCreator.MageInfo.prefab);
                //AssetDatabase.CopyAsset(prefabsPath, newPrefabsPath);
                //AssetDatabase.SaveAssets();
                //AssetDatabase.Refresh();

                //GameObject magePrefab=(GameObject)AssetDatabase.LoadAssetAtPath(newPrefabsPath,typeof(GameObject));
                //if (!magePrefab.GetComponent<Mage>())
                //{
                //    magePrefab.AddComponent(typeof(Mage));

                //}

                //magePrefab.GetComponent<Mage>().mageData = EnemeyCreator.MageInfo;

                break;
            case SettingTypes.WARIOR:

                break;
            case SettingTypes.ROGUE:
                break;
            default:
                break;
        }
    }

}
