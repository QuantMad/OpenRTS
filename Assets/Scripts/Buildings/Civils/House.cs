using System;
using UnityEngine;

namespace OpenRTS.Assets.Scripts.Buildings.Civils
{
    [Serializable]
    public class House : Civil
    {
        [SerializeField]
        [Range(1, 254)]
        private byte Appartaments = 1;
        public override bool Export(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}