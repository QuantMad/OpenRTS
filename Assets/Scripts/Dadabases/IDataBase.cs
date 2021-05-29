using UnityEngine;

namespace OpenRTS.Assets.Scripts.Dadabases
{
    public interface IDataBase
    {
        string GetName();

        GameObject[] GetRecords();
    }
}