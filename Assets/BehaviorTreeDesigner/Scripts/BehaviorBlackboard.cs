using System.Collections.Generic;

namespace BehavorTreeDesigner
{
	public class BehaviorBlackboard
	{
		public Dictionary<string, object> blackboard;

		public static Dictionary<string, object> globalBlackboard;

		public BehaviorBlackboard()
		{
			blackboard = new Dictionary<string, object>();
			globalBlackboard = new Dictionary<string, object>();
		}

		public void Add(string key, object obj)
		{
			if(!blackboard.ContainsKey(key))
			{
				blackboard.Add(key, obj);
			}
			else
			{
				blackboard[key] = obj;
			}
		}

		public object Get(string key)
		{
			object obj;
			blackboard.TryGetValue(key, out obj);
			return obj;
		}

		//Global blackboard
		public void AddGlobal(string key, object obj)
		{
			if(!globalBlackboard.ContainsKey(key))
			{
				globalBlackboard.Add(key, obj);
			}
			else
			{
				globalBlackboard[key] = obj;
			}
		}

		public object GetGlobal(string key)
		{
			object obj;
			globalBlackboard.TryGetValue(key, out obj);
			return obj;
		}
	}
}
