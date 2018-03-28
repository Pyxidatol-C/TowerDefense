using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	// Money is made static so that it can be carried over to another scene.
	public static int Money;
	public int StartMoney = 400;

	private void Start()
	{
		Money = StartMoney;
	}
}
