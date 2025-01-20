using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    Button StartButton;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(sceneName: "Level0");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
