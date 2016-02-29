using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class ClientDAO
    {
        string SQL_STRING = "server=(local); database=hotel; integrated security=true";

        SqlConnection con;

        public ClientDAO()
        {
            con = new SqlConnection(SQL_STRING);
        }

        public void Insert(Client cli)
        {

            con.Open();

            SqlCommand requete = new SqlCommand("insert into client (cli_nom, cli_prenom, cli_ville) values (@p1, @p2, @p3)", con);
            requete.Parameters.AddWithValue("@p1", cli.Nom);
            requete.Parameters.AddWithValue("@p2", cli.Prenom);
            requete.Parameters.AddWithValue("@p3", cli.Ville);

            requete.ExecuteNonQuery();
            con.Close();
        }

        public void Update(Client cli)
        {
            con.Open();

            SqlCommand requete = new SqlCommand("update client set cli_nom=@p1, cli_prenom=@p2, cli_ville=@p3 where cli_id=@p4", con);
            requete.Parameters.AddWithValue("@p1", cli.Nom);
            requete.Parameters.AddWithValue("@p2", cli.Prenom);
            requete.Parameters.AddWithValue("@p3", cli.Ville);
            requete.Parameters.AddWithValue("@p4", cli.Id);

            requete.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(Client cli)
        {
            con.Open();

            SqlCommand requete = new SqlCommand("delete from client where cli_id=@p1", con);
            requete.Parameters.AddWithValue("@p1", cli.Id);

            requete.ExecuteNonQuery();
            con.Close();
        }

        public Client Find(int id)
        {
            Client cli = new Client();

            con.Open();

            SqlCommand requete = new SqlCommand("select * from client where cli_id=@id", con);
            requete.Parameters.AddWithValue("@id", id);

            SqlDataReader resultat = requete.ExecuteReader();

            if (resultat.Read())
            {
                cli.Id = Convert.ToInt32(resultat["cli_id"]);
                cli.Nom = Convert.ToString(resultat["cli_nom"]);
                cli.Prenom = Convert.ToString(resultat["cli_prenom"]);
                cli.Ville = Convert.ToString(resultat["cli_ville"]);
            }

            return cli;
        }

        public List<Client> List()
        {
            List<Client> liste = new List<Client>();

            con.Open();

            SqlCommand requete = new SqlCommand("select * from client", con);

            SqlDataReader resultat = requete.ExecuteReader();

            while (resultat.Read())
            {
                Client cli = new Client();
                cli.Id = Convert.ToInt32(resultat["cli_id"]);
                cli.Nom = Convert.ToString(resultat["cli_nom"]);
                cli.Prenom = Convert.ToString(resultat["cli_prenom"]);
                cli.Ville = Convert.ToString(resultat["cli_ville"]);

                liste.Add(cli);
            }

            return liste;
        }
    }
}
