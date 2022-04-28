using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile _сurrentPile = null;
    public float ProductivityMultiplier = 2;

    protected override void BuildingInRange()
    {
        if (_сurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                _сurrentPile = pile;
                _сurrentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
    }

    private void ResetProductivity()
    {
        if (_сurrentPile != null)
        {
            _сurrentPile.ProductionSpeed /= ProductivityMultiplier;
            _сurrentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity(); 
        base.GoTo(target); 
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }


}
