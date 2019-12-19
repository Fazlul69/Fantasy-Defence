using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private CharacterController characterConrt;
    [SerializeField] private float speed;
    private Vector3 direction;
    public Animator anim;
    [SerializeField] private LayerMask myLayer;

    Vector3 currentLookTarget = Vector3.zero;
    
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


        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin,ray.direction*500, Color.red);

        if (Physics.Raycast(ray, out hit, 500, myLayer, QueryTriggerInteraction.Ignore))
        {
            if (hit.point != null) {
                currentLookTarget = hit.point;
            }

            Vector3 targetPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10);
        }
    }
}
