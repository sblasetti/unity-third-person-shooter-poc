using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Container : MonoBehaviour
{
    public List<ContainerItem> items;
    public Action OnReady;

    [Serializable]
    public class ContainerItem
    {
        public Guid Id;
        public string Name;
        public int Maximum;
        public int taken;

        private int remaining => Maximum - taken;

        internal int Take(int amount)
        {
            var take = Math.Min(remaining, amount);
            taken += take;
            return take;
        }
    }

    private void Awake()
    {
        items = new List<ContainerItem>();
        OnReady?.Invoke();
    }

    public Guid Add(string name, int max)
    {
        var id = Guid.NewGuid();

        items.Add(new ContainerItem
        {
            Id = id,
            Name = name,
            Maximum = max
        });

        return id;
    }

    public int Take(Guid id, int amount)
    {
        var item = items.FirstOrDefault(x => x.Id == id);
        if (item == null) return 0;

        return item.Take(amount);
    }
}
