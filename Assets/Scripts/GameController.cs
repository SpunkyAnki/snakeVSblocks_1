using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public enum GameState { MENU, GAME, GAMEOVER}
    public static GameState gameState;

    [Header("Managers")]
    public SnakeMovement SM;
    public BlockManager BM;

    [Header("CanvasGroup")]
    public CanvasGroup MENU_CG;
    public CanvasGroup GAME_CG;
    public CanvasGroup GAMEOVER_CG;

    [Header("Score Management")]
    public Text ScoreText;
    public Text MenuScoreText;
    public Text BestScoreText;
    public static int SCORE;
    public static int BESTSCORE;

    [Header("SomeBool")]
    bool speedAdded;


    private void Start()
    {
        SetMenu();
        SCORE = 0;

        speedAdded = false;

        BESTSCORE = PlayerPrefs.GetInt("BESTSCORE");
    }

    private void Update()
    {
        ScoreText.text = SCORE + "";
        MenuScoreText.text = SCORE + "";

        if(SCORE < BESTSCORE)
        {
            BESTSCORE = SCORE;

            BestScoreText.text = BESTSCORE + "";

            if (!speedAdded && SCORE > 150)
            {
                SM.speed++;
                speedAdded = true;
            }
        }
    }

    public void SetMenu()
    {
        gameState = GameState.MENU;
        EnableCG(MENU_CG);
        DisableCG(GAME_CG);
        DisableCG(GAMEOVER_CG);

    }

    public void SetGameover()
    {
        gameState = GameState.GAMEOVER;
        EnableCG(MENU_CG);
        DisableCG(GAME_CG);
        DisableCG(GAMEOVER_CG);

        //foreach (GameObject g in GameObject.FindGameObjectWithTag("Box"))
        //{
        //    Destroy(g);
        //}

        //foreach (GameObject g in GameObject.FindGameObjectWithTag("Bar"))
        //{
        //    Destroy(g);
        //}

        //foreach (GameObject g in GameObject.FindGameObjectWithTag("SimpleBox"))
        //{
        //    Destroy(g);
        //}
        
        //foreach (GameObject g in GameObject.FindGameObjectWithTag("Snake"))
        //{
        //    Destroy(g);
        //}

        SM.SpawnBodyParts();
        //BM.SetPreviousPosAfterGameover();

        speedAdded = false;
        SM.speed = 3;

        PlayerPrefs.SetInt ("BESTSCORE", BESTSCORE);
        BM.SimpleBoxPositions.Clear();

    }

    public void EnableCG(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.blocksRaycasts = true;
        cg.interactable = true;
    }

    public void DisableCG (CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable= false; 
        cg.blocksRaycasts = false;
    }

    public void SetGame()
    {
        gameState = GameState.GAME;

        EnableCG(GAME_CG);
        DisableCG(MENU_CG);
        DisableCG(GAMEOVER_CG);

        SCORE = 0;
    }
}
