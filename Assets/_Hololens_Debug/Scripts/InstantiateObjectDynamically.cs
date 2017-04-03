using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

namespace UWB_Hololens_Debug {

    public class InstantiateObjectDynamically : MonoBehaviour {

        public enum ObjectOptions
        {
            Cube,
            Sphere,
            Plane
        };

        public ObjectOptions Options = ObjectOptions.Cube;
        public Vector3 SpawnPosition;

        void Awake()
        {
            SpawnPosition = new Vector3();
        }

        // Update is called once per frame
        public void ObjectInstantiate() { 
            try {
                if (Options != ObjectOptions.Cube
                    && Options != ObjectOptions.Plane
                    && Options != ObjectOptions.Sphere)
                    throw new System.Exception("Type of object not found");

                GameObject obj = null;

                switch (Options)
                {
                    case ObjectOptions.Cube:
                        obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        break;
                    case ObjectOptions.Plane:
                        obj = GameObject.CreatePrimitive(PrimitiveType.Plane);
                        break;
                    case ObjectOptions.Sphere:
                        obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        break;
                }

                if(obj != null)
                    obj.transform.Translate(SpawnPosition);
                else
                    throw new System.Exception("Null object encountered - switch statement failed.");
            }
            catch(System.Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}

#endif