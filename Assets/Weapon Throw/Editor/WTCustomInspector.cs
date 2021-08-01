using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WeaponThrow))]
public class WTCustomInspector : Editor
{
    //get all variables
    SerializedProperty Weapon,
    CurvePoint,
    Target,
    ParentObject,
    ThrowForce,
    ThrowForceDirection,
    ThrowRotationTorque,
    ThrowRotationTorqueDirection,
    ShouldRotate,
    ReturningRotation,
    ReturnRotationSpeed,
    ReceivedRotation;

    void OnEnable()
    {
        // Fetch the objects from the GameObject script to display in the inspector
        Weapon = serializedObject.FindProperty("Weapon");
        Target = serializedObject.FindProperty("Target");
        CurvePoint = serializedObject.FindProperty("CurvePoint");
        ParentObject = serializedObject.FindProperty("ParentObj");
        ThrowForce = serializedObject.FindProperty("ThrowForce");
        ThrowForceDirection = serializedObject.FindProperty("ForceDirection");
        ThrowRotationTorque = serializedObject.FindProperty("RotationalTorque");
        ThrowRotationTorqueDirection = serializedObject.FindProperty("TorqueDirection");
        ReceivedRotation = serializedObject.FindProperty("ReceivedRotation");
        ShouldRotate = serializedObject.FindProperty("ShouldRotate");
        ReturningRotation = serializedObject.FindProperty("ReturningRotation");
        ReturnRotationSpeed = serializedObject.FindProperty("ReturnRotationSpeed");
    }

    public override void OnInspectorGUI(){
        GUILayout.Box(Resources.Load("WTCover") as Texture, GUILayout.Width(400), GUILayout.Height(212));
        WeaponThrow script = (WeaponThrow)target;

        //Weapon
        EditorGUILayout.PropertyField(Weapon, new GUIContent("Weapon", "The weapon object that will be thrown"));
        
        //Target
        EditorGUILayout.PropertyField(Target, new GUIContent("Target", "The default transform position that the weapon would return to"));

        //Curve Point
        EditorGUILayout.PropertyField(CurvePoint, new GUIContent("Curve Point", "The transform position point where the weapon will curve through before reaching the target"));

        //Parent Object
        EditorGUILayout.PropertyField(ParentObject, new GUIContent("Parent Weapon Object", "The parent object of the weapon"));

        //Throw Force
        EditorGUILayout.PropertyField(ThrowForce, new GUIContent("Throw Force", "The force power of the throw"));

        //Throw force direction
        EditorGUILayout.PropertyField(ThrowForceDirection, new GUIContent("Throw Force Direction", "The axis on which the force should be applied"));

        //Throw rotation torque
        EditorGUILayout.PropertyField(ThrowRotationTorque, new GUIContent("Throw Rotation Torque", "The power of the torque that rotates the weapon on throw"));

        //Throw rotation torque direction
        EditorGUILayout.PropertyField(ThrowRotationTorqueDirection, new GUIContent("Rotation Torque Direction", "The axis on which the rotation torque should be applied"));

        //Received rotation
        EditorGUILayout.PropertyField(ReceivedRotation, new GUIContent("Received Rotation", "The rotation of the weapon when received"));

        //Should rotate
        EditorGUILayout.PropertyField(ShouldRotate, new GUIContent("Rotate on Return", "Should the weapon rotate when returning"));

        EditorGUI.BeginDisabledGroup (script.ShouldRotate == false);
            EditorGUILayout.PropertyField(ReturningRotation, new GUIContent("Returning Rotation", "The axis to where the rotation should be applied"));
            EditorGUILayout.PropertyField(ReturnRotationSpeed ,new GUIContent("Rotation Speed", "Rotation speed of return"));
        EditorGUI.EndDisabledGroup ();

        //apply
        serializedObject.ApplyModifiedProperties();
    }
}