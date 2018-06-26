using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttributeManager))]
public class Enemy : MonoBehaviour, IKillable {

    GameObject _destination = null;
    Attribute<float> _speed;

	void Awake() {
        AttributeManager attributeManager = GetComponent<AttributeManager>();
        attributeManager.AddAttribute(AttributeType.Speed, new BasicAttribute(1, 0, 10));
        attributeManager.AddAttribute(AttributeType.Health, new ResourceAttribute(100, 0, 1000));
        attributeManager.AddAttribute(AttributeType.Money, new BasicAttribute(10, 0, 100));

        _speed = GetComponent<AttributeManager>().GetAttribute<float>(AttributeType.Speed);
    }
	
	void Update () {
        if (_destination != null) {
            transform.Translate((_destination.transform.position - transform.position).normalized * _speed.Value * Time.deltaTime);
        }
        if (IsDead()) {
            Die();
        }
	}

    public void SetDestination(GameObject p_destination) {
        _destination = p_destination;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "End") {
            Destroy(this.gameObject);
        }
    }

    public virtual void GetDamage(GameObject p_owner, float p_damage) {
        p_owner.GetComponent<AttributeManager>().GetAttribute<float>(AttributeType.Health).SetValue(AttributeValueType.Add, -p_damage);
    }

    public virtual bool IsDead() {
        return GetComponent<AttributeManager>().GetAttribute<float>(AttributeType.Health).Value <= 0f;
    }

    public virtual void Die() {
        FindObjectOfType<GameManager>().UpdateMoney(GetComponent<AttributeManager>().GetAttribute<float>(AttributeType.Money).Value);
        Debug.Log("Enemy is dead :(");
        FindObjectOfType<GameManager>().DestroyEnemy(this);
    }
}
