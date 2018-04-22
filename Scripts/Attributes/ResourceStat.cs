using UnityEngine;
using System.Collections;

public class ResourceAttribute : MonoBehaviour
{
    Attribute<float> _max;
    Attribute<float> _regen;
    public float _value;
    public float _regenRate;

    void Start() {
        _regenRate = 1f;
    }

    public void Init(Attribute<float> p_max, Attribute<float> p_regen) {
        _max = p_max;
        _regen = p_regen;
        _value = _max.Value;
		StartCoroutine(Regen());
    }

    IEnumerator Regen() {
        while (gameObject != null && gameObject.activeInHierarchy) {
            yield return new WaitForSeconds(_regenRate);
            Add(_regen.Value);
        }
        Debug.Log("Stop the regen coroutine");
	}

	public bool IsEmpty() {
		return _value == 0f;
	}

	public float GetRatio() {
		return _value / _max.Value;
	}

	public void Add(float p_value) {
		_value += p_value;
		_value = Mathf.Clamp(_value, 0f, _max.Value);
	}

    public float Value {
		get { return _value; }
    }
}
