using UnityEngine;

public class AttributeComparisonReq : IRequirement
{
    public enum ComparisonType
    {
        Equal,
        NotEqual,
        GreaterThan,
        GreaterThanOrEqual,
        LesserThan,
        LesserThanOrEqual,
    }

    int _attributeType;
    float _threshold;
    ComparisonType _comparisonType;

    public AttributeComparisonReq(int p_attributeType, float p_threshold, ComparisonType p_comparisonType)
    {
        _attributeType = p_attributeType;
        _threshold = p_threshold;
        _comparisonType = p_comparisonType;
    }
    
	public bool IsValid(GameObject p_owner)
    {
        Attribute<float> attribute = p_owner.GetComponent<AttributeManager>().GetAttribute<float>(_attributeType);
        
        bool isValid = false;
        switch (_comparisonType)
        {
            case ComparisonType.Equal:
                isValid = attribute.Value == _threshold;
            break;
            case ComparisonType.NotEqual:
                isValid = attribute.Value != _threshold;
            break;
            case ComparisonType.GreaterThan:
                isValid = attribute.Value > _threshold;
            break;
            case ComparisonType.GreaterThanOrEqual:
                isValid = attribute.Value >= _threshold;
            break;
            case ComparisonType.LesserThan:
                isValid = attribute.Value < _threshold;
            break;
            case ComparisonType.LesserThanOrEqual:
                isValid = attribute.Value <= _threshold;
            break;
            default:
            throw new System.NotImplementedException();

        }

        return isValid;
	}
}
