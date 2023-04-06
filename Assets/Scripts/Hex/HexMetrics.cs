using UnityEngine;

public static class HexMetrics {
	public const float outerRadius = 10f;
	public const float innerRadius = outerRadius * 0.866025404f;

  public static Vector3[] corners = {
		new Vector3(0f, 0f, outerRadius), //N
		new Vector3(innerRadius, 0f, 0.5f * outerRadius), //NE
		new Vector3(innerRadius, 0f, -0.5f * outerRadius), //SE
		new Vector3(0f, 0f, -outerRadius),//S
		new Vector3(-innerRadius, 0f, -0.5f * outerRadius),//SO
		new Vector3(-innerRadius, 0f, 0.5f * outerRadius),//NO
    new Vector3(0f, 0f, outerRadius)//N
	};
}