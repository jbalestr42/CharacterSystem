using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(AttributeManager))]
public class Character : MonoBehaviour, IKillable, ICharacterObservable {

	public delegate void OnCharacterEventDelegate(GameObject p_owner);
	Dictionary<EventType, OnCharacterEventDelegate> _events;

    public ModifierIconGroup _iconGroup;
    public ModifierIconGroup _skillGroup;
    public MovementType _movementType;

	void Start() {
		_events = new Dictionary<EventType, OnCharacterEventDelegate>();

        // Init all the data
        AMovement movement = AMovement.AddMovement(gameObject, _movementType);

		AttributeManager attributeManager = GetComponent<AttributeManager>();
        attributeManager.AddAttribute(AttributeType.Health, new ResourceAttribute(100, 0, 1000));
        attributeManager.AddAttribute(AttributeType.HealthMax, new BasicAttribute(130, 0, 1000));
		attributeManager.AddAttribute(AttributeType.HealthRegen, new BasicAttribute(1, 0, 100));
		attributeManager.AddAttribute(AttributeType.Speed, new BasicAttribute(5, 0, 10));
		attributeManager.AddAttribute(AttributeType.Damage, new BasicAttribute(80, 0, 1000));
        attributeManager.AddAttribute(AttributeType.CanUseSkill, new Attribute<bool>(true));
        attributeManager.AddModifier(Factory.GetModifier(AttributModifierType.DurationRatio, gameObject, new AttributeParam<float>(_iconGroup.Add(Color.green, true), false, 10f, -1f, AttributeType.Speed, AttributeValueType.RelativeBonus)));
        attributeManager.AddModifier(Factory.GetModifier(AttributModifierType.Resource, gameObject, new ResourceAttributeParam(_iconGroup.Add(Color.red, false), AttributeType.HealthRegen, AttributeType.HealthMax, AttributeType.Health)));

        movement.Init(attributeManager.GetAttribute<float>(AttributeType.Speed));
	}

	void Update() {
        //Debug.Log(GetComponent<AttributeManager>().GetAttribute<float>(AttributeType.Health).Value + "/" + GetComponent<AttributeManager>().GetAttribute<float>(AttributeType.Health).GetValue(AttributeValueType.Max));
		if (Input.GetKeyDown("space"))
			TriggerEvent(EventType.OnGetDamaged, gameObject);

        if (IsDead()) {
            Die();
        }
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
        p_owner.GetComponent<AttributeManager>().GetAttribute<float>(AttributeType.Health).SetValue(AttributeValueType.Add, -p_damage);
        TriggerEvent(EventType.OnGetDamaged, p_owner);
	}

	public virtual bool IsDead() {
        return GetComponent<AttributeManager>().GetAttribute<float>(AttributeType.Health).Value <= 0f;
    }

	public virtual void Die() {
		Debug.Log("Character is dead :(");
		TriggerEvent(EventType.OnDie, gameObject);
	}

	public GameObject GetTarget() {
		// TODO get the nearest ? target // implement a strategy to get the good target
		return GameObject.Find("Enemy");
	}
}
