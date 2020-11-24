using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSetting : MonoBehaviour {
    [SerializeField]
    int damage;             // ダメージ
    [SerializeField]
    int start_up;           // 発生フレーム
    [SerializeField]
    int active_frame;       // 持続
    [SerializeField]
    int recovery_frame;     // 硬直フレーム
    [SerializeField]
    int hit_stun;           // 相手の硬直フレーム

    // 変数引き渡し用
    public int r_Damage() { return damage; }
    public int r_StartUp() { return start_up; }
    public int r_ActiveFrame() { return active_frame; }
    public int r_RecoveryFrame() { return recovery_frame; }
    public int r_HitStun() { return hit_stun; }
}
