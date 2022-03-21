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
  

    private void Start()
    {

        if (!instanse)
        {
            instanse = this;
            player_respown= player.transform.position;
            hunter_respown= hunter.transform.position;
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
 
   
}
