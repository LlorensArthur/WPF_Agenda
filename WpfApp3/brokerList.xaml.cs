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
    /// Interaction logic for brokerList.xaml
    /// </summary>
    public partial class brokerList : Page
    {
        private readonly agendaContext db = new agendaContext();

        public brokerList()
        {
            InitializeComponent();
        }

        private void Add_Broker(object sender, RoutedEventArgs e)
        {
            Broker broker = new Broker();
            broker.Firstname = firstname.Text;
            broker.Lastname = lastname.Text;
            broker.Mail = mail.Text;
            broker.PhoneNumber = phonenumber.Text;
            db.Add(broker);
            db.SaveChanges();
            List<Broker> brokers = db.Brokers.ToList();
            gridBrokers.ItemsSource = brokers;
        }

        private void Delete_Broker(object sender, RoutedEventArgs e)
        {
            DataGridCellInfo row = gridBrokers.SelectedCells[0];
            Broker broker = row.Item as Broker;
            db.Remove(broker);
            db.SaveChanges();
            List<Broker> brokers = db.Brokers.ToList();
            gridBrokers.ItemsSource = brokers;
        }

        Broker selectedBroker;
        private void Update_Broker(object sender, RoutedEventArgs e)
        {
            selectedBroker.Firstname = firstname.Text;
            selectedBroker.Lastname = lastname.Text;
            selectedBroker.Mail = mail.Text;
            selectedBroker.PhoneNumber = phonenumber.Text;
            db.Update(selectedBroker);
            db.SaveChanges();
            List<Broker> brokers = db.Brokers.ToList();
            gridBrokers.ItemsSource = brokers;
        }

        private void SetBrokersProperties(Broker broker)
        {
            if (broker == null)
                return;
            firstname.Text = broker.Firstname;
            lastname.Text = broker.Lastname;
            mail.Text = broker.Mail;
            phonenumber.Text = broker.PhoneNumber;
            selectedBroker = broker;
        }

        private void selectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;
            SetBrokersProperties(dataGrid.SelectedItem as Broker);
        }
    }
}
