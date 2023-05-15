
using UnityEngine;
using UnityEditor;
using log4net.Util;
using UnityEngine.WSA;
using System.Collections.Generic;

[CustomEditor(typeof(Louncher))]
public class LouncherEditor : Editor
{
    [DrawGizmo(GizmoType.Pickable | GizmoType.Selected)]
    static void DrawGizmoSelected(Louncher louncher, GizmoType gizmoType)
    {
        var offsetPosition = louncher.transform.TransformPoint(louncher.offset);
        Handles.DrawDottedLine(louncher.transform.position, offsetPosition, 3);
        Handles.Label(offsetPosition, "Offset");
        if (louncher.projectile != null)
        {
            var positions = new List<Vector3>();
            var velocity = louncher.transform.forward *
                louncher.velocity /
                louncher.projectile.mass;
            var position = offsetPosition;
            var physicsStep = 0.1f;
            for (var i = 0f; i <= 1f; i += physicsStep)
            {
                positions.Add(position);
                position += velocity * physicsStep;
                velocity += Physics.gravity * physicsStep;
            }
            using (new Handles.DrawingScope(Color.yellow))
            {
                Handles.DrawAAPolyLine(positions.ToArray());
                Gizmos.DrawWireSphere(positions[positions.Count - 1], 0.125f);
                Handles.Label(positions[positions.Count - 1], "Estimated Position (1 sec)");
            }

        }
    }

    private void OnSceneGUI()
    {
        var louncher= (Louncher)target;
        var transform= louncher.transform;
        using (var cc=new EditorGUI.ChangeCheckScope())
        {
            //louncher.offset = tranform.InverseTransformPoint(Handles.PositionHandle(tranform.TransformPoint(louncher.offset), tranform.rotation));
            var newOffset = transform.InverseTransformPoint(
            Handles.PositionHandle(
            transform.TransformPoint(louncher.offset),
                   transform.rotation));

            if (cc.changed)
            {
                Undo.RecordObject(louncher, "Offset Change");
                louncher.offset = newOffset;
            }
        }
        

        Handles.BeginGUI();
        var rectMin = Camera.current.WorldToScreenPoint(louncher.transform.position + louncher.offset);
        var rect = new Rect();
        rect.x = rectMin.x;
        rect.y = SceneView.currentDrawingSceneView.position.y-rectMin.y;
        rect.width = 64;
        rect.height = 18;
        GUILayout.BeginArea(rect);
        using(new EditorGUI.DisabledGroupScope(!UnityEngine.Application.isPlaying))
        {
            if (GUILayout.Button("Fire"))
            {
                louncher.Fire();
            }
        }
        GUILayout.EndArea();
        Handles.EndGUI();
    }
}
