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
    /// Interaction logic for AppointmentList.xaml
    /// </summary>
    public partial class AppointmentList : Page
    {
        private readonly agendaContext db = new agendaContext();
        public AppointmentList()
        {
            InitializeComponent();
            List<Appointment> appointments = db.Appointments.ToList();
            gridAppointments.ItemsSource = appointments;
        }

        private void Delete_Appointment(object sender, RoutedEventArgs e)
        {
            DataGridCellInfo row = gridAppointments.SelectedCells[0];
            Appointment appointment = row.Item as Appointment;
            db.Remove(appointment);
            db.SaveChanges();
            List<Appointment> appointments = db.Appointments.ToList();
            gridAppointments.ItemsSource = appointments;

        }
        Appointment selectedAppointment;

        private void Update_Appointment(object sender, RoutedEventArgs e)
        {
            db.Update(selectedAppointment);
            db.SaveChanges();
            List<Appointment> appointments = db.Appointments.ToList();
            gridAppointments.ItemsSource = appointments;
        }

        private void selectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;
            SetAppointmentsProperties(dataGrid.SelectedItem as Appointment);

        }

        private void Add_Appointment(object sender, RoutedEventArgs e)
        {

        }

        private void SetAppointmentsProperties(Appointment appointment)
        {
            if (appointment == null)
                return;
            selectedAppointment = appointment;
        }

    }
}
