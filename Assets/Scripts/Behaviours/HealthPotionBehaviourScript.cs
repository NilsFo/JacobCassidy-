using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionBehaviourScript : MonoBehaviour
{
    [SerializeField] private PlayerStateBehaviourScript playerStateBehaviourScript;

    [SerializeField] private float amountToHeal = 5f;
    
    private void Awake()
    {
        Debug.Assert(playerStateBehaviourScript != null, gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovementBehaviour playerMovementBehaviour = other.gameObject.GetComponentInParent<PlayerMovementBehaviour>();
        if (playerMovementBehaviour)
        {
            playerStateBehaviourScript.ChangeCurrentHealth(+amountToHeal);
            Destroy(gameObject);
        }
    }
}
