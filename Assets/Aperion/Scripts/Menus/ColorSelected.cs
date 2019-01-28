using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColorSelected : EditorWindow
{

    private Color color;

    [MenuItem("Aperion Studios/Color Selected")]
    public static void ShowWindow()
    {
        GetWindow<ColorSelected>("Color Selected");
    }

    private void OnGUI()
    {
        GUILayout.Label("Color The Selected Objects", EditorStyles.boldLabel);

        color = EditorGUILayout.ColorField("Color", color);

        if (GUILayout.Button("Color Selected"))
        {
            Colorize();   
        }
    }

    private void Colorize()
    {
        var objs = Selection.gameObjects;

        foreach (var o in objs)
        {
            Renderer rend = o.GetComponent<Renderer>();

            if (rend != null)
            {
                rend.sharedMaterial.color = color;
            }

        }
    }
}
