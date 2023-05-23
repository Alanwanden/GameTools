
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Calculate))]
public class CalculateEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Calculate calculate = (Calculate)target;
        if (GUILayout.Button("CalCulate"))
        {
            
            calculate.Calculating();
        }
    }
}
