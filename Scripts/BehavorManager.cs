using UnityEngine;
using NodeEditorFramework;
using BehavorTreeDesigner;

public class BehavorManager : MonoBehaviour
{
	public BehaviorCanvas behavior;
	public float tickTime = 0.1f;

	private BaseBehaviorNode rootNode;

	private void Start ()
	{
		//behavior = Resources.LoadAll<BehaviorCanvas>("Saves/");

		rootNode = behavior.GetRootNode();
		//InvokeRepeating("DoTick", 0, tickTime);
		DoTick();
	}
	
	private void DoTick ()
	{
		NodeStatus status = rootNode.Tick();
		Debug.Log("Tick result: " + status);
	}
}
