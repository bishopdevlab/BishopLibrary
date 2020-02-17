using Bishop.DesignPattern.MVVM.Example.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bishop.DesignPattern.MVVM.Example.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private List<Customer> myCustomers;
        private Customer myCurrentCustomer;
        private CustomerRepository myRepository;

        public CustomerViewModel()
        {
            myRepository = new CustomerRepository();
            myCustomers = myRepository.GetCustomers();

            WireCommands();
        }

        private void WireCommands()
        {
            UpdateCustomerCommand = new RelayCommand(UpdateCustomer);
        }

        public RelayCommand UpdateCustomerCommand
        {
            get;
            private set;
        }

        public List<Customer> Customers
        {
            get { return myCustomers; }
            set { myCustomers = value; }
        }

        public Customer CurrentCustomer
        {
            get
            {
                return myCurrentCustomer;
            }

            set
            {
                if (myCurrentCustomer != value)
                {
                    myCurrentCustomer = value;
                    OnPropertyChanged("CurrentCustomer");
                    UpdateCustomerCommand.IsEnabled = true;
                }
            }
        }

        public void UpdateCustomer()
        {
            myRepository.UpdateCustomer(CurrentCustomer);
        }
    }
}
