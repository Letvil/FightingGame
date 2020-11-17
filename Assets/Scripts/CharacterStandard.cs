using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStandard : MonoBehaviour {
    // プレイヤーの状態
    enum PlayerState {
        stop, move, jump, 
        attack, shield, damage, dead
    }

    // 攻撃の種類
    enum AttackVar {
        // 通常攻撃
        NeutralAttack,
        UpAttack,
        SideAttack,
        DownAttack,

        // B 攻撃
        NeutralB,
        UpB,
        SideB,
        DownB,

        // 空中攻撃
        AirAttack,

        // つかみ
        Grab
    }

    // 追加コメント
    [Header("基本設定")]
    [SerializeField]
    private int maxHp = 100;
    [SerializeField]
    private float moveSpeed = 2.0f;
    [SerializeField]
    private float jumpPower = 2.0f;

    [Header("基本動作_発生・硬直")]
    [SerializeField]
    private int[] shield_startup;
    private int[] dash_startup;
    private int[] jump_startup;

    /*** 攻撃の種類ごとに変数定義(予定) ***/
    [Header("攻撃_ダメージ")]
    [SerializeField]
    private int attack1_damage;
    [SerializeField]
    private int attack2_damage;
    [SerializeField]
    private int attack3_damage;
    [SerializeField]
    private int attack4_damage;

    /*** 攻撃の種類ごとに変数定義(予定) ***/
    [Header("攻撃_発生・持続・硬直")]
    [SerializeField]
    private int[] attack1_frame;
    [SerializeField]
    private int[] attack2_frame;
    [SerializeField]
    private int[] attack3_frame;
    [SerializeField]
    private int[] attack4_frame;


    // 基本変数
    private PlayerState ps;
    private int playerHp; // HP
    private int rigidityFrame; // 硬直時間
    private bool deadFlag; // 死亡フラグ


    private int Hp {
        set { 
            playerHp += value;
            playerHp = Mathf.Max(playerHp, 0);
        }
        get {
            return playerHp;
        }
    }
    private int RigidityFrame {
        set {
            rigidityFrame += value;
            rigidityFrame = Mathf.Max(rigidityFrame, 0);
        }
        get {
            return rigidityFrame;
        }
    }




    // 初期値操作
    private void InitPlayerHP() { playerHp = maxHp; }
    private void InitRigidityFrame() { rigidityFrame = 0; }
    // プレイヤーの状態操作
    private void c_PlayerState(PlayerState s) { ps = s; }
    private PlayerState r_PlayerState() { return ps; }
    // 死亡フラグ操作
    private void c_DeadFlag (bool b) { deadFlag = b; }
    private bool r_DeadFlag () { return deadFlag; }



    void Start() {
        InitPlayerHP();
        InitRigidityFrame();
        c_DeadFlag(false);
    }

    void Update() {
        // 死亡フラグ
        if (r_DeadFlag()) {
            /*** 死亡時の操作 ***/

        }

        // 硬直時間
        if (RigidityFrame > 0) {
            RigidityFrame--;
            return;
        }

        /*** 操作 ***/

    }




    private void Attack (int damage, int r_frame){
        /*** ダメージを相手に伝える ***/


        // 硬直時間
        InitRigidityFrame();
        RigidityFrame += r_frame;
    }

    public void GetDamage(int damage, int r_frame) { 
        // ダメージ
        Hp -= damage;

        // 死亡フラグ ON
        if (Hp <= 0) {
            c_PlayerState(PlayerState.dead);
            c_DeadFlag(true);
            return;
        }

        // 硬直時間
        c_PlayerState(PlayerState.damage);
        InitRigidityFrame();
        RigidityFrame += r_frame;
    }
}
