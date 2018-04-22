using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;

[RequireComponent(typeof(AttributeManager))]
public class Character : MonoBehaviour, IKillable, ICharacterObservable {

	public CharacterData _data;

	public delegate void OnCharacterEventDelegate(GameObject p_owner);
	Dictionary<EventType, OnCharacterEventDelegate> _events;

	ResourceAttribute _health;
	bool _canUseSkill = true;

	void Start() {
		Assert.IsNotNull(_data, "There is not data attached to the character");

		_events = new Dictionary<EventType, OnCharacterEventDelegate>();
		_health = gameObject.AddComponent<ResourceAttribute>();

		// Init all the data
		AMovement movement = AMovement.AddMovement(gameObject, _data._movementType);

		AttributeManager AttributeManager = GetComponent<AttributeManager>();
		foreach (CharacterData.AttributeData data in _data._attributes) {
			AttributeManager.AddAttribute(data.valueType, new BasicAttribute(data.baseValue, data.min, data.max));
			foreach (CharacterData.AttributModifierData modifier in data.AttributModifiers) {
				AttributeManager.AddModifier(data.valueType, AttributeModifier.GetModifier(modifier.AttributModifierType, gameObject, modifier.modifierFactorAttributes));
			}
		}
        AttributeManager.AddAttribute(AttributeType.CanUseSkill, new Attribute<bool>(true, true));

		movement.Init(AttributeManager.GetAttribute<float>(AttributeType.Speed));
		_health.Init(AttributeManager.GetAttribute<float>(AttributeType.HealthMax), AttributeManager.GetAttribute<float>(AttributeType.HealthRegen));
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

	public ResourceAttribute Health {
		get { return _health; }
	}

	public bool CanUseSkill {
		get { return _canUseSkill; }
		set { _canUseSkill = value; }
	}
}
