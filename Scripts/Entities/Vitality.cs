using Godot;
using System;
using System.ComponentModel.DataAnnotations;

public class Health
{
	private float currentHealth, maxHealth;
	public Health(float currentValue, float maxValue)
	{
		currentHealth = currentValue;
		maxHealth = maxValue;
	}

	public void Heal(float value)
	{
		currentHealth += value;
		if (currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}
	}

	public void TakeDamage(float value)
	{
		if (currentHealth > 0)
			currentHealth -= value;
	}

	public float Value()
	{
		return Mathf.Max(0,currentHealth);
	}
		
	public float maxValue()
	{
		return maxHealth;
	}
}

public class Stamina
{
    private float currentStamina, maxStamina;
    public Stamina(float currentValue, float maxValue)
    {
        currentStamina = currentValue;
        maxStamina = maxValue;
    }

	public void DecStamina(float value)
	{
		if(currentStamina>0)
			currentStamina-=value;
	}
    public float Value()
    {
        return currentStamina;
    }

    public float maxValue()
    {
        return maxStamina;
    }
}