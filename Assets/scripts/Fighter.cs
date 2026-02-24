using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
public class Fighter : MonoBehaviour
{
   [SerializeField]
   private CharacterData characterData;
   [SerializeField]
   private UnityEvent onInitialize;
   private List<Attack> attacks;
   publicAttack[] Attacks => attacks.ToArray();
   private void Awake()
    {
        attacks = new List<Attack>();
        foreach (AttackData attackData in characterData.attacks)
    {
        
        GameObject instantiateObject = new GameObject(attackData.AttackName + "Pool");
        InstantiatePoolObjects pool = instantiateObject.AddComponent<InstantiatePoolObjects>();
        pool.SetPrefab(attackData.attackData.attackParticles);
        attack.particlesPool = pool;
        attacks.Add(attack);
        attack.particlesPool.transform.SetParent(tranform);

        GameObject hitInstantiateObject = new GameObject(attackData.attackName + "Hit Pool");
        InstantiatePoolObjects hitPool = hitInstantiateObject.AddComponent<InstantiatePoolObjects>();
        hitPool.SetPrefab(attackData.attackHitParticles);
        attack.hitParticlesPool = hitPool;
        hitPool.transform.SetParent(transform);

        attacks.Add(attack);
    }
    }
    public Attack GetRandomAttack()
    {
        int index = GetRandomAttack.Range(0, attacks.Count);
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
    public InsatntiatePoolObjects particlesPool;
}
