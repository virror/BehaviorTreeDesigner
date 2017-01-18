using System.Collections.Generic;
using UnityEngine;
using System;

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

		//Local blackboard
		public void AddClass<T>(string key, T obj) where T : class
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

		public void AddInt(string key, int obj)
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

		public void AddFloat(string key, float obj)
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

		public void AddBool(string key, bool obj)
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

		public T GetClass<T>(string key) where T : class
		{
			object obj;
			blackboard.TryGetValue(key, out obj);
			return obj as T;
		}

		public int GetInt(string key)
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

		public float GetFloat(string key)
		{
			object obj;
			blackboard.TryGetValue(key, out obj);
			if(obj == null)
			{
				return -1;
			}
			else
			{
				return (float)obj;
			}
		}

		public bool GetBool(string key)
		{
			object obj;
			blackboard.TryGetValue(key, out obj);
			if(obj == null)
			{
				return false;
			}
			else
			{
				return (bool)obj;
			}
		}

		//Global blackboard
		public void AddGlobalClass<T>(string key, T obj) where T : class
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

		public void AddGlobalInt(string key, int obj)
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

		public void AddGlobalFloat(string key, float obj)
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

		public void AddGlobalBool(string key, bool obj)
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

		public T GetGlobalClass<T>(string key) where T : class
		{
			object obj;
			globalBlackboard.TryGetValue(key, out obj);
			return obj as T;
		}

		public int GetGlobalInt(string key)
		{
			object obj;
			globalBlackboard.TryGetValue(key, out obj);
			if(obj == null)
			{
				return -1;
			}
			else
			{
				return (int)obj;
			}
		}

		public float GetGlobalFloat(string key)
		{
			object obj;
			globalBlackboard.TryGetValue(key, out obj);
			if(obj == null)
			{
				return -1;
			}
			else
			{
				return (float)obj;
			}
		}

		public bool GetGlobalBool(string key)
		{
			object obj;
			globalBlackboard.TryGetValue(key, out obj);
			if(obj == null)
			{
				return false;
			}
			else
			{
				return (bool)obj;
			}
		}
	}
}
