using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class GetMethod : MonoBehaviour
{

    [SerializeField]
    private string uri;

    private DataModel.KeyValue[] KeyValue = new DataModel.KeyValue[]
    {
        new DataModel.KeyValue() { fieldName = "key", value = "score" },
        new DataModel.KeyValue() { fieldName = "value", value = "0" }
    };

    public void Get(int score)
    {
        StartCoroutine(GetData(score));
    }

    public void SetName(string name)
    {
        KeyValue[0].value = name;
    }

    private IEnumerator GetData(int score)
    {
        WWWForm form = new WWWForm();
        FillFields(form, score);

        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
                Debug.LogError("Error: " + request.error);
            else
                Debug.Log("Success!");
        }
    }

    private void FillFields(WWWForm form, int score)
    {
        int number;

        foreach (var kv in KeyValue)
        {
            try
            {
                number = Convert.ToInt32(kv.value);
                number = score;
                form.AddField(kv.fieldName, number);
            }
            catch
            {
                form.AddField(kv.fieldName, kv.value);
            }
        }
    }

}
