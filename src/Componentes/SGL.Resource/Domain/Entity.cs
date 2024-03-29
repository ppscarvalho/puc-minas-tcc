﻿#nullable disable

using FluentValidation.Results;
using SGL.Resource.Interfaces;
using SGL.Resource.Messagens;
using System;
using System.Collections.Generic;

namespace SGL.Resource.Domain
{
    public abstract class Entity : IAggregateRoot
    {
        public Guid Id { get; set; }
        public DateTime CriadoEm { get; protected set; }
        public DateTime? ModificadoEm { get; protected set; }
        public int CriadoPor { get; protected set; }
        public int? ModificadoPor { get; protected set; }

        private List<Event>? _notifications;
        public IReadOnlyCollection<Event>? Notifications => _notifications?.AsReadOnly();

        public ValidationResult? ValidationResult { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public void AddEvent(Event evento)
        {
            _notifications = _notifications ?? new List<Event>();
            _notifications.Add(evento);
        }

        public void RemoveEvent(Event eventItem)
        {
            _notifications?.Remove(eventItem);
        }

        public void ClearEvent()
        {
            _notifications?.Clear();
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
