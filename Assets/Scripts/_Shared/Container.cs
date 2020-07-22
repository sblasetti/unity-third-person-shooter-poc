using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Container : MonoBehaviour
{
    private List<ContainerItem> items;

    class ContainerItem
    {
        public Guid Id;
        public string Name;
        public int Maximum;

        private int remaining;

        internal int Take(int amount)
        {
            var take = Math.Min(remaining, amount);
            remaining -= take;
            return take;
        }
    }

    private void Awake()
    {
        items = new List<ContainerItem>();
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
        if (item == null) return -1;

        return item.Take(amount);
    }
}
