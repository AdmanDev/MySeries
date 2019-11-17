using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MySeries
{
    public partial class AddSerie_Window : Window
    {
        //Variables
        public Category category;
        private bool editMode;
        private MSerie serieToEdit;

        //Constructor
        private void CommonConstructor()
        {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(App.LanguageResources);
        }


        public AddSerie_Window(Category _category)
        {
            CommonConstructor();

            category = _category;
            editMode = false;
        }

        public AddSerie_Window(Category _category, MSerie _serieToEdit)
        {
            CommonConstructor();

            category = _category;
            editMode = true;
            serieToEdit = _serieToEdit;

            this.TB_Name.Text = _serieToEdit.Title;
            this.NUD_Rating.Value = _serieToEdit.Rating;
            this.TB_Author.Text = _serieToEdit.Author;
            this.NUD_ReleaseDate.Value = _serieToEdit.ReleaseDate;
            this.TB_Genre.Text = _serieToEdit.Genre;
            this.CB_Language.Text = _serieToEdit.Language;
            this.CB_State.Text = _serieToEdit.State;
            this.NUD_NbEpisode.Value = _serieToEdit.EpisodeNb;
            this.TB_Synopsis.Text = _serieToEdit.Synopsis;
            this.IMG_Poster.Source = MyFunctions.WpfFunctions.BitmapToImageSource(_serieToEdit.Poster);
        }

        //Move the window
        private void HeaderGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        //Close this window
        private void BT_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NUD_Rating_ValueChanged(float obj)
        {
            this.IPB_Rating.Value = (int)obj;
        }

        //Choose poster
        private void BT_ChoosePoster_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            };

            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.IMG_Poster.Source = new BitmapImage(new Uri(ofd.FileName));
            }
        }

        //Add or edit the serie and save
        private void BT_SaveSerie_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(this.TB_Name.Text) || string.IsNullOrWhiteSpace(this.TB_Name.Text))
            {
                System.Windows.MessageBox.Show((string)App.LanguageResources["EnterAllFields"], "MySerie", MessageBoxButton.OK);
                return;
            }

            Bitmap poster = null;
            if (this.IMG_Poster.Source != null)
            {
                poster = MyFunctions.WpfFunctions.BitmapImageToBitmap((BitmapImage)this.IMG_Poster.Source);
            }

            MSerie serie = new MSerie(this.TB_Name.Text, this.TB_Author.Text, this.TB_Genre.Text, this.CB_Language.Text, this.CB_State.Text, this.TB_Synopsis.Text, (int)this.NUD_NbEpisode.Value, (int)this.NUD_ReleaseDate.Value, (int)this.NUD_Rating.Value, poster, false);

            if (editMode)
            {// Edit the serie
                category.SeriesList.Remove(serieToEdit);
            }

            category.AddSerie(serie);

            Category.Save();
            this.DialogResult = true;
        }

    }
}
