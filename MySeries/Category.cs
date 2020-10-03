using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MySeries
{
    [Serializable]
    public class Category
    {
        //Const variable
        private static string savePath = Application.StartupPath + @"\" + "MySeries.series";

        //Variables
        public string name;
        private List<MSerie> seriesList;

        //Properties
        public int SeriesCount { get => seriesList.Count; }
        public List<MSerie> SeriesList { get => seriesList; }

        //Constructors
        public Category()
        {
            name = "Undefined";
            seriesList = new List<MSerie>();
        }

        public Category(string _name, List<MSerie> _series)
        {
            name = _name;
            seriesList = _series;
        }

        public Category(string _name)
        {
            name = _name;
            seriesList = new List<MSerie>();
        }

        public void AddSerie(MSerie serie)
        {
            if (serie == null)
                return;

            seriesList.Add(serie);
        }

        public void AddRange(List<MSerie> series)
        {
            if (series == null || series.Count<MSerie>() <= 0)
                return;

            SeriesList.AddRange(series);
        }

        public void Remove(MSerie serie)
        {
            seriesList.Remove(serie);
        }

        public void Remove(int index)
        {
            seriesList.RemoveAt(index);
        }

        //STATIC FUNCTIONS

        public static List<Category> Open()
        {
            List<Category> result = MyFunctions.FileManager.Deserialize<List<Category>>(savePath);
           
            //Si la liste contient aucune catégorie, on en ajoutera une par défaut
            if (result.Count <= 0)
            {
                result.Add(new Category("Series", new List<MSerie>()));
            }

            return result;
        }

        public static void Save()
        {
            MyFunctions.FileManager.Serialize<List<Category>>(savePath, Global.categoriesList);
        }
    }
}
