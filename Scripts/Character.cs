using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(StatManager))]
public class Character : MonoBehaviour, IKillable, ICharacterObservable {

	public delegate void OnCharacterEventDelegate(GameObject p_owner);

	Dictionary<EventType, OnCharacterEventDelegate> _events;

	public CharacterData _data;
	ResourceStat _health;

	StatManager _statManager;

	bool _canUseSkill = true;

	void Start() {
		_events = new Dictionary<EventType, OnCharacterEventDelegate>();
		_statManager = GetComponent<StatManager>();
		_health = gameObject.AddComponent<ResourceStat>();

		// Init all the data
		Movement movement = Movement.AddMovement(gameObject, _data._movementType);

		foreach (CharacterData.StatData data in _data._stats) {
			_statManager.AddStat(data.valueType, new Stat(data.baseValue, data.min, data.max));
			foreach (CharacterData.StatModifierData modifier in data.statModifiers) {
				_statManager.AddModifier(data.valueType, new StatModifier(this, modifier.value, modifier.statValueType, modifier.statModifierType, modifier.modifierFactorAttributes));
			}
		}

		movement.Init(GetStat(StatType.Speed));
		_health.Init(GetStat(StatType.HealthMax), GetStat(StatType.HealthRegen));
	}

	void Update() {
		if (Input.GetKeyDown("space"))
			TriggerEvent(EventType.OnGetDamaged, gameObject);
	}

	public void Suscribe(EventType p_eventType, OnCharacterEventDelegate p_delegate) {
		if (p_delegate == null) {
			return;
		}

		if (_events.ContainsKey(p_eventType)) {
			_events[p_eventType] += p_delegate;
		} else {
			_events[p_eventType] = p_delegate;
		}
	}

	public void Unsuscribe(EventType p_eventType, OnCharacterEventDelegate p_delegate) {
		if (_events.ContainsKey(p_eventType) && _events[p_eventType] != null) {
			_events[p_eventType] -= p_delegate;
		}
	}

	private void TriggerEvent(EventType p_eventType, GameObject p_gameObject) {
		if (_events.ContainsKey(p_eventType) && _events[p_eventType] != null) {
			_events[p_eventType](p_gameObject);
		}
	}

	public virtual void GetDamage(GameObject p_owner, float p_damage) {
		Health.Add(-p_damage);
		TriggerEvent(EventType.OnGetDamaged, p_owner);
		if (IsDead()) {
			Die();
		}
	}

	public virtual bool IsDead() {
		return Health.IsEmpty();
	}

	public virtual void Die() {
		Debug.Log("Character is dead :(");
		TriggerEvent(EventType.OnDie, gameObject);
	}

	public GameObject GetTarget() {
		// TODO get the nearest ? target // implement a strategy to get the good target
		return GameObject.Find("Enemy");
	}

	public Stat GetStat(StatType p_statType) {
		return _statManager.GetStat(p_statType);
	}

	public ResourceStat Health {
		get { return _health; }
	}

	public bool CanUseSkill {
		get { return _canUseSkill; }
		set { _canUseSkill = value; }
	}
}
