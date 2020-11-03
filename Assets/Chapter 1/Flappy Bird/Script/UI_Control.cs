using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Control : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject pnlGameOver;
    [SerializeField] private Bird bird;
    [SerializeField] private int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.IsDead())
        {
            pnlGameOver.SetActive(true);
            //score = bird.finalScore();
            //scoreText.text = score.ToString();
            scoreText.text = "Score : "+bird.finalScore().ToString();
        }
    }
}
