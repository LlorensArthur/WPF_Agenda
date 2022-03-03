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
    /// Logique d'interaction pour addCustomer.xaml
    /// </summary>
    public partial class addCustomer : Page
    {
        private readonly agendaContext db = new agendaContext();
        public addCustomer()
        {
            InitializeComponent();
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
        }
    }
}
