using UnityEngine;

public class DurationRatio : Duration {

	public override float GetFactor() {
        return GetRatio();
    }
}