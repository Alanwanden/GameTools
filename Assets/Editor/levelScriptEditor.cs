using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;

[CustomEditor(typeof(Level))]
public class levelScriptEditor : Editor
{
  public override void OnInspectorGUI()
    {
        Level myTarget = (Level)target;
        myTarget.exprience = EditorGUILayout.IntField("Exprience", myTarget.exprience);
        EditorGUILayout.LabelField("CurrentLevel", myTarget.CurrentLevel.ToString());
    }
}
