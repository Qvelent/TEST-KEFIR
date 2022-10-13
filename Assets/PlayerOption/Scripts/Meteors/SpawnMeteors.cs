using System.Collections.Generic;
using UnityEngine;

namespace PlayerOption.Scripts.Meteors
{
	public class SpawnMeteors : MonoBehaviour
	{
		
		[SerializeField] private GameObject asteroidPrefab;
		[SerializeField] private float offscreenPadding;
		[SerializeField] private int startingAsteroidCount = 1;
		

		public void Spawn(int level)
		{
			int numAsteroids = startingAsteroidCount + level;
			for (int i = 0; i < numAsteroids; i++)
			{
				Instantiate(asteroidPrefab, GetOffScreenPosition(), GetOffScreenRotation());
			}
		}

		private Vector3 GetOffScreenPosition()
		{
			float posX = 0.0f;
			float posY = 0.0f;
			int startingSide = Random.Range(0, 4);

			switch (startingSide)
			{
				case 0:
					posX = Random.value;
					posY = 0.0f;
					posY -= offscreenPadding;
					break;
				case 1:
					posX = Random.value;
					posY = 1.0f;
					posY += offscreenPadding;
					break;
				case 2:
					posX = 0.0f;
					posY = Random.value;
					posX -= offscreenPadding;
					break;
				case 3:
					posX = 1.0f;
					posY = Random.value;
					posX += offscreenPadding;
					break;
			}

			return Camera.main.ViewportToWorldPoint(new Vector3(posX, posY, 1.0f));
		}
		
		private Quaternion GetOffScreenRotation()
		{
			int angle = 0;
			int startingSide = Random.Range(0, 4);
			angle = startingSide switch
			{
				0 => Random.Range(20, 70),
				1 => -Random.Range(20, 70),
				2 => Random.Range(110, 160),
				3 => -Random.Range(110, 160),
				_ => angle
			};
			return Quaternion.Euler(new Vector3(0.0f, 0.0f, angle));
		}
	}
}
