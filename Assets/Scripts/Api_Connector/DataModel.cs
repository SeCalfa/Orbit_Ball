using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataModel : MonoBehaviour
{

    [System.Serializable]
    public struct KeyValue
    {
        public string fieldName;
        public string value;
    }

}
