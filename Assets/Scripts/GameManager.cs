using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }


    public void LoseGame()
    {

    }
}
