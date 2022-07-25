using System;
using UnityEngine;
using MarchingBytes;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BallPoolControl : MonoBehaviour {
	
	public string[] poolName;
	List<GameObject> goList = new List<GameObject>();
	[SerializeField] private float zPointSpawn;
	[SerializeField] private float xBorder;

	public void CreateFromPoolAction()
	{
		Vector3 spawnPos = new Vector3(Random.Range(-xBorder, xBorder), 0, zPointSpawn);
		GameObject ball = EasyObjectPool.instance.GetObjectFromPool(poolName[Random.Range(0,poolName.Length)], spawnPos, Quaternion.identity);
		if(ball) {
			goList.Add(ball);
			if(!ball.GetComponent<Hitable>().isBomb)
				ball.GetComponent<BallView>().SetBallMaterial(ball);
		}
	}
	
	public void ReturnAllToPoolAction() {
		foreach(GameObject go in goList) {
			EasyObjectPool.instance.ReturnObjectToPool(go);
		}
		goList.Clear();
	}

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.A))
		{
			CreateFromPoolAction();
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			ReturnAllToPoolAction();
		}
	}
}
