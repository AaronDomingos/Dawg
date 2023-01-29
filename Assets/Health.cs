using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float CurrentHealth = 5;
    public float MaxHealth = 5;

    public Status CurrentStatus = Status.Healthy;
    private Status PreviousStatus = Status.Healthy;

    public bool SendWhenDamaged = false;
    public bool SendWhenRepaired = false;
    public bool SendStatusHealthy = false;
    public bool SendStatusDamaged = false;
    public bool SendStatusCritical = false;
    public bool SendStatusDestroyed = false;
    
    public enum Status
    {
        Healthy,
        Damaged,
        Critical,
        Destroyed
    }

    public void Init(float health)
    {
        MaxHealth = health;
        CurrentHealth = health;
        CurrentStatus = Status.Healthy;
        PreviousStatus = Status.Healthy;
    }

    public void Damage(float amount)
    {
        if (SendWhenDamaged)
        {
            gameObject.SendMessage("OnDamaged");
        }

        CurrentHealth -= amount;
        AdjustHealth();
    }

    public void Repair(float amount)
    {
        if (SendWhenRepaired)
        {
            gameObject.SendMessage("OnRepaired");
        }

        CurrentHealth += amount;
        AdjustHealth();
    }
    
    public void AdjustHealth()
    {
        if (CurrentHealth > MaxHealth) { CurrentHealth = MaxHealth; }
        if (CurrentHealth < 0) { CurrentHealth = 0; }
        AdjustStatus();
    }

    public void AdjustStatus()
    {
        if(CurrentHealth <= 0f)
        {
            CurrentStatus = Status.Destroyed;
            if (CurrentStatus != PreviousStatus)
            {
                if (SendStatusDestroyed)
                {
                    gameObject.SendMessage("OnStatusDestroy");
                }
            }
        }
        else if((0f/3f) * MaxHealth < CurrentHealth && 
                CurrentHealth <= MaxHealth * (1f/3f))
        {
            CurrentStatus = Status.Critical;
            if (CurrentStatus != PreviousStatus)
            {
                if (SendStatusCritical)
                {
                    gameObject.SendMessage("OnStatusCritical");
                }
            }
        }
        else if((1f/3f) * MaxHealth < CurrentHealth && 
                CurrentHealth <= MaxHealth * (2f/3f))
        {
            CurrentStatus = Status.Damaged;
            if (CurrentStatus != PreviousStatus)
            {
                if (SendStatusDamaged)
                {
                    gameObject.SendMessage("OnStatusDamaged");
                }
            }
        }
        else if((2f/3f) * MaxHealth < CurrentHealth && 
                CurrentHealth <= MaxHealth * (3f/3f))
        {
            CurrentStatus = Status.Healthy;
            if (CurrentStatus != PreviousStatus)
            {
                if (SendStatusHealthy)
                {
                    gameObject.SendMessage("OnStatusHealthy");
                }
            }
        }
        PreviousStatus = CurrentStatus;
    }
}
