using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public bool isAllowSkill;
    public GameObject[] skills;
    private Transform playerPos;

    //0 SkillAura

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        if (isAllowSkill)
        {
            if (skills.Length > 0)
            {

                SpawnSkillAura();
            }
        }

        
        
    }

    void SpawnSkillAura()
    {
        DamageAura skillAuraScript = skills[0].GetComponent<DamageAura>();
        skillAuraScript.Spawn(playerPos);
    }


    //void SpawnSkillAura()
    //{
    //    SkillAura skillAuraScript = skills[0].GetComponent<SkillAura>();
    //    Vector3 spawnPosition = playerPos.position + new Vector3(skillAuraScript.distanceOffset, 0f, 0f);
    //    GameObject skillAura = Instantiate(skills[0], spawnPosition, Quaternion.identity);
    //    skillAura.transform.SetParent(playerPos);
    //}

}
