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

    [Header("通常攻撃")]
    [SerializeField]
    private AttackSetting NeutralASetting;
    [SerializeField]
    private AttackSetting UpASetting;
    [SerializeField]
    private AttackSetting SideASetting;
    [SerializeField]
    private AttackSetting DownASetting;
    [Header("B 攻撃")]
    [SerializeField]
    private AttackSetting NeutralBSetting;
    [SerializeField]
    private AttackSetting UpBSetting;
    [SerializeField]
    private AttackSetting SideBSetting;
    [SerializeField]
    private AttackSetting DownBSetting;
    [Header("その他")]
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
            playerHp = Mathf.Clamp(value, 0, maxHp);

            if (playerHp <= 0) {
                c_DeadFlag(true);
                c_PlayerState(PlayerState.dead);
                return;
            }
        }
        get { return playerHp; }
    }

    private int RecoveryFrame {
        set {
            recoveryFrame = System.Math.Max(0, value);
            if (recoveryFrame == 0) 
                c_PlayerState(PlayerState.stop);
        }
        get { return recoveryFrame; }
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

    // AttackVar -> AttackSetting
    AttackSetting VarToSetting(AttackVar var) {
        switch(var) {
            // 通常攻撃
            case AttackVar.NeutralA: return NeutralASetting;
            case AttackVar.UpA: return UpASetting;
            case AttackVar.SideA: return SideASetting;
            case AttackVar.DownA: return DownASetting;
            // B 攻撃
            case AttackVar.NeutralB: return NeutralBSetting;
            case AttackVar.UpB: return UpBSetting;
            case AttackVar.SideB: return SideBSetting;
            case AttackVar.DownB: return DownBSetting;
            // その他
            case AttackVar.AirA: return AirASetting;
            case AttackVar.Grab: return GrabSetting;
        }
        return null;
    }





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



    private void Attack (AttackVar var){
        AttackSetting attack = VarToSetting(var);   // 攻撃情報の取得

        /*** 当たり判定オブジェクトの生成 ? ***/


        RecoveryFrame = attack.r_RecoveryFrame(); // 硬直
        c_PlayerState(PlayerState.attack);          // 状態変化
    }

    public void GetDamage(int damage, int recov_frame) { 
        Hp -= damage; // ダメージ

        RecoveryFrame = recov_frame;          // 硬直時間
        c_PlayerState(PlayerState.damage);  // 状態変化
    }
}