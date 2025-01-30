using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    Button StartButton;

    [SerializeField]
    GameObject transition;

    [SerializeField]
    Canvas Canvas;

    [SerializeField]
    GameObject background, cloud1, cloud2;
    // Start is called before t he first frame update
    void Start()
    {
        // Initial Animation
        Vector2 bgPos = background.transform.position;
        Vector2 cloud1Pos = cloud1.transform.position;
        Vector2 cloud2Pos = cloud2.transform.position;

        background.transform.position = new Vector2(bgPos.x, bgPos.y-100);
        cloud1.transform.position = new Vector2(cloud1Pos.x-1000, cloud1Pos.y);
        cloud2.transform.position = new Vector2(cloud2Pos.x+1000, cloud2Pos.y);
        LeanTween.move(background, bgPos, 2).setEaseOutSine();
        LeanTween.move(cloud1, cloud1Pos, 2).setEaseOutSine();
        LeanTween.move(cloud2, cloud2Pos, 2).setEaseOutSine();

        // Play Button + Transition
        Vector2 startPos = new Vector2(0, 0);
        StartButton.onClick.AddListener(() =>
        {
            int rowCount = Screen.width / 50;
            int colCount = Screen.width /50 ;
            for (int j = 0; j < colCount; j++)
            {
                for (int i = 0; i < rowCount;  i++)
                {
                    GameObject newBlock = Instantiate(transition);
                    newBlock.transform.position = new Vector2(startPos.x + (i*70),startPos.y + (70*j));
                    newBlock.transform.SetParent(Canvas.transform);
                    newBlock.transform.localScale = Vector3.zero;
                    LeanTween.scale(newBlock, Vector3.one*1f, 5f).setEaseOutElastic().setDelay(0.1f * j);
                }

            }
            
            StartCoroutine(CallingScene());
        });



    }

    IEnumerator CallingScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(sceneName: "Level0");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
