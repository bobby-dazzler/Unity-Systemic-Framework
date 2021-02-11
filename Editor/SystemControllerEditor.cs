using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnitySystemicFramework;

[CustomEditor (typeof(SystemController), true)]
public class SystemControllerEditor : Editor {

	//DrawDefaultInspector();

	private static GUIContent startLoopButton = new GUIContent("Start", "Start Loop");
	private static GUIContent stopLoopButton = new GUIContent("Stop", "Stop Loop");

	private static GUILayoutOption miniButtonWidth = GUILayout.Width(30f);

 	public override void OnInspectorGUI() {

		DrawDefaultInspector();

		EditorGUILayout.BeginVertical();
		//EditorGUILayoutUtility.HorizontalLine(new Vector2(20f, 20f));
		EditorGUILayout.EndVertical();

		EditorGUILayout.LabelField("SubSystem Management", EditorStyles.boldLabel);

		SystemController controller = (SystemController)target;
		
		serializedObject.Update();
		
		SerializedProperty subSystemsList = serializedObject.FindProperty("subSystems");
		SerializedProperty systemsStatusList = serializedObject.FindProperty("subSystemRunning");

		for (int i = 0; i < subSystemsList.arraySize; i++) {
			EditorGUILayout.BeginHorizontal();
			if (systemsStatusList.GetArrayElementAtIndex(i) != null) {
				EditorGUILayout.PropertyField(subSystemsList.GetArrayElementAtIndex(i), GUIContent.none);

				bool isRunning = systemsStatusList.GetArrayElementAtIndex(i).boolValue;
				GUI.enabled = !isRunning;
				if (GUILayout.Button(startLoopButton, miniButtonWidth)) {
					controller.RunGameLoopAtIndex(i);
				}
				GUI.enabled = isRunning;
				if (GUILayout.Button(stopLoopButton, miniButtonWidth)) {
					controller.StopGameLoopAtIndex(i);
				}
			}
			EditorGUILayout.EndHorizontal();
		}

		//EditorGUILayout.PropertyField(serializedObject.FindProperty("debugMode"));

		serializedObject.ApplyModifiedProperties(); 

	}

} 
