using System.Collections.Generic;
using UnityEngine;
using System;

namespace BehavorTreeDesigner
{
	public class BehaviorBlackboard
	{
		public Dictionary<string, object> blackboard;

		public BehaviorBlackboard()
		{
			blackboard = new Dictionary<string, object>();
		}

		public void Add<T>(string key, T obj) where T : class
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

		public void Add(string key, int obj)
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

		public T Get<T>(string key) where T : class
		{
			object obj;
			blackboard.TryGetValue(key, out obj);
			return obj as T;
		}

		public int Get(string key)
		{
			object obj;
			blackboard.TryGetValue(key, out obj);
			if(obj == null)
			{
				return -1;
			}
			else
			{
				return (int)obj;
			}
		}
	}
}
