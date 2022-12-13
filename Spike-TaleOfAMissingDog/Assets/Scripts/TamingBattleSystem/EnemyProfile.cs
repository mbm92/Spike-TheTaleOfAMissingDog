using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyProfile", menuName = "EnemyProfiles/Enemy")]
public class EnemyProfile : ScriptableObject
{

    public int HP;

    public int CharmHp; // tamingTresshold


    public Sprite EnemyVisual;

    public GameObject[] EnemiesAttacks;
}
