﻿using System;
using CQRSlite.Domain;
using CQRSlite.Events;

namespace CQRSlite.Tests.Substitutes
{
    public class TestAggregate : AggregateRoot
    {
        private TestAggregate() : base(Guid.Empty){}
        public TestAggregate(Guid id) : base(id)
        {
            ApplyChange(new TestAggregateCreated(id));
        }
        public int DidSomethingCount;

        public void DoSomething()
        {
            ApplyChange(new TestAggregateDidSomething());
        }

        public void DoSomethingElse()
        {
            ApplyChange(new TestAggregateDidSomeethingElse());
        }

        public void Apply(TestAggregateDidSomething e)
        {
            DidSomethingCount++;
        }

    }

    public class TestAggregateCreated : IEvent
    {
        private readonly Guid _id;

        public TestAggregateCreated(Guid id)
        {
            _id = id;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }

    public class TestAggregateNoParameterLessConstructor : AggregateRoot
    {
        public TestAggregateNoParameterLessConstructor(int i, Guid id) : base(id)
        {
        }

        public void DoSomething()
        {
            ApplyChange(new TestAggregateDidSomething());
        }
    }
}