using UnityEngine;
using System;
using System.Collections;
using AdvancedInspector;

public abstract class SingletonLogScrollBase<T> : MonoBehaviour where T : SingletonLogScrollBase<T>
{
	protected static readonly string[] findTags =
	{
		"TagSingleton",
	};

	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				Type type = typeof(T);

				foreach (var tag in findTags)
				{
					GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

					for (int j = 0; j < objs.Length; j++)
					{
						instance = (T)objs[j].GetComponent(type);
						if (instance != null)
							return instance;
					}
				}
			}

            return instance;
		}
	}
	protected static T instance;

	protected bool CheckInstance()
	{
		bool found = false;

		foreach (string t in findTags)
		{
			if (tag == t)
				found = true;
		}

		if (!found) //tag != "singleton")
		{
			string errMsg = "";

			foreach (string t in findTags)
			{
				errMsg += ("/" + t);
			}
			
			Debug.Assert(false, "Singleton's tag should be " + errMsg + "/ !", transform);
		}

        if (instance == null)
		{
			instance = (T)this;
            return true;
		}
		else if (Instance == this)
		{
            return true;
		}

		Destroy(gameObject);
		return false;
	}
}
