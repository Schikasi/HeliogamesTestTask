using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public static void FightNpc(GameObject lhs, GameObject rhs) {
        var rhs_stats = rhs.GetComponent<Stats>();
        var lhs_stats = lhs.GetComponent<Stats>();
        if (rhs_stats.status != Stats.Status.dead && lhs_stats.status != Stats.Status.dead) {
            float luck_random = Random.Range(0, lhs_stats.Luck + rhs_stats.Luck);
            if (luck_random >= lhs_stats.Luck)
            {
                lhs.GetComponent<Behavior>().Die();
                rhs.GetComponent<Behavior>().Fight();
            }
            else
            {
                rhs.GetComponent<Behavior>().Die();
                lhs.GetComponent<Behavior>().Fight();
            }
        }
    }
}
