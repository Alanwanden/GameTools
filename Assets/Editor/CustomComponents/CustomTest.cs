using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(SampleX))]
public class CustomTest : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        SampleX sample=(SampleX)target;  

    }

    
}
