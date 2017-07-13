using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GUI_Health gui_Health;
    public GameObject player;
    public LevelGenerator levelGenerator;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        InitGame();
    }

    // Use this for initialization
    void Start()
    {

    }

    void InitGame()
    {
        AttackList.Start();
        gui_Health = GetComponent<GUI_Health>();
        gui_Health.player = player.GetComponent<Player>();
        levelGenerator = GetComponent<LevelGenerator>();
        levelGenerator.GenerateLevel(0, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
