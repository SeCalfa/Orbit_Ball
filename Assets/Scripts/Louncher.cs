using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Louncher : MonoBehaviour
{
    [SerializeField]
    private GameObject api;
    [SerializeField]
    private TMP_InputField playerName;

    private GameObject Api;

    private void Awake()
    {
        Api = Instantiate(api);
        DontDestroyOnLoad(Api);
    }

    public void Clear()
    {
        playerName.text = string.Empty;
    }

    public void Play()
    {
        if(playerName.text.Length < 3)
        {
            Clear();
            return;
        }

        Api.GetComponent<GetMethod>().SetName(playerName.text);
        SceneManager.LoadScene("Game");
    }
}
