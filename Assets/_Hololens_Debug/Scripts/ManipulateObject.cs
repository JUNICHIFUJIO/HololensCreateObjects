using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if !UNITY_EDITOR && UNITY_WSA_10_0
using UnityEngine.VR.WSA.Input;

namespace UWB_Hololens_Debug
{
    public class ManipulateObject : MonoBehaviour {

        public GameObject gazeCursor;
        public 

        // Use this for initialization
        void Start () {
            gazeCursor = GameObject.Find("Cursor");

            if(gazeCursor == null)
            {
                throw new System.Exception("Gaze cursor not found");
            }
        }
	
        // Update is called once per frame
        void Update () {
		// Need to generate cubes by voice - still need to write this script
        // Need to attach to object (Gesturemanager and voicecommand manager)

        }
    }
}

#endif