using System;
using UnityEngine;

namespace OpenRTS.Assets.Scripts.Buildings
{
    [Serializable]
    public abstract class Building : MonoBehaviour
    {
        [SerializeField]
        public string Name = "Undefined";

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public abstract bool Export(string path);
    }
}