using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HierarchyPath : MonoBehaviour {
	public static string GetPath(Transform _obj, string _pathSeparate = "/") {
		string str = "";
		List<Transform> objList = new List<Transform>();
		for (Transform cur = _obj.parent; cur; cur = cur.parent) {
			objList.Add(cur);
		}
		for(int idx = (objList.Count - 1); idx >= 0; idx--) {
			str += objList[idx].name + _pathSeparate;
		}
		str += _obj.name;
		return str;
	}
}