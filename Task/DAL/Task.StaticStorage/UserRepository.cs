﻿using System.Collections.Generic;
using System.Linq;
using Task.CommonTypes.Interfaces;

namespace Task.StaticStorage
{
    public class UserRepository<T> : IRepository<T>
        where T : IUser
    {
        private static readonly List<T> userList = new List<T>();
        private static int id = 0;

        public UserRepository()
        {

        }

        public int Add(T item)
        {
            var it = userList.FirstOrDefault(i => i.Id == item.Id);

            if (it == null)
            {
                item.Id = id++;
                userList.Add(item);
            }

            return it == null ? item.Id : -1;
        }

        public bool Delete(int id)
        {
            return userList.Remove(userList.Find(it => it.Id == id));
        }

        public T Get(int id)
        {
            return userList.FirstOrDefault(it => it.Id == id);
        }

        public T Update(int id, T item)
        {
            var result = Get(id);

            if (result != null)
            {
                result = item;
            }

            return result;
        }

        IEnumerable<T> IRepository<T>.Get()
        {
            return userList;
        }
    }
}