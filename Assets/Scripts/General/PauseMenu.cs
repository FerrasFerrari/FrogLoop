using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject fundo;
    public Button BtnResume;
    public Button BtnQuit;
    public TMP_Text Pause;
    public TMP_Text Resume;
    public TMP_Text Quit;
    // Start is called before the first frame update
    void Start()
    {
        fundo.SetActive(false);
        BtnResume.enabled = false;
        BtnQuit.enabled = false;
        Pause.enabled = false;
        Resume.enabled = false;
        Quit.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            fundo.SetActive(true);
            BtnResume.enabled = true;
            BtnQuit.enabled = true;
            Pause.enabled = true;
            Resume.enabled = true;
            Quit.enabled = true;
        }
    }
    public void ResumeBtn()
    {
        Time.timeScale = 1;
        fundo.SetActive(false);
        BtnResume.enabled = false;
        BtnQuit.enabled = false;
        Pause.enabled = false;
        Resume.enabled = false;
        Quit.enabled = false;
    }
    
    public void QuitBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
