using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SelecAllOffTags :ScriptableWizard
{
    public string SearchTag = "your Tag Here";
    [MenuItem("GameTools/SelectAllOffTags")]
    static void SelectAllOffTagWizard()
    {
        ScriptableWizard.DisplayWizard<SelecAllOffTags>("select tags", "make selection");
    }
    private void OnWizardCreate()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(SearchTag);
        Selection.objects = gameObjects;
    }
}
