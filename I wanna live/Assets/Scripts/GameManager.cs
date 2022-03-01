using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instanse;




    [SerializeField]
    public Sprite OneStarSprite;

    [SerializeField]
    public Sprite TwoStarSprite;
    [SerializeField]
    public Sprite ThreeStarSprite;

    [SerializeField]
    public int jumpPower;
    public float player_min_speed;
    public float player_current_speed;
    public float player_max_speed;
    public float hunter_current_speed;


    [HideInInspector]
    public bool isPlayerJump;


    [HideInInspector]
    public float hunter_width;

    [HideInInspector]
    public float player_width;


    public GameObject player;
    public GameObject hunter;

    [HideInInspector]
    public Vector2 player_jump_position;

    [HideInInspector]
    public Vector2 player_respown;
    [HideInInspector]
    public Vector2 hunter_respown;
    void Start()
    {
        if (instanse == null)
        {
            instanse = this;

        }
    }

    public void Respawn()
    {
        player.transform.position = player_respown;
        hunter.transform.position = hunter_respown;

    }
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }




}
