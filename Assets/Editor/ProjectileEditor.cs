
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Projectile))]
public class ProjectileEditor : Editor
{
    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    static void DrawGizmoSelected(Projectile projectile,GizmoType gizmoType)
    {
        Gizmos.DrawSphere(projectile.transform.position,0.125f);
    }

    private void OnSceneGUI()
    {
        var projectile=(Projectile)target;
        var transform = projectile.transform;
        projectile.damageRadius = Handles.RadiusHandle(transform.rotation, transform.position, projectile.damageRadius);

    }
}
