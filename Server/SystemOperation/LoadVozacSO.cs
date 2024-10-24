using Common.Domen;

namespace Server.SystemOperation
{
    public class LoadVozacSO : SystemOperationBase
    {
        private readonly Vozac vozac;
        public Vozac Result { get; set; }

        public LoadVozacSO(Vozac vozac)
        {
            this.vozac = vozac;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = (Vozac)broker.GetById(vozac);
        }
    }
}
