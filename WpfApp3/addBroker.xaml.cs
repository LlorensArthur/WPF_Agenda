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
    /// Interaction logic for addBroker.xaml
    /// </summary>
    public partial class addBroker : Page
    {
        private readonly agendaContext db = new agendaContext();

        public addBroker()
        {
            InitializeComponent();
        }

        private void Register_Broker(object sender, RoutedEventArgs e)
        {
            Broker broker = new Broker();
            broker.Firstname = firstname.Text;
            broker.Lastname = lastname.Text;
            broker.Mail = mail.Text;
            broker.PhoneNumber = phonenumber.Text;
            db.Add(broker);
            db.SaveChanges();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
        }
    }
}
