using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{
[SerializeField]
private int minimumFighters = 2;
[SerializeField]
private int maximumFighters = 4;
[SerializeField]
private UnityEvent onStartBattleCount;
[SerializeField]
private UnityEvent onStopBattle;
private List<Fighter> fighters = new List<Fighter>();
public void AddFighter(Fighter fighter)
    {
        if (fighters.Count < maximumFighters)
        {
            fighters.Add(fighter);
            if (fighters.Count >= minimumFighters)
            {
                onStartBattleCount?.Invoke();
            }
        }
    }
    public void RemoveFighter(Fighter fighter)
    {
        if (fighters.Contains(fighter))
        {
            fighters.Remove(fighter);
            if (fighters.Count < minimumFighters)
            {
             onStopBattle?.Invoke();
            }
        }
    }
    public void StartBattle()
    {
        
    }
}
