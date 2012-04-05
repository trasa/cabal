using System;
using System.Collections.Generic;
using Cabal.Client.Core.Infrastructure;
using Cabal.Client.Core.Model;
using Cabal.Client.Test.Infrastructure;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Events;
using Moq;
using NUnit.Framework;

namespace Cabal.Client.Test.PresentationModels
{
    [TestFixture]
    public abstract class PresentationModelFixture<TView> where TView : class 
    {
        protected SessionState SessionState { get; set;}
        protected StubCommandsProxy CommandsProxy { get; set; }
        protected Mock<IEventAggregator> EventAggregator { get; set; }
        protected Mock<TView> MockView { get; set; }
        protected MockGlobalRegions GlobalRegions { get; set; }
        
        
        private Dictionary<Type, bool> eventSubscriptions;

        [SetUp]
        public virtual void SetUp()
        {
            eventSubscriptions = new Dictionary<Type, bool>();
            SessionState = new SessionState();
            CommandsProxy = new StubCommandsProxy();
            EventAggregator = new Mock<IEventAggregator>();
            MockView = new Mock<TView>();
            GlobalRegions = new MockGlobalRegions();
        }

        protected void SubscribeToEvent<TEvent, TPayload>(Action<TPayload> subscribeAction)
            where TEvent : CompositePresentationEvent<TPayload>
        {
            var evt = Activator.CreateInstance<TEvent>();
            EventAggregator.Setup(ea => ea.GetEvent<TEvent>()).Returns(evt);
            eventSubscriptions.Add(typeof(TEvent), false);
            evt.Subscribe(payload =>
                              {
                                  subscribeAction(payload);
                                  eventSubscriptions[typeof(TEvent)] = true;
                              });
        }
		
        protected bool VerifyEventRaised<TEvent>()
        {
            bool b;
            eventSubscriptions.TryGetValue(typeof(TEvent), out b);
            return b;
        }
    }
}
