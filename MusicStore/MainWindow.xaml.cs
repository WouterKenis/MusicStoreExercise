using MusicStore.Business;
using MusicStore.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace MusicStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            genreComboBox.ItemsSource = GenreRepository.GetGenres();

        }

        private void genreComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Genre genre = genreComboBox.SelectedItem as Genre;

            IList<AlbumSummary> sum = new List<AlbumSummary>();
            sum = AlbumSummaryService.GetAlbumSummariesByGenre(genre.GenreId);
            albumDataGrid.Items.Clear();

            foreach (AlbumSummary albumSummary in sum)
            {
                albumDataGrid.Items.Add(albumSummary);
            }
        }
    }
}
