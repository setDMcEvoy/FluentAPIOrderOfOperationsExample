using System;
using System.Collections.Generic;
using System.Text;

namespace FluentAPIOrderOfOperationsExample
{
    public class Order : ISelectStoreStep, ISetTimeStep, ISetUserNameStep, ISetPasswordStep, IAddItemStep
    {
        private string _store;
        private DateTime _timeToOrder;
        private string _userName;
        private string _password;
        private List<string> _items;
        
        // Private to force class creation statically
        private Order() { }

        public static ISelectStoreStep CreateOrder()
        {
            return new Order();
        }

        public ISetTimeStep AtStore(string store)
        {
            _store = store;
            return this;
        }

        public ISetUserNameStep ForTime(DateTime time)
        {
            _timeToOrder = time;
            return this;
        }

        public ISetPasswordStep ForUser(string username)
        {
            _userName = username;
            return this;
        }

        public IAddItemStep WithPassword(string password)
        {
            _password = password;
            return this;
        }

        public IAddItemStep AddItem(string item)
        {
            if (_items == null)
            {
                _items = new List<string>();
            }

            _items.Add(item);
            return this;
        }

        public bool Submit()
        {
            // submit the order
            return true;
        }
    }

    public interface ISelectStoreStep
    {
        public ISetTimeStep AtStore(string store);
    }

    public interface ISetTimeStep
    {
        public ISetUserNameStep ForTime(DateTime time);
    }

    public interface ISetUserNameStep
    {
        public ISetPasswordStep ForUser(string username);
    }

    public interface ISetPasswordStep
    {
        public IAddItemStep WithPassword(string password);
    }

    public interface IAddItemStep
    {
        public IAddItemStep AddItem(string item);

        public bool Submit();
    }

}
