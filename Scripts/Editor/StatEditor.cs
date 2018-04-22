using System;
using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;


public class AttributeEditor : EditorWindow {

    Vector2 scrollPosition;
    public CharacterData _data;

    [MenuItem("Window/Attribute Editor %#e")]
    static void Init() {
        EditorWindow.GetWindow(typeof(AttributeEditor));
    }

    void OnGUI() {
        using (var scrollView = new EditorGUILayout.ScrollViewScope(scrollPosition, GUILayout.Width(this.position.width), GUILayout.Height(this.position.height))) {
            EditorGUILayout.LabelField("Welcome in the Attribute editor", EditorStyles.boldLabel);
            scrollPosition = scrollView.scrollPosition;

            EditorGUI.BeginChangeCheck();
            GUILayout.BeginVertical();
            _data = (CharacterData)EditorGUILayout.ObjectField("Data", _data, typeof(CharacterData), false);

            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Value", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Min", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Max", EditorStyles.boldLabel);
            GUILayout.EndHorizontal();

            SerializedObject serializedObject = new SerializedObject(_data);
            serializedObject.Update();
            SerializedProperty list = serializedObject.FindProperty("_attributes");

            for (int i = 0; i < list.arraySize; i++) {
                var sublist = list.GetArrayElementAtIndex(i).FindPropertyRelative("AttributModifiers");
                var baseValue = list.GetArrayElementAtIndex(i).FindPropertyRelative("baseValue");
                var min = list.GetArrayElementAtIndex(i).FindPropertyRelative("min");
                var max = list.GetArrayElementAtIndex(i).FindPropertyRelative("max");
                GUILayout.BeginHorizontal();

                GUILayout.BeginVertical();
                EditorGUIUtility.labelWidth = 0f;
                EditorGUILayout.PropertyField(baseValue, GUIContent.none, GUILayout.Width(100.0f));
                GUILayout.EndVertical();

                GUILayout.BeginVertical();
                EditorGUIUtility.labelWidth = 0f;
                EditorGUILayout.PropertyField(min, GUIContent.none, GUILayout.Width(100.0f));
                GUILayout.EndVertical();

                GUILayout.BeginVertical();
                EditorGUILayout.PropertyField(max,  GUIContent.none, GUILayout.Width(100.0f));
                GUILayout.EndVertical();

                //EditorGUILayout.PropertyField(sublist, true);
                GUILayout.EndHorizontal();
            }

            serializedObject.ApplyModifiedProperties();

            GUILayout.EndVertical();
            if (EditorGUI.EndChangeCheck()) {
                Undo.RecordObject(_data, "Update character data");
                EditorUtility.SetDirty(_data);
            }
        }
    }
}
