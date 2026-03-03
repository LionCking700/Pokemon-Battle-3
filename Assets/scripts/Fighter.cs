using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;
 
 
 
public class Fighter : MonoBehaviour
{
    [SerializeField]
    private CharacterData characterData;
    [SerializeField]
    private UnityEvent onInitialize;
    private List<Attack> attacks;
    public Attack[] Attacks => attacks.ToArray();
    private void Awake()
    {
       
        attacks = new List<Attack>();
        foreach (AttackData attackData in characterData.attacks)
        { 
            Attack attack = new Attack();
            attack.attackData = attackData;
            attack.particlesPool = Instantiate(attackData.attackParticles).GetComponent<InstantiatePoolObjects>();
            attack.particlesPool.SetPrefab(attackData.attackParticles);
            attacks.Add(attack);
            attack.particlesPool.transform.SetParent(transform);
        }
    }
    public Attack GetRandomAttack()
    {
        int index = Random.Range(0, attacks.Count);
        return attacks[index];
    }
    public void Initialize()
    {
        onInitialize.Invoke();
    }
 
 
}
  [System.Serializable]
    public class Attack
    {
        public AttackData attackData;
        public InstantiatePoolObjects particlesPool;
        public InstantiatePoolObjects hitParticlesPool;
    }
 
 