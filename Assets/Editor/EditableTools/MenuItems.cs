using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItems : Editor
{
    [MenuItem("Window/NewMenuOption %#a")]
    private static void NewMenuOption()
    {
        
    }
    [MenuItem("Tools/SubMenu/Option Ctrl g")]
    private static void NewnestedMenuOption()
    {

    }
    [MenuItem("Tools/Item2 _g")]
    private static void NewOptionWitHotKey()
    { 
    }
    [MenuItem("Window/Load Addittive Scene")]
    [System.Obsolete]
    private static void LoadAddittiveScene()
    {
        var selection = Selection.activeObject;
        EditorApplication.OpenSceneAdditive(AssetDatabase.GetAssetPath(selection));
    }
    [MenuItem("Asset/Create/Add Configuration")]
    private static void AddConfig()
    {

    }
    [MenuItem("CONTEXT/Rigidbody/New Option")]
    private static void NewOpenForRigidBody()
    {

    }
    [MenuItem("Asset/ProccesTexture")]
    private static void ProccesTexture()
    { 
        var select=Selection.activeGameObject; 
        select.GetComponentInChildren<MeshRenderer>().sharedMaterial.color = Color.red;
    }
    [MenuItem("Sample/Option1", false, 1)]
    private static void MenuOption()
    {
    }

    [MenuItem("Sample/Option2", false, 2)]
    private static void NewMenuOption2()
    {
    }

    [MenuItem("Sample/Option3", false, 3)]
    private static void NewMenuOption3()
    {
    }

    [MenuItem("Sample/Option4", false, 51)]
    private static void NewMenuOption4()
    {
    }

    [MenuItem("Sample/Option5", false, 52)]
    private static void NewMenuOption5()
    {
    }
}
