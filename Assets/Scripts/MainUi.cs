using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUi : MonoBehaviour
{

    [SerializeField]
    private GameObject losePanel;

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    public void OpenLosePanel()
    {
        losePanel.GetComponent<Animator>().SetTrigger("LosePanelOpen");
    }

}
