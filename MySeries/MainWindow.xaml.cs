using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using MyFunctions;
namespace MySeries
{
    public partial class MainWindow : Window
    {
        //Variables
        private BitmapImage noFavoriteImg;
        private BitmapImage favoriteImg;
        private ContextMenu categoriesMenu;
        private WPF_ADMANMenu mn_adman = new WPF_ADMANMenu();

        private Category selectedCategory;
        private MSerie selectedSerie;

        //Delegates
        private Action searchSerie;

        //Properies
        public Category SelectedCategory
        {
            get => selectedCategory;

            private set
            {
                if (value == null)
                    return;

                selectedCategory = value;
                UpdateSeriesListVew(Series);

                SetDefaultSerie();
            }
        }
        public List<MSerie> Series { get => SelectedCategory.SeriesList; }
        public MSerie SelectedSerie
        {
            get => selectedSerie;
            private set
            {
                selectedSerie = value;
                ShowSerieInfos(value);
            }
        }

        //Constructor
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Resources.MergedDictionaries.Add(App.LanguageResources);
        }

        //Move application
        private void HeaderGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        //Close application
        private void BT_CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Load
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            noFavoriteImg = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/UIs/Star - No favorite.png"));
            favoriteImg = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/UIs/Star - favorie.png"));
            categoriesMenu = (ContextMenu)this.FindResource("CategoriesMenu");

            LoadCategories();
            SelectedCategory = Global.categoriesList[0];

            SetDefaultSerie();

        }


        private void SetDefaultSerie()
        {
            if (Series.Count > 0)
                this.LB_Series.SelectedIndex = 0;
            else
                ClearInfos();

            this.Group_SeriesList.Header = SelectedCategory.name + " (" + Series.Count + ")";
        }

        private void ClearInfos()
        {
            this.RatingBar.Rate = 0;
            this.IMG_SeriePoster.Source = null;
            this.LB_Title.Content = null;
            this.LB_Author.Text = null;
            this.LB_ReleaseDate.Text = null;
            this.LB_Genre.Text = null;
            this.LB_Languages.Text = null;
            this.LB_State.Text = null;
            this.LB_NbEpisode.Text = null;
            this.TB_Synopsis.Text = null;
            this.IMG_Favorite.Source = noFavoriteImg;

            SelectedSerie = null;

        }

        private void LoadCategories()
        {
            this.CB_Categories.Items.Clear();

            Label lb;
            foreach (Category c in Global.categoriesList)
            {
                lb = new Label() { Content = c.name};
                lb.ContextMenu = categoriesMenu;
                lb.ContextMenuOpening += Categories_ContextMenuOpening;

                this.CB_Categories.Items.Add(lb);
            }
            
            this.CB_Categories.Items.Add((Button)this.FindResource("BT_AddCategory"));
        }

        private void Categories_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            categoriesMenu.Tag = e.Source;
        }

        private void UpdateSeriesListVew(List<MSerie> _seriesList)
        {
            if (_seriesList == null)
                return;

            this.LB_Series.Items.Clear();
            foreach (MSerie s in _seriesList)
            {
                this.LB_Series.Items.Add(s.Title);
            }

            //Sort items
            this.LB_Series.Items.SortDescriptions.Add(
            new System.ComponentModel.SortDescription("",
            System.ComponentModel.ListSortDirection.Ascending));

        }

        private void ShowSerieInfos(MSerie serie)
        {
            if (serie == null)
                return;

            this.RatingBar.Rate = serie.Rating;
            this.IMG_SeriePoster.Source = WpfFunctions.BitmapToImageSource(serie.Poster);
            this.LB_Title.Content = serie.Title;
            this.LB_Author.Text = serie.Author;
            this.LB_ReleaseDate.Text = serie.ReleaseDate.ToString();
            this.LB_Genre.Text = serie.Genre;
            this.LB_Languages.Text = serie.Language;
            this.LB_State.Text = serie.State;
            this.LB_NbEpisode.Text = serie.EpisodeNb.ToString();
            this.TB_Synopsis.Text = serie.Synopsis;

            if (serie.Favorite)
                this.IMG_Favorite.Source = favoriteImg;
            else
                this.IMG_Favorite.Source = noFavoriteImg;
        }

        private void LB_Series_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.LB_Series.SelectedIndex < 0)
                return;

            SelectedSerie = Series.Find(x => x.Title == (string)this.LB_Series.SelectedItem);
        }

        //Add a serie
        private void BT_AddSerie_Click(object sender, RoutedEventArgs e)
        {
            AddEditSerie(new AddSerie_Window(SelectedCategory));
        }

        //Edit the selected serie
        private void BT_EditSerie_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedSerie != null)
                AddEditSerie(new AddSerie_Window(SelectedCategory, selectedSerie));
        }

        //Add or edit a serie
        private void AddEditSerie(AddSerie_Window asw)
        {
            if (asw.ShowDialog() == true)
            {
                UpdateSeriesListVew(Series);
                this.LB_Series.SelectedItem = Series[Series.Count - 1].Title;

                this.Group_SeriesList.Header = SelectedCategory.name + " (" + Series.Count + ")";
            }
        }

        //Delete the selected serie
        private void BT_DeleteSerie_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedSerie == null)
                return;

            if (MessageBox.Show((string)App.LanguageResources["DeleteConfirm"], "MySeries", MessageBoxButton.YesNo) == MessageBoxResult.No)
                return;

            SelectedCategory.Remove(selectedSerie);
            Category.Save();

            this.LB_Series.Items.Remove(selectedSerie.Title);
            SetDefaultSerie();
        }

        //Set favorite serie
        private void BT_Favorite_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedSerie == null)
                return;

            SelectedSerie.Favorite = !SelectedSerie.Favorite;

            if(SelectedSerie.Favorite)
                this.IMG_Favorite.Source = favoriteImg;
            else
                this.IMG_Favorite.Source = noFavoriteImg;

            Category.Save();
        }


        //Add a new category
        private void BT_AddCategory_Click(object sender, RoutedEventArgs e)
        {
            MyFunctions.ControlsWPF.InputBox ib = new MyFunctions.ControlsWPF.InputBox((string)App.LanguageResources["NewCategoryName"], false);

            if(ib.ShowDialog() == true)
            {
                if (string.IsNullOrEmpty(ib.Value))
                    return;

                Category newCategory = new Category(ib.Value);
                Global.categoriesList.Add(newCategory);
                LoadCategories();
                SelectedCategory = newCategory;

                Category.Save();
            }
        }

        private void CB_Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.CB_Categories.SelectedItem == null)
                return;

            SelectedCategory = Global.categoriesList.Find(x => x.name == (string)((Label)this.CB_Categories.SelectedItem).Content);
        }

        #region Categories context menu

        //Edit a category
        private void MN_EditCategory_Click(object sender, RoutedEventArgs e)
        {
            Label lb_selected = (Label)categoriesMenu.Tag;
            string categoryName = (string)lb_selected.Content;

            Category cy = Global.categoriesList.Find(x => x.name == categoryName);

            if(cy != null)
            {
                MyFunctions.ControlsWPF.InputBox ib = new MyFunctions.ControlsWPF.InputBox(App.LanguageResources["EditCategoryMsg"] +" " + categoryName, false);
                if (ib.ShowDialog() == true)
                {
                    if (ib.Value == "")
                        return;

                    cy.name = ib.Value;
                    lb_selected.Content = ib.Value;

                    Category.Save();

                    int i = this.CB_Categories.SelectedIndex;
                    this.CB_Categories.SelectedIndex = -1;
                    this.CB_Categories.SelectedIndex = i;
                }
            }
        }

        //Delete a category
        private void MN_DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            Label lb_selected = (Label)categoriesMenu.Tag;
            string categoryName = (string)lb_selected.Content;

            Category cy = Global.categoriesList.Find(x => x.name == categoryName);

            if(cy != null)
            {
                if (Global.categoriesList.Count <= 1)
                    return;

                if (System.Windows.Forms.MessageBox.Show((string)App.LanguageResources["DeleteCategoryConfirm"], "MySeries", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    Global.categoriesList.Remove(cy);
                    Category.Save();

                    this.CB_Categories.Items.Remove(lb_selected);
                    this.CB_Categories.SelectedIndex = 0;
                }
            }
        }


        #endregion

        #region Set options search

        private void TB_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchSerie?.Invoke();
        }

        //Search by title
        bool firstFindByTitleCall = true;
        private void RB_FindTitle_Checked(object sender, RoutedEventArgs e)
        {
            searchSerie = () => 
            {
                string textToSearch = this.TB_Search.Text.ToLower();
                List<MSerie> seriesFound = Series.FindAll(x => x.Title.ToLower().StartsWith(textToSearch));
                UpdateSeriesListVew(seriesFound);
            };

            if (!firstFindByTitleCall)
                searchSerie?.Invoke();

            firstFindByTitleCall = false;
        }
        
        //Search by author
        private void RB_FindAuthor_Checked(object sender, RoutedEventArgs e)
        {
            searchSerie = () =>
            {
                string textToSearch = this.TB_Search.Text.ToLower();
                List<MSerie> seriesFound = Series.FindAll(x => x.Author.ToLower().StartsWith(textToSearch));
                UpdateSeriesListVew(seriesFound);
            };

            searchSerie?.Invoke();
        }

        //Search by genre
        private void RB_FindGenre_Checked(object sender, RoutedEventArgs e)
        {
            searchSerie = () =>
            {
                string textToSearch = this.TB_Search.Text.ToLower();
                List<MSerie> seriesFound = Series.FindAll(x => x.Genre.ToLower().Contains(textToSearch));
                UpdateSeriesListVew(seriesFound);
            };

            searchSerie?.Invoke();
        }

        //Search by language
        private void RB_FindLanguage_Checked(object sender, RoutedEventArgs e)
        {
            searchSerie = () =>
            {
                string textToSearch = this.TB_Search.Text.ToLower();
                List<MSerie> seriesFound = Series.FindAll(x => x.Language.ToLower().StartsWith(textToSearch));
                UpdateSeriesListVew(seriesFound);
            };

            searchSerie?.Invoke();
        }

        //Search by state
        private void RB_FindState_Checked(object sender, RoutedEventArgs e)
        {
            searchSerie = () =>
            {
                string textToSearch = this.TB_Search.Text.ToLower();
                List<MSerie> seriesFound = Series.FindAll(x => x.State.ToLower().StartsWith(textToSearch));
                UpdateSeriesListVew(seriesFound);
            };

            searchSerie?.Invoke();
        }

        //Search series whose rating is less than x
        private void RB_FindRating_Checked(object sender, RoutedEventArgs e)
        {
            searchSerie = () =>
            {
                int v;
                if (!int.TryParse(this.TB_Search.Text, out v))
                {
                    UpdateSeriesListVew(Series);
                    return;
                }

                List<MSerie> seriesFound = Series.FindAll(x => x.Rating <= v);
                UpdateSeriesListVew(seriesFound);
            };

            searchSerie?.Invoke();
        }

        //Show favorites series
        private void RB_FindFavorite_Checked(object sender, RoutedEventArgs e)
        {
            searchSerie = () =>
            {
                string textToSearch = this.TB_Search.Text.ToLower();
                List<MSerie> seriesFound = Series.FindAll(x => x.Favorite)
                    .FindAll(x => x.Title.ToLower().StartsWith(textToSearch));

                UpdateSeriesListVew(seriesFound);
            };

            searchSerie?.Invoke();
        }

        #endregion

        #region Settings

        private void BT_Settings_Click(object sender, RoutedEventArgs e)
        {
            this.BT_Settings.ContextMenu.IsOpen = true;
        }
  
        private void SetLanguage(string _lang)
        {
            Properties.Settings.Default.Language = _lang;
            Properties.Settings.Default.Save();

            this.Resources.MergedDictionaries.Remove(App.LanguageResources);
            App.SetAppLanguage(_lang);
            this.Resources.MergedDictionaries.Add(App.LanguageResources);

        }

        private void MN_English(object sender, RoutedEventArgs e)
        {
            SetLanguage("en-US");
        }

        private void MN_French(object sender, RoutedEventArgs e)
        {
            SetLanguage("fr-FR");
        }

        #endregion

        private void BT_ADMANSoftware_Click(object sender, RoutedEventArgs e)
        {
            mn_adman.ShowMenu();
        }
    }
}
