using UnityEngine;

[ExecuteInEditMode]
public class Waypoints : MonoBehaviour
{
	public bool showGizmos = true;
	public bool circular = false;
	public Color gizmoColor = Color.cyan;
	public Color lineColor = Color.cyan;

	public void OnDrawGizmos()
	{
		if(showGizmos)
		{
			int count = transform.childCount;
			for(int i = 0; i < count; i++)
			{
				Transform point = transform.GetChild(i);
				int indexNext = i + 1;
				if(indexNext >= transform.childCount)
					indexNext = 0;
				Transform pointNext = transform.GetChild(indexNext);

				Vector3 pos = point.position;
				pos.y += 0.5f;
				Vector3 posNext = pointNext.position;
				posNext.y += 0.5f;
				Gizmos.color = gizmoColor;
				if(i == 0)
					Gizmos.DrawCube(pos, new Vector3(0.4f, 0.4f, 0.4f));
				else
					Gizmos.DrawSphere(pos, 0.2f);


				if(indexNext == 0 && !circular)
					continue;

				Gizmos.color = lineColor;
				Gizmos.DrawLine(pos, posNext);
			}
		}
	}
}
