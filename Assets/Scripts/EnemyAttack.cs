using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Vector3 playerPos;
    [SerializeField] private Vector3 distance;
    private float playerFarRange = 3f;
    private bool playerInImage;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(enemyAttack());
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameManager.instance.player.transform.position;
        if (Vector3.Distance(playerPos, gameObject.transform.position) < playerFarRange)
        { playerInImage = true; }
        else {
            playerInImage = false;
        }
    }

    IEnumerator enemyAttack() {
        if (!GameManager.instance.GameOver && playerInImage) {
            anim.Play("attack");
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;

        StartCoroutine(enemyAttack());
    }
}
