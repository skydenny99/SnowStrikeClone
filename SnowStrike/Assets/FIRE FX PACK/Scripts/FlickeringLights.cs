using UnityEngine;
using System.Collections;

public class FlickeringLights : MonoBehaviour
{
    
	public float MinIntensity = 0.8f;
	public float MaxIntensity = 1.2f;
	public float FlickerRate = 5f;

	private float randOffset;
    private Light light;

	void Start()
	{
		randOffset = Random.Range( 0f, 100f );
        light = transform.GetComponent<Light>();
	}

	void Update()
	{
		float noise = Mathf.PerlinNoise( randOffset, Time.time * FlickerRate );
		light.intensity = Mathf.Lerp( MinIntensity, MaxIntensity, noise );
	}
}