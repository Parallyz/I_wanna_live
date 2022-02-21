using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dumping = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);



    private Transform player;

    private int lastX;
    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            int curentX = Mathf.RoundToInt(player.position.x);


            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target = transform.position = new Vector3(player.position.x + offset.x, player.position.y, transform.position.z);



            Vector3 currentPos = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPos;
        }


    }

    public void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);

        transform.position = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);

    }
}
