using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public enum BattleState
{
    Start,
    PlayerTurn,
    EnemyTurn,  
    FinishedTurn,   // all turns are finished
    Won,    // enemy is defeated or tamed
    Lost    // player dead
}

public class TurnHandle : MonoBehaviour
{
    public BattleState state;
    public EnemyProfile[] EnemiesInBattle;
    private bool enemyActed;
    private GameObject[] EnemyAtks;

    public PlayerSoulCtrl PlayerSoul;
    public GameObject Player;

    public GameObject PlayerUi;
    public TMPro.TextMeshProUGUI DialogueText;

    // Start is called before the first frame update
    void Start()
    {
        SetupGame();
        state = BattleState.Start;
        enemyActed = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckGameState(state));
        
    }

    private IEnumerator CheckGameState(BattleState battleState)
    {
        switch (state)
        {
            case BattleState.Start:
                //Debug.Log(state);
                //setup the level
                PlayerUi.SetActive(true);
                yield return new WaitForSeconds(4f);
                IntroDialogue();
                state = BattleState.PlayerTurn;

                //for each enemy in the enemyProfiler list, create an animated sprite for them i...
                // set this enemies health and charm hp to the profiles health and charm hp
                break;

            case BattleState.PlayerTurn:
                //wait for the player to attack
                
                yield return new WaitForSeconds(6f);
                //Debug.Log(state);
                PlayerTurn();
                break;

            case BattleState.EnemyTurn:
                Debug.Log(state);
                EnemyTurn();
                // enemy take turn
                break;

            case BattleState.FinishedTurn:
                //Debug.Log(state);
                FinishedTurn();
                break;

            case BattleState.Lost:
                //Debug.Log(state);
                DialogueText.text = "You have lost!";
                // end the mini-game
                break;

            case BattleState.Won:
                //Debug.Log(state);
                DialogueText.text = "You Tamed the Creature!";
                // end the mini-game
                break;
        }
    }

    private void FinishedTurn()
    {
        //turn is over turn off player soul
        PlayerSoul.gameObject.SetActive(false);

        // check if the player is alive at the end of turn
        if (PlayerSoul.GetComponent<PlayerSoulWillpower>().WP <= 0)
        {
            state = BattleState.Lost;
        }
        else
        {
            var wpLevel = PlayerSoul.GetComponent<PlayerSoulWillpower>().WP;
            var numCreaturesTamed = 0;
            // TODO: finish this part - check for enemy health and set state to Won
            foreach (EnemyProfile enemy in EnemiesInBattle)
            {
                // if enemy's will is lower then the players WP - enemy is tamed.
                if (enemy.CharmHp < wpLevel)
                {
                    numCreaturesTamed++;
                }
            }

            if (numCreaturesTamed == EnemiesInBattle.Length)
            {
                state = BattleState.Won;
            }
            else
            {
                state = BattleState.Lost;
            }
        }
    }

    private void EnemyTurn()
    {
        DialogueText.text = "Dodge the bullets!";
        if (EnemiesInBattle.Length <= 0)
        {
            // there are no enemies so finish the enemy turn
            EnemyFinishedTurn();
        }
        else
        {
            if (!enemyActed)
            {
                // turn on the player Soul
                PlayerSoul.gameObject.SetActive(true);
                PlayerSoul.SetSoul();

                // create all battle effects in the enemy logics
                foreach (EnemyProfile enemy in EnemiesInBattle)
                {
                    int AtkNumb = Random.Range(0, enemy.EnemiesAttacks.Length);

                    Instantiate(enemy.EnemiesAttacks[AtkNumb], Vector3.zero, Quaternion.identity);
                }

                //find all attacks in scene to check when there done
                EnemyAtks = GameObject.FindGameObjectsWithTag("Enemy");

                enemyActed = true;
            }
            else
            {
                bool enemyfin = true;
                foreach (GameObject enemy in EnemyAtks)
                {
                    if (!enemy.GetComponent<EnemyTurnHandle>().FinishedTurn)
                    {
                        enemyfin = false;
                    }
                }

                if (enemyfin)
                {
                    EnemyFinishedTurn();
                }
            }
        }
    }

    void SetupGame()
    {
        Player = GameObject.FindWithTag("Player");
        DialogueText.text = "Welcome to the Taming Mini Game...";

        // set WP Slider
        PlayerSoul.GetComponent<PlayerSoulWillpower>().SetWpSlider();
    }

    private void IntroDialogue()
    {
        DialogueText.text = "To tame the Creature you has to have a WP score higher then the monster";
    }

    private void PlayerTurn()
    {
        DialogueText.text = "Press the 'Act' button";
    }

 

    public void PlayerAct()
    {
        //bring up the menu of aditional player actions that will target specific enemies
        PlayerFinishTurn();
    }

    private void PlayerFinishTurn()
    {
        PlayerUi.SetActive(false);

        state = BattleState.EnemyTurn;
    }

    private void EnemyFinishedTurn()
    {
        //destory all attacks
        foreach (GameObject obj in EnemyAtks)
        {
            Destroy(obj);
        }

        enemyActed = false;
        state = BattleState.FinishedTurn;
    }
}
