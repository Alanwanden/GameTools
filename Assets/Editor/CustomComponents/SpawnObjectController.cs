using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
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
    }

}
