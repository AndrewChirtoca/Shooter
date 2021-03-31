using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneDamageEffect : MonoBehaviour
{
    [SerializeField]
    private Renderer _renderer;
    [SerializeField]
    private float _effectDuration = 1f;
    [SerializeField]
    private float _timeStep = 0.1f;
    private Coroutine _effectRoutineInstance;
    
    
    private static MaterialPropertyBlock _defaultMPB;
    private static MaterialPropertyBlock GetDefaultMPB(Renderer renderer)
    {
        if (_defaultMPB == null)
        {
            _defaultMPB = new MaterialPropertyBlock();
            renderer.GetPropertyBlock(_defaultMPB);
        }
        return _defaultMPB;
    }

    private static MaterialPropertyBlock _damagedMPB;
    private static MaterialPropertyBlock GetDamagedMPB(Renderer renderer)
    {
        if (_damagedMPB == null)
        {
            _damagedMPB = new MaterialPropertyBlock();
            renderer.GetPropertyBlock(_damagedMPB);
            _damagedMPB.SetColor("_BaseColor", Color.red);
            _damagedMPB.SetTexture("_BaseMap", Texture2D.whiteTexture);
        }
        return _damagedMPB;
    }

    [ContextMenu("TriggerEffect")]
    public void TriggerEffect()
    {
        if(_effectRoutineInstance != null)
            StopCoroutine(_effectRoutineInstance);
        
        StartCoroutine(EffectRoutine());
    }

    private IEnumerator EffectRoutine()
    {
        var defaultMPB = GetDefaultMPB(_renderer);
        var damagedMPB = GetDamagedMPB(_renderer);
        var cycleStep = false;
        var currentDuration = 0f;
        
        while (currentDuration < _effectDuration)
        {
            if (cycleStep)
            {
                _renderer.SetPropertyBlock(defaultMPB);
            }
            else
            {
                _renderer.SetPropertyBlock(damagedMPB);
            }
            
            yield return new WaitForSeconds(_timeStep);

            cycleStep = !cycleStep;
            currentDuration += _timeStep;
        }
        
        _renderer.SetPropertyBlock(defaultMPB);
        _effectRoutineInstance = null;
    }
}
