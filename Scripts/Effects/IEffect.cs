using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Chaque effet deevrait avoir un id unique pour pouvoir les retrouver facilement et le reset (eg on silence un mec 2 fois, on veux pas qu'il soit deux fois silence, on veut reset le silence la deuxieme fois)
// avec peut etre une option de cumulation/reset

// Cette classe doit etre la base de tous les effets dans le jeu, AStatModifier et IEffect et autres
// Tous les effets doivent etre référencer dans un même endroit ?
// Faire une fusion du statmanager et effectmanager
public interface IEffect {

    // TODO ajouter un type d'effet (positif, negatif, neutre) (abstract classe ?)
    void OnStart(GameObject p_target);
	void Update(GameObject p_target);
	void OnEnd(GameObject p_target);
    bool IsOver();
}

/* IEffect et AStatModifier sont très similaires

    IEffecct
	void Update(GameObject p_target);
    
    AStatModifier
    public abstract float GetFactor(GameObject p_character);
	
	void OnStart(GameObject p_target);
    void OnEnd(GameObject p_target);
    bool IsOver();
     
     
     
     
     
     
     
     
     
     
     
     */
