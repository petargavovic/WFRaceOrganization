using DatabaseBroker;
using System;
using System.Diagnostics;

namespace Server.SystemOperation
{
    public abstract class SystemOperationBase
    {
        protected Broker broker;

        public SystemOperationBase()
        {
            broker = new Broker();
        }

        public void ExecuteTemplate()
        {
            using (broker)
            {
                broker.OpenConnection();
                broker.BeginTransaction();
                try
                {
                    if (Conditions())
                        ExecuteConcreteOperation();
                    broker.Commit();
                }
                catch (Exception ex)
                {
                    broker.Rollback();
                    throw ex;
                }
            }
        }

        protected abstract void ExecuteConcreteOperation();
        public virtual bool Conditions() { return true; }
    }
}
