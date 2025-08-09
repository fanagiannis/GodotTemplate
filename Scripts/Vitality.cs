using Godot;
using System;

public class Health
{
	private float currentHealth, maxHealth;
	public Health(float currentValue, float maxValue)
	{
		currentHealth = currentValue;
		maxHealth = maxValue;
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

    public float Value()
    {
        return currentStamina;
    }

    public float maxValue()
    {
        return maxStamina;
    }
}