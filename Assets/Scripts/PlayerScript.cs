using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private CharacterController characterConrt;
    [SerializeField] private float speed;
    private Vector3 direction;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        characterConrt = GetComponent<CharacterController>();
        speed = 10f;
        direction = Vector3.zero;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterConrt.SimpleMove(direction*speed);

        if (direction != Vector3.zero)
        {
            anim.SetBool("isWalking", true);
        }
        else {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Chob", true);
        }
        else {
            anim.SetBool("Chob", false);
        }
    }
}
