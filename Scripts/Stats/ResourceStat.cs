using UnityEngine;
using System.Collections;

public class ResourceStat : MonoBehaviour
{
    AAttribute _max;
    AAttribute _regen;
    public float _value;
    public float _regenRate;

    void Start() {
        _regenRate = 1f;
    }

    public void Init(AAttribute p_max, AAttribute p_regen) {
        _max = p_max;
        _regen = p_regen;
        _value = _max.Total;
		StartCoroutine(Regen());
    }

    IEnumerator Regen() {
        while (gameObject != null && gameObject.activeInHierarchy) {
            yield return new WaitForSeconds(_regenRate);
            Add(_regen.Total);
        }
        Debug.Log("Stop the regen coroutine");
	}

	public bool IsEmpty() {
		return _value == 0f;
	}

	public float GetRatio() {
		return _value / _max.Total;
	}

	public void Add(float p_value) {
		_value += p_value;
		_value = Mathf.Clamp(_value, 0f, _max.Total);
	}

    public float Value {
		get { return _value; }
    }
}
