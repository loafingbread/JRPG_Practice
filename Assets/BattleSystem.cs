using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattlestation;

    UnitController PlayerUnit;
    UnitController EnemyUnit;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        GameObject PlayerGO = Instantiate(playerPrefab, playerBattleStation);
        PlayerUnit = PlayerGO.GetComponent<UnitController>();

        GameObject EnemyGO = Instantiate(enemyPrefab, enemyBattlestation);
        EnemyUnit = EnemyGO.GetComponent<UnitController>();

        
    }

    
}
