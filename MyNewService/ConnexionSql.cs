using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewService
{
            public class ConnexionSql
            {

                private static MySqlConnection Oconn = null;

                //Constructor
                private ConnexionSql(string unServeur, string unUser, string uneDataBase)
                {
                    string connectionString;
                    connectionString = "server=" + unServeur + ";" + "user id=" + unUser + ";" + "database=" + uneDataBase + "";

                    Oconn = new MySqlConnection(connectionString);
                }


                public static void getInstance(string unServeur, string unUser, string uneDataBase)
                {
                    if (null == Oconn)
                    { // Premier appel
                      //  ConnexionSql.Initialize(unServeur, unUser, uneDataBase);

                        new ConnexionSql(unServeur, unUser, uneDataBase);

                    }
                    //return Oconn;
                }


                public static MySqlConnection getConnection()
                {
                    return (Oconn);

                }



                //open connection to database
                public static void OpenConnection()
                {
                    Oconn.Open();
                }

                //Close connection
                public static void CloseConnection()
                {
                    Oconn.Close();
                }
            }

        }
