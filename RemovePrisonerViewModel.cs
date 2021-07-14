using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PrisonDataBaseWpfApp
{
    public class RemovePrisonerViewModel : DependencyObject
    {
        private ApplicationContext app;
        private List<Prisoner> prisoners;
        //private string path;
        public RemovePrisonerViewModel()
        {
            app = new ApplicationContext();
            prisoners = app.Prisoners.ToList();
            PrisonersItems = CollectionViewSource.GetDefaultView(app.Prisoners.ToList());
            PrisonersItems.Filter = FilterForStart;
            
        }
        public string Searcher
        {
            get { return (string)GetValue(SearcherProperty); }
            set { SetValue(SearcherProperty, value); }
        }
        public static readonly DependencyProperty SearcherProperty =
            DependencyProperty.Register("Searcher", typeof(string), typeof(RemovePrisonerViewModel), new PropertyMetadata(string.Empty, searcher_changed));


        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }
        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register("ImagePath", typeof(string), typeof(RemovePrisonerViewModel), new PropertyMetadata(string.Empty, searcher_changed));


        
        private static void searcher_changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as RemovePrisonerViewModel;
            if (current != null)
            {
                current.PrisonersItems.Filter = null;
                current.PrisonersItems.Filter = current.FilterChanged;
                var prisoners = new List<Prisoner>();
                foreach (var item in current.PrisonersItems)
                {
                    prisoners.Add((Prisoner)item);
                }
                if (prisoners.Count > 0)
                {
                    current.ImagePath = prisoners[0].ImagePath;
                }
            }
        }

        public ICollectionView PrisonersItems
        {
            get { return (ICollectionView)GetValue(PrisonersItemsProperty); }
            set { SetValue(PrisonersItemsProperty, value); }
        }

        public static readonly DependencyProperty PrisonersItemsProperty =
            DependencyProperty.Register("PrisonersItems", typeof(ICollectionView), typeof(RemovePrisonerViewModel), new PropertyMetadata(null));

        private bool FilterChanged(Object obj)
        {
            Prisoner prisoner = obj as Prisoner;
            if(prisoner != null && !string.IsNullOrWhiteSpace(Searcher) && prisoner.prisonerId.ToString().Equals(Searcher))
            {
                return true;
            }
            return false;
        }

        private bool FilterForStart(Object obj) => false;
    }
}
