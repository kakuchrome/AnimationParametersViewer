using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using VRC.SDK3.Avatars.Components;

public class PAPV : EditorWindow
{
    [MenuItem("APV/View")]
    public static void OpenWindow()
    {
        GetWindow<PAPV>(false, "AnimationParametersViewer", true);
    }
    private void Update()
    {
        if (EditorApplication.isPlaying)
        {
            Repaint();
        }
    }
    bool _isFolded = true;
    string stxt;
    void OnGUI()
    {
        minSize = new Vector2(350, 400);
        if (!EditorApplication.isPlaying)
        {
            EditorGUILayout.LabelField("Only works in Play mode.");
            return;
        }
        VRCAvatarDescriptor[] descriptors = FindObjectsOfType<VRCAvatarDescriptor>();
        VRCAvatarDescriptor targetDescriptor = null;
        foreach (VRCAvatarDescriptor descriptor in descriptors)
        {
            if (!descriptor.gameObject.name.Contains("ShadowClone") && !descriptor.gameObject.name.Contains("MirrorReflection"))
            {
                targetDescriptor = descriptor;
            }
        }
        if (targetDescriptor == null)
        {
            EditorGUILayout.LabelField("Target Avatar: Not Found");
            return;
        }
        EditorGUILayout.LabelField("Target Avatar: " + targetDescriptor.gameObject.name);
        var animator = targetDescriptor.gameObject.GetComponent<Animator>();
        var animatorParameters = animator.parameters;
        int[] columnsizes = { 200, 50, 100 };
        if (animatorParameters != null)
        {

            stxt = EditorGUILayout.TextField("Search: ", stxt);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Name", GUILayout.Width(columnsizes[0]));
            EditorGUILayout.LabelField("Type", GUILayout.Width(columnsizes[1]));
            EditorGUILayout.LabelField("Value", GUILayout.Width(columnsizes[2]));
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginVertical("box");
            foreach (var param in animatorParameters)
            {
                if (!param.name.Contains(stxt)) { continue; }
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(param.name, GUILayout.Width(columnsizes[0]));
                EditorGUILayout.LabelField(param.type.ToString(), GUILayout.Width(columnsizes[1]));
                string valueText = "";
                switch (param.type)
                {
                    case AnimatorControllerParameterType.Bool:
                        valueText = animator.GetBool(param.name).ToString();
                        break;
                    case AnimatorControllerParameterType.Float:
                        valueText = animator.GetFloat(param.name).ToString();
                        break;
                    case AnimatorControllerParameterType.Int:
                        valueText = animator.GetInteger(param.name).ToString();
                        break;
                }
                EditorGUILayout.LabelField(valueText, GUILayout.Width(columnsizes[2]));
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
        }



        //折りたたみUIを表示、現在開いているかを取得
        _isFolded = EditorGUILayout.Foldout(_isFolded, "見たいParametersがない場合");
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.wordWrap = true;
        //開いている時はGUI追加
        if (_isFolded)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.LabelField("このツールはAvatars3.0EmulatorでDefaultAnimatorToDebugに設定されているレイヤのParaemetersを表示します。この値は通常Baseレイヤーになっています。多くの場合、FXに変更する必要があります。この変更はツールバー/Tools/Avatars3.0Emulator/Settingsから行って下さい。", style);
            EditorGUI.indentLevel--;
        }
    }
}