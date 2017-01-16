using UnityEngine;
using NodeEditorFramework;
using BehavorTreeDesigner;

public class BehaviorManager : MonoBehaviour
{
	public string path;
	public float tickTime = 0.1f;
	public Transform agent;

	private BaseBehaviorNode rootNode;
	private BehaviorBlackboard data;

	private void Start ()
	{
		string response = IsValid();
		if(response != "")
		{
			Debug.LogError(response);
			return;
		}

		BehaviorCanvas behavior = Resources.Load<BehaviorCanvas>(path);
		if(behavior == null)
		{
			Debug.LogError("Behavor Tree Designer\nNo valid path!");
			return;
		}
		data = new BehaviorBlackboard();
		data.Add<Transform>("Agent", agent);
		rootNode = behavior.GetRootNode();
		rootNode.Init(data);
		InvokeRepeating("DoTick", 0, tickTime);
	}
	
	private void DoTick ()
	{
		rootNode.Tick(data);
	}

	private string IsValid()
	{
		if(path == "")
		{
			return "Behavor Tree Designer\nNo path given!";
		}
		else if(agent == null)
		{
			return "Behavor Tree Designer\nNo agent assigned!";
		}
		else
		{
			return "";
		}
	}
}
