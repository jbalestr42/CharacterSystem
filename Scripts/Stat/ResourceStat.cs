using UnityEngine;
using System.Collections;

public class ResourceStat : MonoBehaviour
{
    Stat m_max;
    Stat m_regen;
    public float m_value;
    public float m_regenRate;

    void Start() {
        m_regenRate = 1f;
    }

    public void Init(Stat p_max, Stat p_regen) {
        m_max = p_max;
        m_regen = p_regen;
        m_value = m_max.Total;
		StartCoroutine(Regen());
    }

    IEnumerator Regen() {
        while (gameObject != null && gameObject.activeInHierarchy) {
            yield return new WaitForSeconds(m_regenRate);
            Add(m_regen.Total);
        }
        Debug.Log("Stop the regen coroutine");
	}

	public bool IsEmpty() {
		return m_value == 0f;
	}

	public float GetRatio() {
		return m_value / m_max.Total;
	}

	public void Add(float p_value) {
		m_value += p_value;
		m_value = Mathf.Clamp(m_value, 0f, m_max.Total);
	}

    public float Value {
		get { return m_value; }
    }
}
