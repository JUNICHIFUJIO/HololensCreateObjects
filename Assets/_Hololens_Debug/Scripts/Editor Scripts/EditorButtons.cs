using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

namespace UWB_Hololens_Debug
{
    [CustomEditor(typeof(InstantiateObjectDynamically))]
    public class EditorButtons : Editor
    {

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            InstantiateObjectDynamically myScript = (InstantiateObjectDynamically)target;
            if (GUILayout.Button("Instantiate"))
            {
                myScript.ObjectInstantiate();
            }
        }
    }
}

#endif