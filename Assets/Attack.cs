using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    //PlayerのAnimatorコンポーネント保存用
    private Animator animator;
    public float speed = 3.0f;
    // Use this for initialization
    void Start()
    {
        //PlayerのAnimatorコンポーネントを取得する
        animator = GetComponent<Animator>();
    }
    IEnumerator Timer()
    {
        //Debug.Log("3秒待ちます。");
        //3秒待つ
        yield return new WaitForSeconds(3);
        //Debug.Log("3秒待ちました。");
    }
    // Update is called once per frame
    void Update()
    {

        //Aを押すとjab
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("jab", true);
        } else {
            animator.SetBool("jab", false);
        }

        //Sを押すとHikick
       // if (Input.GetKeyDown(KeyCode.S))
        //{
        //    animator.SetBool("Hikick", true);
        //} else {
         //   animator.SetBool("Hikick", false);
        //}

        //Dを押すとSpinkick
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("Spinkick", true);
        } else {
            animator.SetBool("Spinkick", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.S))
        {
        animator.SetBool("MoveForward", true);
        //Debug.Log("dd");
        }else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
          animator.SetBool("MoveForward", false);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        //if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.S))
        //{
        //animator.SetBool("Hikick", true);
        //Debug.Log("aa");
        //Time.timeScale = 0.0f;
        //StartCoroutine(Timer());
        //Time.timeScale = 1.0f;
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        // animator.SetBool("MoveForward", false);
        //animator.SetBool("Hikick", true);
        //}
        //else
        //{
        //animator.SetBool("Hikick", false);
        //}
        //}
        //else if (Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.S))
        //{
        //animator.SetBool("MoveForward", true);
        //Debug.Log("dd");
        //}
        //else if (Input.GetKeyUp(KeyCode.UpArrow))
        //{
        //  animator.SetBool("MoveForward", false);
        //}
        //else
        //{
        //animator.SetBool("Hikick", false);
        //}

    }

}