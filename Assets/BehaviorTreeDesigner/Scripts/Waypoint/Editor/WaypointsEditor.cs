using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Waypoints))]
public class WaypointsEditor : Editor
{
	private static bool placeMode = false;

	public override void OnInspectorGUI()
    {
		Waypoints visPoints = (Waypoints)target;

		visPoints.showGizmos = EditorGUILayout.Toggle("Show Gizmos", visPoints.showGizmos);
		visPoints.circular = EditorGUILayout.Toggle("Circular", visPoints.circular);
		visPoints.gizmoColor = EditorGUILayout.ColorField("Gizmo Color", visPoints.gizmoColor);
		visPoints.lineColor = EditorGUILayout.ColorField("Line Color", visPoints.lineColor);
		EditorGUILayout.Space();

		if(GUILayout.Button("Add waypoint", GUILayout.Height(30)))
        {
			AddWaypoint();
		}
		if(GUILayout.Button("Clear waypoints", GUILayout.Height(30)))
        {
			ClearWaypoint();
		}
		if(placeMode)
		{
			GUILayout.Label("ADD MODE (esc to exit)");
		}
	}

	private void OnSceneGUI()
	{
		if(placeMode)
		{
			GameObject go = Selection.activeGameObject;
			if(Event.current.keyCode == KeyCode.Escape)
			{
				placeMode = false;
				Repaint();
				return;
			}
			if(go)
			{
				if(Event.current.button == 1 && Event.current.type == EventType.MouseDown)
				{
					RaycastHit hit;
					Ray ray = HandleUtility.GUIPointToWorldRay( Event.current.mousePosition );
					if (Physics.Raycast(ray, out hit, 5000))
					{
						int count = go.transform.childCount;
						GameObject wp = new GameObject("WP_" + count);
						wp.transform.position = hit.point;
						wp.transform.SetParent(go.transform);
						wp.AddComponent<Waypoint>();
					}
				}
			}
		}
	}

	private void ClearWaypoint()
	{
		GameObject go = Selection.activeGameObject;
		if(go)
		{
			int count = go.transform.childCount;
			for(int i = 0; i < count; i++)
			{
				DestroyImmediate(go.transform.GetChild(0).gameObject);
			}
		}
		placeMode = false;
	}

	private void AddWaypoint()
	{
		placeMode = true;
	}
}
