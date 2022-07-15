using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garota : MonoBehaviour
{
    public Rigidbody cr;
    public Animator anim;
    public bool correr = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cr = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("0"))
        {
            anim.Play("WAIT00");
        }
        if (Input.GetKeyDown("1"))
        {
            anim.Play("WAIT01");
        }
        if (Input.GetKeyDown("2"))
        {
            anim.Play("WAIT02");
        }
        if (Input.GetKeyDown("3"))
        {
            anim.Play("WAIT03");
        }
        if (Input.GetKeyDown("4"))
        {
            anim.Play("WAIT04");
        }

        if (Input.GetKeyDown("space"))
        {
            anim.Play("JUMP00");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            anim.Play("LOSE00");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.Play("SLIDE00");
        }

        if (Input.GetMouseButtonDown(0))
        {
            int n = Random.Range(0, 2);

            if (n == 0)
            {
                anim.Play("DAMAGED00");
            }
            else
            {
                anim.Play("DAMAGED01");
            }
        }
        //if (Input.GetMouseButtonDown(1))
        //{
        //    anim.Play("DAMAGED01");
        //}

        if (Input.GetKey(KeyCode.LeftShift))
        {
            correr = true;
        }
        else
        {
            correr = false;
        }

        float entradaH = Input.GetAxis("Horizontal");
        float entradaV = Input.GetAxis("Vertical");

        anim.SetFloat("entradaH", entradaH);
        anim.SetFloat("entradaV", entradaV);
        anim.SetBool("correr", correr);

        float moveX = entradaH * 40.0f * Time.deltaTime;
        float moveZ = entradaV * 100.0f * Time.deltaTime;

        if (moveZ <= 0f)
        {
            moveX = 0f;
        }
        else if (correr)
        {
            moveX *= 6f;
            moveZ *= 6f;
        }

        cr.velocity = new Vector3(moveX, 0.0f, moveZ);
    }
}
