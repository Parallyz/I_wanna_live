using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameController instanse;




    [SerializeField]
    public Sprite OneStarSprite;

    [SerializeField]
    public Sprite TwoStarSprite;
    [SerializeField]
    public Sprite ThreeStarSprite;

   
    
    


    [HideInInspector]
    public bool isPlayerJump;


    public bool isRun = true;


    public GameObject player;
    public GameObject hunter;

    [HideInInspector]
    public Vector2 player_jump_position;

    [HideInInspector]
    public Vector2 player_respown;
    [HideInInspector]
    public Vector2 hunter_respown;
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {

        if (!instanse)
        {
            instanse = this;
        }
    }
    public void StopMoving()
    {
        isRun = false;
    }
    public void Init()
    {
    }

    public void Respawn()
    {
        player.transform.position = player_respown;
        hunter.transform.position = hunter_respown;

    }


    public void SetPlayerJumpPosition()
    {
        player_jump_position = player.transform.position;

    }
    public void SetPlayerIsJump(bool isjump)
    {
        isPlayerJump = isjump;

    }
  
    public void SetPlayerRespownPosition()
    {
        player_respown = player.transform.position;
    }
    public bool isTimeToJump()
    {
        if (player_jump_position != null)
        {
            return isPlayerJump &&
                   player_jump_position.x >= hunter.transform.position.x - 0.5 &&
                   player_jump_position.x <= hunter.transform.position.x + 0.5;
            ;
        }
        return false;
    }
    public void SetHunterRespownPosition()
    {

        hunter_respown = hunter.transform.position;
    }
}
