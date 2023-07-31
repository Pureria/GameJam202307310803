using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Core : MonoBehaviour
{
    private List<CoreComponent> CoreComponents = new List<CoreComponent>();

    private void Update()
    {
        foreach(CoreComponent component in CoreComponents)
        {
            component.LogicUpdate();
        }
    }

    public void AddCoreComponent(CoreComponent component)
    {
        //���ɓ����R���|�[�l���g�����݂���ꍇ�͒ǉ����Ȃ�
        if (CoreComponents.Contains(component)) return;

        CoreComponents.Add(component);
    }

    public T GetCoreComponent<T>(T value) where T:CoreComponent
    {
        var comp = CoreComponents.OfType<T>().FirstOrDefault();

        if (comp == null)
            Debug.LogWarning($"{typeof(T)}��{transform.parent.name}�ɑ��݂��܂���B");

        return comp;
    }

    public T GetCoreComponent<T>(ref T value) where T:CoreComponent
    {
        value = GetCoreComponent(value);
        return value;
    }
}
