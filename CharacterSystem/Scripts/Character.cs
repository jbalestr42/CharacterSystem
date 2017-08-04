using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(StatManager))]
public class Character : MonoBehaviour, IKillable, IPlayerObservable {

	public delegate void OnCharacterEventDelegate(GameObject p_owner);
	Dictionary<EventType, OnCharacterEventDelegate> m_events;

	public CharacterData m_data;
	ResourceStat m_health;

    StatManager m_statManager;

	void Start() {
		m_events = new Dictionary<EventType, OnCharacterEventDelegate>();
		m_statManager = GetComponent<StatManager>();
		m_health = gameObject.AddComponent<ResourceStat>();

		// Init all the data
		Movement movement = Movement.AddMovement(gameObject, m_data.m_movementType);

		foreach (CharacterData.StatData data in m_data.m_stats) {
			m_statManager.AddStat(data.valueType, new Stat(data.baseValue, data.min, data.max));
			foreach (CharacterData.StatModifierData modifier in data.statModifiers) {
				m_statManager.AddModifier(data.valueType, new StatModifier(this, modifier.value, modifier.statValueType, modifier.statModifierType, modifier.modifierFactorAttributes));
			}
		}

		movement.Init(GetStat(StatType.Speed));
		m_health.Init(GetStat(StatType.HealthMax), GetStat(StatType.HealthRegen));
	}

	void Update () {
		if (Input.GetKeyDown("space"))
			TriggerEvent(EventType.OnGetDamaged, gameObject);
	}

	public void Suscribe(EventType p_eventType, OnCharacterEventDelegate p_delegate) {
		if (p_delegate == null) {
			return;
		}

		if (m_events.ContainsKey(p_eventType)) {
			m_events[p_eventType] += p_delegate;
		} else {
			m_events[p_eventType] = p_delegate;
		}
	}

	public void Unsuscribe(EventType p_eventType, OnCharacterEventDelegate p_delegate) {
		if (m_events.ContainsKey(p_eventType) && m_events[p_eventType] != null) {
			m_events[p_eventType] -= p_delegate;
		}
	}

	private void TriggerEvent(EventType p_eventType, GameObject p_gameObject) {
		if (m_events.ContainsKey(p_eventType) && m_events[p_eventType] != null) {
			m_events [p_eventType] (p_gameObject);
		}
	}

	public virtual void GetDamage(GameObject p_owner) {
		Health.Add(-p_owner.GetComponent<Character>().GetStat(StatType.Damage).Total);
		TriggerEvent(EventType.OnGetDamaged, p_owner);
		if (IsDead()) {
			Die ();
		}
	}

	public virtual bool IsDead() {
		return Health.IsEmpty();
	}

	public virtual void Die() {
		Debug.Log("Character is dead :(");
		TriggerEvent(EventType.OnDie, gameObject);
	}

	public Stat GetStat(StatType p_statType) {
		return m_statManager.GetStat(p_statType);
	}

	public ResourceStat Health {
		get { return m_health; }
	}
}
