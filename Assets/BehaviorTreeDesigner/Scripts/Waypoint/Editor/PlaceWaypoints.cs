using UnityEngine;
using UnityEditor;

public class PlaceWaypoints : Editor
{
	[MenuItem ("Window/Behavior Tree Designer/Create Waypoint")]
    static void CreateWaypoint ()
	{
		GameObject go = new GameObject("Waypoints");
		go.AddComponent<Waypoints>();
    }
}
