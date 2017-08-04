using UnityEngine;
using System.Collections;

public interface IPlayerObservable {
	void Suscribe(EventType p_eventType, Character.OnCharacterEventDelegate p_delegate);
	void Unsuscribe(EventType p_eventType, Character.OnCharacterEventDelegate p_delegate);
}