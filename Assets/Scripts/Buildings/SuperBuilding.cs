using System;
using UnityEngine;

namespace Buildings
{
    public abstract class SuperBuilding : MonoBehaviour
    {
        public abstract void SetProperties(string json);
    }
}
