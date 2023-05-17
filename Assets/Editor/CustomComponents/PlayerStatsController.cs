using UnityEngine;
using UnityEditor;
using UnityEngine.Analytics;

[CustomEditor(typeof(PlayerStats))]
public class PlayerStatsController : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        EditorGUILayout.HelpBox("this is help box help box",MessageType.Info);
    }
}
