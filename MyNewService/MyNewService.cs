using MySql.Data.MySqlClient;
using System;
using System.ServiceProcess;
using System.Timers;


namespace MyNewService
{
    public partial class MyNewService : ServiceBase
    {
        private System.Diagnostics.EventLog eventLog1;
        private MySqlConnection Oconn;
        private string connectionString = "server = localhost; user id = root; persistsecurityinfo=False;database=gmanzola";
        private int eventId;

        public MyNewService()
        {
            InitializeComponent();
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
            

        }

        protected override void OnStart(string[] args)
        {

            eventLog1.WriteEntry("In OnStart");
            Timer timer = new Timer();
            timer.Interval = 21600; // 6 heures en secondes
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            // TODO: Insert monitoring activities here.
            eventLog1.WriteEntry("Monitoring the System", System.Diagnostics.EventLogEntryType.Information, eventId++);
            Oconn = new MySqlConnection(connectionString);      //Instance de connexion
            Oconn.Open();

            string jourActuel = DateTime.Now.ToString("yyyy-MM-dd");

            try { 
            if ( GestionDate.dansLintervalleCL() == true)
            {
                MySqlCommand cloture = new MySqlCommand("update fichefrais set idetat ='cl', datemodif='" + jourActuel + "'  where idetat='cr' and mois='" + GestionDate.moisPrecedent() + "'", Oconn);
                cloture.ExecuteNonQuery();
                Oconn.Close();
            }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Echec dans la méthode dansLintervalleCL" + ex);
            }

            try { 
                if (GestionDate.dansLintervalleRB() == true)
                {
                MySqlCommand remboursement = new MySqlCommand("update fichefrais set idetat ='rb', datemodif='" + jourActuel + "'  where idetat='va' and mois='" + GestionDate.moisPrecedent() + "'", Oconn);
                remboursement.ExecuteNonQuery();
                Oconn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Echec dans la méthode dansLintervalleRB" + ex);
            }


        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In onStop.");
        }
    }
}
