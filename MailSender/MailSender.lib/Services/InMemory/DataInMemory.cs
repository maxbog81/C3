﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data.BaseEntityes;

namespace MailSender.lib.Services.InMemory
{
    public abstract class DataInMemory<T> : IDataService<T> where T : Entity
    {
        protected readonly List<T> _Items = new List<T>();

        public IEnumerable<T> GetAll() => _Items;

        public T GetById(int id)
        {
            if(id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Значение id должно быть больше 0");

            return _Items.FirstOrDefault(item => item.Id == id);
        }

        public void Add(T item)
        {
            if(_Items.Any(i => i.Id == item.Id)) return;
            item.Id = _Items.Count == 0 ? 1 : _Items.Max(i => i.Id) + 1;
            _Items.Add(item);
        }

        public abstract void Edit(T item);

        public void Delete(T item)
        {
            _Items.Remove(item);
        }
    }
}
