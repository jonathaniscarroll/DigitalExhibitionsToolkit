using UnityEngine;

public class MaintainDistanceFromTerrain : MonoBehaviour
{
	public float minimumDistanceFromTerrain = 1.0f; // Set this to your desired distance
	public LayerMask obstacleLayers; // Set this in the Inspector to the layers you want to avoid
	private Terrain terrain;

	void Start()
	{
		// Get the height of the terrain beneath the GameObject
		terrain = Terrain.activeTerrain;
	}

	void Update()
	{
		MaintainDistanceFromObjects();
		MaintainDistanceFromTerrainBelow();
	}

	void MaintainDistanceFromTerrainBelow()
	{
		float terrainHeight = terrain.SampleHeight(transform.position);

		// Calculate the distance from the bottom of the GameObject to the terrain
		float distanceToTerrain = transform.position.y - terrainHeight;

		// If the distance is less than the minimum, move the GameObject up
		if (distanceToTerrain < minimumDistanceFromTerrain)
		{
			Vector3 newPosition = transform.position;
			newPosition.y = terrainHeight + minimumDistanceFromTerrain;
			transform.position = newPosition;
		}
	}

	void MaintainDistanceFromObjects()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, minimumDistanceFromTerrain, obstacleLayers);
		foreach (var hitCollider in hitColliders)
		{
			Vector3 directionAwayFromObstacle = transform.position - hitCollider.transform.position;
			float distanceToObstacle = Vector3.Distance(transform.position, hitCollider.transform.position);

			if (distanceToObstacle < minimumDistanceFromTerrain)
			{
				transform.position += directionAwayFromObstacle.normalized * (minimumDistanceFromTerrain - distanceToObstacle);
			}
		}
	}
}
