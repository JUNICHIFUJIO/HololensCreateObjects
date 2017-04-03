// Simple debug that lets you look at an object, 
// tap it (not hold) to select it, then drag it to whereever you're 
// looking

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if !UNITY_EDITOR && UNITY_WSA_10_0
using UnityEngine.VR.WSA.Input;

namespace UWB_Hololens_Debug
{
    public class GestureManager : MonoBehaviour
    {
        public static GestureManager Instance { get; private set; }
        public static bool Selected;
        public GameObject FocusedObject { get; private set; }

        GestureRecognizer recognizer;
        
        // Use this for initialization
        void Awake()
        {
            Instance = this;

            recognizer = new GestureRecognizer();
            recognizer.TappedEvent += new GestureRecognizer.TappedEventDelegate(onSelectTrigger);

            Selected = false;
        }

        public void onSelectTrigger(UnityEngine.VR.WSA.Input.InteractionSourceKind source, int tapCount, UnityEngine.Ray headRay)
        {
            if (FocusedObject != null)
            {
                FocusedObject.SendMessageUpwards("OnSelect");
                Selected = !Selected;
            }
        }

        // Update is called once per frame
        void Update()
        {
            GameObject oldFocusedObject = FocusedObject;
            var headPos = Camera.main.transform.position;
            var gazeDir = Camera.main.transform.forward;
            
            RaycastHit hitInfo;

            if (Selected)
            {
                if (Physics.Raycast(headPos, gazeDir, out hitInfo))
                {
                    // Change the position
                    RaycastHit meshInfo;
                    if (Physics.Raycast(FocusedObject.transform.position, gazeDir, out meshInfo))
                    {
                        Vector3 pullVector = meshInfo.point - FocusedObject.transform.position;
                        Vector3 updatePos = hitInfo.point + pullVector;
                        FocusedObject.transform.position = updatePos;
                    }

                    // Change the angle of rotation
                    FocusedObject.transform.LookAt(Camera.main.transform);
                }
                else
                {
                    FocusedObject.transform.position = headPos + gazeDir * 3.1f;
                }
            }
            else
            {
                if (Physics.Raycast(headPos, gazeDir, out hitInfo))
                {
                    FocusedObject = hitInfo.collider.gameObject;
                }
                else
                {
                    FocusedObject = null;
                }

                if (FocusedObject != oldFocusedObject)
                {
                    // Cancels pending gesture events and stops capturing gestures
                    recognizer.CancelGestures();
                    // Restarts capturing gestures
                    recognizer.StartCapturingGestures();
                }
            }
        }
    }
}

#endif