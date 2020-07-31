using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Inventory playerInventory;

    public Text DialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public Transform playerBattleStation;
    public Transform enemyBattlestation;

    UnitController PlayerUnit;
    UnitController EnemyUnit;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject PlayerGO = Instantiate(playerPrefab, playerBattleStation);
        PlayerUnit = PlayerGO.GetComponent<UnitController>();

        GameObject EnemyGO = Instantiate(enemyPrefab, enemyBattlestation);
        EnemyUnit = EnemyGO.GetComponent<UnitController>();

        DialogueText.text = EnemyUnit.unitName + " approaches!";

        playerHUD.SetHUD(PlayerUnit);
        enemyHUD.SetHUD(EnemyUnit);

        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        //damage enemy
        bool isDead = EnemyUnit.TakeDamage(PlayerUnit.damage);

        enemyHUD.SetHP(EnemyUnit.currentHP);
        DialogueText.text = "Direct Hit!";

        yield return new WaitForSeconds(2f);

        //check if enemy is dead
        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        //change state based on what happened
    }

    IEnumerator PlayerHeal()
    {
        PlayerUnit.Heal(5);

        playerHUD.SetHP(PlayerUnit.currentHP);
        DialogueText.text = "You feel renewed strenght";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator EnemyTurn()
    {
        DialogueText.text = EnemyUnit.unitName + " attacks!";
        yield return new WaitForSeconds(1f);

        bool isDead = PlayerUnit.TakeDamage(EnemyUnit.damage);

        playerHUD.SetHP(PlayerUnit.currentHP);

        yield return new WaitForSeconds(1f);
        if(isDead)
        {
            state = BattleState.LOST;
            EndBattle();

        } else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            DialogueText.text = "You won the battle";
        } else if (state == BattleState.LOST)
        {
            DialogueText.text = "You were defeated.";
        }
    }
    void PlayerTurn()
    {
        DialogueText.text = "Choose an action!";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }

    public void OnPlayerUseItem(Item item)
    {
        UnityEngine.Debug.Log("OnPlayerUseItem: " + item.itemName);
        if (PlayerUnit)
        {
            item.UseItem(PlayerUnit);
            playerHUD.SetHP(PlayerUnit.currentHP);
        }
    }

}
