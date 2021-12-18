using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool oldKey;
    public bool newKey;
    public bool puzzleKeyResove;
    public static GameController instanceGame;

    void Awake()
    {
        instanceGame = this;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
