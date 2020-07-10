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

    public Text DialogueText;

    public battlehud playerHUD;
    public battlehud enemyHUD;

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

    void PlayerTurn()
    {
        DialogueText.text = "Choose an action!";
    }

    
}
