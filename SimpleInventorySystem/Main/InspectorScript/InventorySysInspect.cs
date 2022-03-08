using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InventorySystem))]
public class InventorySysInspect : Editor
{
    private InventorySystem inventory;

	private void OnEnable()
	{	
		inventory = (InventorySystem)target;
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		EditorGUILayout.Space(10);

		if (GUILayout.Button("Clear all item"))
		{
			inventory.ClearAll();
		}
	}
}
