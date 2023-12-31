		///----------------------------\\\				
		//      Ultimate AI System      \\
// Copyright (c) N-Studios. All Rights Reserved. \\
//      https://nikichatv.com/N-Studios.html	  \\
///-----------------------------------------------\\\	



using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Ultimate.AI;

public class PlayerHealth : MonoBehaviour
{
	[Tooltip("The max value of the player's total hitpoints.")]
    public float health;
	[Tooltip("This is the empty game object that will be used as a parent for the animation rigging target and will only apply when the AI can see the player.")]
	public Transform IKPosition;
	[Tooltip("The audio source attached to the player.")]
	public AudioSource audioSource;
	[Tooltip("Make an empty game object and position it in the center of your player object.")]
	public Transform playerCenter;

	[SerializeField] public GameObject deathCamera;
	[SerializeField] public GameObject deathCanvas;

	private void Update()
	{
		if (health < 0f) health = 0f;
		if (health <= 0f) Die();
	}

	private Transform GetClosestAI()
	{
		List<Transform> aiTransforms = new List<Transform>();

		foreach (UltimateAI ai in Object.FindObjectsOfType(typeof(UltimateAI))) aiTransforms.Add(ai.transform);

		Vector3 position = transform.position;
		return aiTransforms.OrderBy(o => (o.transform.position - position).sqrMagnitude).FirstOrDefault();
	}

	public void TakeDamage(float damageToTake)
	{
		if (health - damageToTake > 0f) health -= damageToTake;
		else Die();
	}

	public void Die()
	{
		foreach (UltimateAI ai in Object.FindObjectsOfType(typeof(UltimateAI))) if (ai.players.Contains(this)) ai.players.Remove(this);
		deathCamera.SetActive(true);
		deathCanvas.SetActive(true);
;		Cursor.lockState = CursorLockMode.None;
        Destroy(this.gameObject);
	}
}
