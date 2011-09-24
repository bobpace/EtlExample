using System;
using Rhino.Mocks;
using StructureMap.AutoMocking;

namespace EtlExample.Tests
{
    public abstract class Verifies<TClass> : Verifies<TClass, TClass>
        where TClass : class
    {
    }

    public abstract class Verifies<TContract, TImplementation> : IDisposable
        where TImplementation : class, TContract
    {
        protected Verifies()
        {
            Services = new RhinoAutoMocker<TImplementation>();
        }

        public TContract SUT { get { return Services.ClassUnderTest; } }

        public RhinoAutoMocker<TImplementation> Services { get; private set; }

        public TService MockFor<TService>() where TService : class
        {
            return Services.Get<TService>();
        }

        public void VerifyCallsFor<TMock>() where TMock : class
        {
            MockFor<TMock>().VerifyAllExpectations();
        }

        public virtual void Dispose()
        {
            Services.Container.Dispose();
        }
    }
}