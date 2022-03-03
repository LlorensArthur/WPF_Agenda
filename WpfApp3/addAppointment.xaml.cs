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
    /// Interaction logic for addAppointment.xaml
    /// </summary>
    public partial class addAppointment : Page
    {
        private readonly agendaContext db = new agendaContext();
        public addAppointment()
        {
            InitializeComponent();
            cmbCustomers.ItemsSource = db.Customers.ToList();
            cmbBrokers.ItemsSource = db.Brokers.ToList();
        }

        private void SaveAppointment(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.IdBroker = cmbBrokers.SelectedIndex + 1;
            appointment.IdCustomer = cmbCustomers.SelectedIndex + 1;
            appointment.DateHour = appointmentDate.DisplayDate;
            appointment.DateHour = appointment.DateHour.AddHours(double.Parse(appointmentHour.Text));
            appointment.DateHour = appointment.DateHour.AddMinutes(double.Parse(appointmentMinutes.Text));
            appointment.Subject = $"Customer {((Customer)cmbCustomers.SelectedValue).Firstname} meets broker {cmbBrokers.SelectedValue} the {appointment.DateHour.ToString("yyyy'-'MM'-'dd' at 'HH':'mm")}";
            db.Add(appointment);
            db.SaveChanges();
        }
    }
}
