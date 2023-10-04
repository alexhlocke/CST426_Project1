using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoldDebuff : MonoBehaviour
{
    public float duration; // Duration of the debuff
    public float tickRate; // How often the debuff ticks
    public int maxStacks; // Maximum number of stacks
    public int currentStacks; // Current number of stacks
    public float damagePerTick; // Damage inflicted per tick
	public bool active;

    private float timer; // Timer to keep track of debuff duration

    // Initialize the debuff with parameters
    public void Initialize(float duration, float tickRate, int maxStacks, float damagePerTick)
    {
        this.duration = duration;
        this.tickRate = tickRate;
        this.maxStacks = maxStacks;
        this.damagePerTick = damagePerTick;

        currentStacks = 1; // Start with one stack
        timer = 0f; // Initialize the timer
		active = false;
    }

    private void Update()
    {
		if(active == true)
		{
        	// Update the timer
        	timer += Time.deltaTime;

        	// Check if the debuff has expired
        	if (timer >= duration + 1)
        	{
            	currentStacks = 0;
        	}
        	else
        	{
            	// Check if it's time to apply a tick of damage
            	if (timer >= tickRate)
            	{
                	// Apply damage to the unit
                	ApplyDamage();
					duration -= timer;
                	timer = 0f; // Reset the timer for the next tick
            	}
        	}
		}
    }

    // Apply damage to the unit
    private void ApplyDamage()
    {
        float totalDamage = damagePerTick * currentStacks;
        GetComponent<life>().takeDamage(totalDamage);
        
        // Increase the stack count if it's not at the maximum
        if (currentStacks < maxStacks)
        {
            currentStacks++;
        }
    }

	public void ToggleScript()
	{
    	if(active == false)
		{
			active = true;
		}
		if(active == true)
		{
			active = false;
		}
	}
}
