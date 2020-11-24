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
        NeutralA, UpA, SideA, DownA,
        // B 攻撃
        NeutralB, UpB, SideB, DownB,
        // 空中攻撃, つかみ
        AirA, Grab
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

    [Header("攻撃設定")]
    // 通常攻撃
    [SerializeField]
    private AttackSetting NeutralASetting;
    [SerializeField]
    private AttackSetting UpASetting;
    [SerializeField]
    private AttackSetting SideASetting;
    [SerializeField]
    private AttackSetting DownASetting;
    // B 攻撃
    [SerializeField]
    private AttackSetting NeutralBSetting;
    [SerializeField]
    private AttackSetting UpBSetting;
    [SerializeField]
    private AttackSetting SideBSetting;
    [SerializeField]
    private AttackSetting DownBSetting;
    // その他攻撃
    [SerializeField]
    private AttackSetting AirASetting;
    [SerializeField]
    private AttackSetting GrabSetting;



    // 基本変数
    private PlayerState ps;
    private int playerHp; // HP
    private int recoveryFrame; // 硬直時間
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
    private int RecoveryFrame {
        set {
            recoveryFrame += value;
            recoveryFrame = Mathf.Max(recoveryFrame, 0);

            // 硬直を解除
            if (recoveryFrame == 0) c_PlayerState(PlayerState.stop);
        }
        get {
            return recoveryFrame;
        }
    }




    // 初期値操作
    private void InitPlayerHP() { playerHp = maxHp; }
    private void InitRecoveryFrame() { recoveryFrame = 0; }
    // プレイヤーの状態操作
    private void c_PlayerState(PlayerState s) { ps = s; }
    private PlayerState r_PlayerState() { return ps; }
    // 死亡フラグ操作
    private void c_DeadFlag (bool b) { deadFlag = b; }
    private bool r_DeadFlag () { return deadFlag; }



    void Start() {
        InitPlayerHP();
        InitRecoveryFrame();
        c_DeadFlag(false);
    }

    void Update() {
        // 死亡フラグ
        if (r_DeadFlag()) {
            /*** 死亡時の操作 ***/

        }

        // 硬直時間
        if (RecoveryFrame > 0) {
            RecoveryFrame--;
            return;
        }

        /*** 操作 ***/

    }



    // damage:ダメージ   r_frame:硬直時間
    private void Attack (int damage, int r_frame, int ene_rframe){
        /*** 当たり判定オブジェクトの生成 ? ***/


        // 硬直時間
        c_PlayerState(PlayerState.attack);
        InitRecoveryFrame();
        RecoveryFrame += r_frame;
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
        InitRecoveryFrame();
        RecoveryFrame += r_frame;
    }
}