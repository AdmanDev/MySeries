using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Drawing;

namespace MySeries
{
    //Old class
    [Serializable]
    public class Serie
    {
        public String Titre { get; set; }
        public String Auteur { get; set; }
        public String Genre { get; set; }
        public String Langue { get; set; }
        public String Statut { get; set; }
        public String Histoire { get; set; }
        public int NbEpisode { get; set; }
        public int DateSortie { get; set; }
        public int Note { get; set; }
        public string Affiche { get; set; }
        public bool Favorite { get; set; }

        public Serie()
        {

        }

        public Serie(string titre, string auteur, string genre, string langue, string statut, string histoire, int nbEpisode, int dateSortie, int note, string affiche, bool favorite)
        {
            Titre = titre;
            Auteur = auteur;
            Genre = genre;
            Langue = langue;
            Statut = statut;
            Histoire = histoire;
            NbEpisode = nbEpisode;
            DateSortie = dateSortie;
            Note = note;
            Affiche = affiche;
            Favorite = favorite;
        }

        public static List<Serie> Deserialize(string filePath)
        {
            List<Serie> seriesListe = null;
            try
            {
                if (File.Exists(filePath))
                {
                    FileStream fluxFichier = File.OpenRead(filePath);
                    try
                    {
                        XmlSerializer deserialisation = new XmlSerializer(typeof(List<Serie>));

                        seriesListe = deserialisation.Deserialize(fluxFichier) as List<Serie>;
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show(e.Message, "MySeries", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                    finally
                    {
                        fluxFichier.Close();
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "MySeries", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return seriesListe;
        }

        public static List<MSerie> Upgrade()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                return UpgradeFile(ofd.FileName);
            }

            return null;
        }

        public static List<MSerie> UpgradeFile(string filePath = "")
        {
            if(filePath == "")
                filePath = Application.StartupPath + @"\" + "My_Series.bin";

            List<Serie> oldSeriesList = Deserialize(filePath);

            if (oldSeriesList != null)
            {
                List<MSerie> newSeriesList = new List<MSerie>();
                foreach (Serie s in oldSeriesList)
                {
                    newSeriesList.Add(new MSerie(s.Titre, s.Auteur, s.Genre, s.Langue, s.Statut, s.Histoire, s.NbEpisode, s.DateSortie, s.Note, (Bitmap)StringToImage(s.Affiche), s.Favorite));
                }
                return newSeriesList;
            }
            return null;
        }

        public static Image StringToImage(string imageString)
        {
            if (imageString == "")
                return null;

            byte[] array = Convert.FromBase64String(imageString);

            Image image = Image.FromStream(new MemoryStream(array));

            return image;
        }


    }
}
