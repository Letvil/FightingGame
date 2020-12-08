using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{

    void Update()
    {

        //GetComponentを用いてAnimatorコンポーネントを取り出す.
        Animator animator = GetComponent<Animator>();

        //あらかじめ設定していたintパラメーター「trans」の値を取り出す.
        int ueB = animator.GetInteger("ueB");

        //上矢印キーを押した際にパラメータ「trans」の値を増加させる.
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ueB++;
        }

        //下矢印キーを押した際にパラメータ「trans」の値を減少させる.
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ueB--;
        }

        //intパラメーターの値を設定する.
        animator.SetInteger("ueB", ueB);
    }
}