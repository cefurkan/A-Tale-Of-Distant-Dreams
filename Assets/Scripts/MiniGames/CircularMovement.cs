using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
	Boss boss;

	[SerializeField]
	Transform rotationCenter;

	[SerializeField]
	float rotationRadius = 2f, angularSpeed = 2f;

	public float angle;
		float posX, posY = 0f;

    private void Start()
    {
		boss = FindObjectOfType<Boss>();
    }

    // Update is called once per frame
    void Update()
	{
		posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
		posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
		transform.position = new Vector2(posX, posY);
		 angle = angle + Time.deltaTime * angularSpeed;

		if (angle >= 360f)
			angle = 0f;

	if(boss.Health <= 0)
        {
			Destroy(gameObject);
        }
	}
}
