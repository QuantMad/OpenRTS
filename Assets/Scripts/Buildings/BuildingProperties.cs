using System;
using UnityEngine;

namespace Buildings
{
    [Serializable]
    public abstract class BuildingProperties 
    {
        [SerializeField]
        public const int MaxHealth = 100;
        
        [SerializeField]
        internal string _name;
        public string Name => _name;

        [SerializeField]
        [Range(0, 999999)]
        internal int _cost;
        public int Cost => _cost;

        [SerializeField]
        [Range(0, MaxHealth)]
        private int _health = MaxHealth;
        public int Health {
            get => _health;
            set {
                _health = value < 0 ? 0 : value > MaxHealth ? MaxHealth : value;
            }
        }

        public BuildingProperties() 
        {
            _name = "Unnamed";
            _cost = 0;
        }

        public BuildingProperties(string name, int cost) 
        {
            _name = name;
            _cost = cost;
        }

        public override string ToString()
        {
            return $"Name:{_name}, Cost:{_cost}, Health:{_health}/{MaxHealth}";
        }
    }
}
