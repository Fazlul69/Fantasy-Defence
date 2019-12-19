using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent nav;
    [SerializeField] private Transform player;

    private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Hero").transform;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameManager.instance.Player.transform.position;
        if (Vector3.Distance(playerPos, gameObject.transform.position) > 2)
        {
            nav.enabled = true;
            //enemy find the player
            nav.SetDestination(player.position);
        }
        else {
            nav.enabled = false;
        }
        
    }
}
