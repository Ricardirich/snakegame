using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float speed = 1f;
    Rigidbody2D myRB;
    Vector3 dir = new Vector3(0, 0, 0);

    public int Playernumber = 2;
    private enum GameState { Playing, Paused, GameOver }
    private GameState currentState;

    void Start()
    {
        currentState = GameState.Playing;
    }

    void Update()
    {
        State();
        if (currentState == GameState.Paused || currentState == GameState.GameOver)
            return;
        MoveSnake();
    }

    void State()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (currentState == GameState.Playing)
                currentState = GameState.Paused;
            else if (currentState == GameState.Paused)
                currentState = GameState.Playing;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    Vector3 Direction()
    {
        Vector3 v = Vector3.zero;

        if (Input.GetKey(KeyCode.I))
        { v += Vector3.up; }
        else if (Input.GetKey(KeyCode.K))
        { v += Vector3.down; }

        if (Input.GetKey(KeyCode.L))
        { v += Vector3.right; }
        else if (Input.GetKey(KeyCode.J))
        { v += Vector3.left; }

        return v;
    }

    void MoveSnake()
    {
        dir = Direction();
        transform.Translate(dir * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            GameManager.Instance.AddScore(Playernumber, 5);
            
        }
        else if (other.CompareTag("Wall") || other.CompareTag("Player"))
        {
            currentState = GameState.GameOver;
        }
    }

    private void RestartGame()
    {
        transform.position = Vector3.zero;
        dir = Vector3.zero;
        currentState = GameState.Playing;
    }
}
