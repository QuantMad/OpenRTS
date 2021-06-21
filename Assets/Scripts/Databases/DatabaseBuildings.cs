using Buildings;
using UnityEngine;

namespace Databases
{
    public class DatabaseBuildings : Database
    {

        internal override GameObject LoadObject<T>(string path, string name)
        {
            var building = base.LoadObject<T>(path, name);
            string json = loadJson(path, name);
            building.AddComponent<T>().DeserializeProperties(json);
            building.AddComponent<BoxCollider>().isTrigger = true;
            building.AddComponent<Rigidbody>().isKinematic = true;
            building.layer = 6;

            return building;
        }
    }
}
