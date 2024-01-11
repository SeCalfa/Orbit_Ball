using UnityEngine.Networking;
using UnityEngine;
using System.Collections;
using System;

public class Database<T>
{
    public T Data { get; private set; }

    public IEnumerator Get(string uri, bool requireToken = false, string token = null, Action OnSuccess = null, Action OnFailed = null, Action OnDataModelNotFilled = null)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            if (requireToken)
                request.SetRequestHeader("Authorization", "Bearer " + token);

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogWarning(request.error);
                OnFailed?.Invoke();
            }
            else
            {
                Data = JsonUtility.FromJson<T>(request.downloadHandler.text);

                if (Data == null)
                {
                    Debug.LogWarning("Data model not filled");
                    OnDataModelNotFilled?.Invoke();
                }
                else
                {
                    Debug.Log("Data model filled");
                    OnSuccess?.Invoke();
                }
            }
        }
    }

    public IEnumerator Post(string uri, string jsonData, Action OnSuccess = null, Action OnFailed = null, Action OnDataModelNotFilled = null)
    {
        UnityWebRequest request = new UnityWebRequest(uri, "POST");

        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogWarning(request.error);
            OnFailed?.Invoke();
        }
        else
        {
            //Data = JsonUtility.FromJson<T>(request.downloadHandler.text);

            if (Data == null)
            {
                Debug.LogWarning("Data model not filled");
                OnDataModelNotFilled?.Invoke();
            }
            else
            {
                Debug.Log("Data model filled");
                OnSuccess?.Invoke();
            }
        }

        request.Dispose();
    }
}