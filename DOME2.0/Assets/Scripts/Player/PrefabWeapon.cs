using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;
    private Animator animator;
    private PlayerMovement playerMovement;
    private float horizontalInput;

    void Start()
    {
        // Get the Animator component on the same GameObject
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();

        // Ensure the animator is not null
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the weapon GameObject.");
        }
    }

    // Update is called once per frame
    void Update () {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Fire1") && horizontalInput==0)
		{
            PlayAttackAnimation();
            Shoot();
		}
	}
    void PlayAttackAnimation()
    {
        // Ensure the animator is not null
        if (animator != null)
        {
            // Trigger the attack animation parameter (assuming you have a trigger parameter named "Attack")
            //animator.SetTrigger("attack");
        }
    }
    void Shoot ()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
