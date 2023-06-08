using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

[CustomEditor(typeof(ObjectBuilder))]
public class SpawnObjectController : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        ObjectBuilder builder = (ObjectBuilder)target;
        if(GUILayout.Button("build object"))
        {
            builder.SpawnObj();
        }
        if(GUILayout.Button("is it 2d"))
        {
            Debug.Log("works");
        }
        
    }

}
