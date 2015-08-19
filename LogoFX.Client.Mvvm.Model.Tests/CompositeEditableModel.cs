﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using LogoFX.Client.Mvvm.Model.Contracts;

namespace LogoFX.Client.Mvvm.Model.Tests
{
    interface ICompositeEditableModel : IEditableModel
    {
        [EditableList]
        IEnumerable<int> Phones { get; }

        SimpleEditableModel Person { get; set; }

        IEnumerable<SimpleEditableModel> SimpleCollection { get; } 
    }

    class CompositeEditableModel : EditableModel, ICompositeEditableModel
    {       
        public CompositeEditableModel(string location)
        {                                      
            Location = location; 
            Person = new SimpleEditableModel();           
        }

        public CompositeEditableModel(string location, IEnumerable<int> phones)
        {
            Location = location;
            Person = new SimpleEditableModel();
            Phones.AddRange(phones);
        }

        public CompositeEditableModel(string location, IEnumerable<SimpleEditableModel> simpleCollection)
        {
            Location = location;
            Person = new SimpleEditableModel();
            foreach (var simpleEditableModel in simpleCollection)
            {
                _simpleCollection.Add(simpleEditableModel);
            }            
        }

        public string Location { get; private set; }

        private SimpleEditableModel _person;        

        public SimpleEditableModel Person
        {
            get { return _person; }
            set
            {
                _person = value;
                NotifyOfPropertyChange();
            }
        }

        private readonly ObservableCollection<SimpleEditableModel> _simpleCollection = new ObservableCollection<SimpleEditableModel>();        

        public IEnumerable<SimpleEditableModel> SimpleCollection
        {
            get { return _simpleCollection; }
        }

        private readonly List<int> _phones = new List<int>();
        
        IEnumerable<int> ICompositeEditableModel.Phones
        {
            get { return _phones; }
        }        
        private List<int> Phones
        {
            get { return _phones; }
        }

        public void AddPhone(int number)
        {
            MakeDirty();
            _phones.Add(number);
        }

        public void RemoveSimpleItem(SimpleEditableModel item)
        {
            MakeDirty();
            _simpleCollection.Remove(item);
        }
    }

    class ExplicitCompositeEditableModel : EditableModel, ICompositeEditableModel
    {
        public ExplicitCompositeEditableModel(string location)
        {
            Location = location;
            Person = new SimpleEditableModel();
        }

        public ExplicitCompositeEditableModel(string location, IEnumerable<int> phones)
        {
            Location = location;
            Person = new SimpleEditableModel();
            Phones.AddRange(phones);
        }

        public ExplicitCompositeEditableModel(string location, IEnumerable<SimpleEditableModel> simpleCollection)
        {
            Location = location;
            Person = new SimpleEditableModel();
            foreach (var simpleEditableModel in simpleCollection)
            {
                _simpleCollection.Add(simpleEditableModel);
            }
        }

        public string Location { get; private set; }

        private SimpleEditableModel _person;

        public SimpleEditableModel Person
        {
            get { return _person; }
            set
            {
                _person = value;
                NotifyOfPropertyChange();
            }
        }

        private readonly ObservableCollection<SimpleEditableModel> _simpleCollection = new ObservableCollection<SimpleEditableModel>();

        IEnumerable<SimpleEditableModel> ICompositeEditableModel.SimpleCollection
        {
            get { return _simpleCollection; }
        }

        private readonly List<int> _phones = new List<int>();

        IEnumerable<int> ICompositeEditableModel.Phones
        {
            get { return _phones; }
        }
        private List<int> Phones
        {
            get { return _phones; }
        }

        public void AddPhone(int number)
        {
            MakeDirty();
            _phones.Add(number);
        }

        public void RemoveSimpleItem(SimpleEditableModel item)
        {
            MakeDirty();
            _simpleCollection.Remove(item);
        }
    }    
}