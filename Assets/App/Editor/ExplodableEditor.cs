using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AperionStudios.ClimberVR
{
    [CustomEditor(typeof(Explodable))]
    public class ExplodableEditor : Editor
    {
        public SerializedProperty
            explode_Time;

        private void OnEnable()
        {
            explode_Time = serializedObject.FindProperty("explodeTime");
        }

        public override void OnInspectorGUI()
        {
            //serializedObject.Update();

            base.OnInspectorGUI();

            Explodable explodable = (Explodable)target;

            GUILayout.Space(5);
            GUILayout.Label("Custom Explodable Settings", EditorStyles.boldLabel);

            switch (explodable.explodeType)
            {
                case Explodable.ExplodeType.TimedExplosion:
                    EditorGUILayout.PropertyField(explode_Time, new GUIContent("Explode Time"));
                    break;
            }

            GUILayout.Space(20);


            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Explode"))
            {
                explodable.Explode();
            }

            if (GUILayout.Button("Reset"))
            {
                //grenade.GrenadeExplode();
            }

            GUILayout.EndHorizontal();

        }
    }
}
