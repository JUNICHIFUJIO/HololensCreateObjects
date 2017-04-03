using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 #if !UNITY_EDITOR && UNITY_WSA_10_0
using UnityEngine.VR.WSA.Input;

namespace UWB_Hololens_Debug
{
    public class GazeCursor : MonoBehaviour
    {
        private MeshRenderer meshRenderer;

        void Awake()
        {
            meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
        }

        void Update()
        {
            var headPos = Camera.main.transform.position;
            var gazeDir = Camera.main.transform.forward;

            RaycastHit hitInfo;

            if(Physics.Raycast(headPos, gazeDir, out hitInfo))
            {
                meshRenderer.enabled = true;
                this.transform.position = hitInfo.point;
                this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            }
            else
            {
                meshRenderer.enabled = false;
            }
        }
    }
}

#endif