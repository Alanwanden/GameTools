using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

[CustomEditor(typeof(GameStyleHelper))]
public class GameStyle : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GameStyleHelper gameStyleHelper=(GameStyleHelper)target;
        if (GUILayout.Button("Side View"))
        {
            gameStyleHelper.mainCamera = Camera.main;
            gameStyleHelper.SideWiew();

        }
        if (GUILayout.Button("Forward View"))
        {
            gameStyleHelper.mainCamera = Camera.main;
            gameStyleHelper.Forward();

        }
        if (GUILayout.Button("TopDown View"))
        {
            gameStyleHelper.mainCamera = Camera.main;
            gameStyleHelper.TopDownView();

        }
        if (GUILayout.Button("Runner"))
        {
            gameStyleHelper.RunnerGame();
        }

        if (GUILayout.Button("Platform Game"))
        {
            
            gameStyleHelper.PlatformGame();
        }
    }
}
