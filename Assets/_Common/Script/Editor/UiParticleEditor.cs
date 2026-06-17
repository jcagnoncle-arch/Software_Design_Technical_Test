using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Made by Julien Cagnoncle

[CustomEditor(typeof(UiParticle))]
[CanEditMultipleObjects]

public class UiParticleEditor : Editor
{

    private SerializedProperty propertyDuration = default;
    private SerializedProperty propertySplitAnimationCurve = default;
    private SerializedProperty propertyXMovementCurve = default;
    private SerializedProperty propertyY = default;
    private SerializedProperty propertyResizeParticle = default;
    private SerializedProperty propertyScaleBoundaries = default;
    private SerializedProperty propertyScaleCurve = default;
    private UiParticle uiParticleTarget = default;

    protected virtual void OnEnable()
    {
        uiParticleTarget = (UiParticle)target;
        propertyDuration = serializedObject.FindProperty("duration");
        propertySplitAnimationCurve = serializedObject.FindProperty("splitAnimationCurve");
        propertyXMovementCurve = serializedObject.FindProperty("xMovementCurve");
        propertyY = serializedObject.FindProperty("yMovementCurve");
        propertyResizeParticle = serializedObject.FindProperty("resizeParticle");
        propertyScaleBoundaries = serializedObject.FindProperty("scaleBoundaries");
        propertyScaleCurve = serializedObject.FindProperty("scaleCurve");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();


        EditorGUILayout.PropertyField(propertyDuration);


        GUILayout.Space(10);
        GUILayout.Label("Optional Settings", EditorStyles.boldLabel);
        GUILayout.Space(10);

        EditorGUILayout.PropertyField(propertySplitAnimationCurve);

        //Split the curve to make the particle more modular
        if (uiParticleTarget.splitAnimationCurve)
        {
            EditorGUILayout.PropertyField(propertyXMovementCurve);
            EditorGUILayout.PropertyField(propertyY);
        }
        else
        {
            EditorGUILayout.PropertyField(propertyXMovementCurve);
        }

        //add the possibility to change the size
        EditorGUILayout.PropertyField(propertyResizeParticle);

        if (uiParticleTarget.resizeParticle)
        {
            EditorGUILayout.PropertyField(propertyScaleBoundaries);
            EditorGUILayout.PropertyField(propertyScaleCurve);
        }
      
        serializedObject.ApplyModifiedProperties();
    }
}
