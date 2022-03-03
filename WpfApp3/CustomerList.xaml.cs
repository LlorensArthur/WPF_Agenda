using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp3.Data;
using WpfApp3.Models;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for CustomerList.xaml
    /// </summary>
    public partial class CustomerList : Page
    {

        private readonly agendaContext db = new agendaContext();
        public CustomerList()
        {
            InitializeComponent();
            List<Customer> customers = db.Customers.ToList();
            gridCustomers.ItemsSource = customers;
        }
        private void Add_Customer(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer.Firstname = firstname.Text;
            customer.Lastname = lastname.Text;
            customer.Mail = mail.Text;
            customer.PhoneNumber = phonenumber.Text;
            customer.Budget = int.Parse(budget.Text);
            db.Add(customer);
            db.SaveChanges();
            List<Customer> customers = db.Customers.ToList();
            gridCustomers.ItemsSource = customers;
        }

        private void Delete_Customer(object sender, RoutedEventArgs e)
        {
            DataGridCellInfo row = gridCustomers.SelectedCells[0];
            Customer customer = row.Item as Customer;
            db.Remove(customer);
            db.SaveChanges();
            List<Customer> customers = db.Customers.ToList();
            gridCustomers.ItemsSource = customers;
        }

        Customer selectedCustomer;
        private void Update_Customer(object sender, RoutedEventArgs e)
        {
            selectedCustomer.Firstname = firstname.Text;
            selectedCustomer.Lastname = lastname.Text;
            selectedCustomer.Mail = mail.Text;
            selectedCustomer.PhoneNumber = phonenumber.Text;
            selectedCustomer.Budget = int.Parse(budget.Text);
            db.Update(selectedCustomer);
            db.SaveChanges();
            List<Customer> customers = db.Customers.ToList();
            gridCustomers.ItemsSource = customers;
        }

        private void SetCustomersProperties(Customer customer)
        {
            if (customer == null)
                return;
            firstname.Text = customer.Firstname;
            lastname.Text = customer.Lastname;
            mail.Text = customer.Mail;
            phonenumber.Text = customer.PhoneNumber;
            budget.Text = customer.Budget.ToString();
            selectedCustomer = customer;
        }

        private void selectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;
            SetCustomersProperties(dataGrid.SelectedItem as Customer);
        }
    }
}
