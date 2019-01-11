using System;
using System.Collections.Generic;
using System.Text;
using BibliotecaProxyServices;
using Entidades;

namespace Biblio.ViewModel
{
   public class Biblioteca: ViewModelBase
    {
        public Biblioteca()
        {
            InitializeViewModel();
        }
        void InitializeViewModel()
        {
            Biblio = new List<Entidades.Biblioteca>();

            AddProductsCommand = new CommandDelegate
                ((o) => { return true; },
                (o) =>
                {
                    var Proxy = new BibliotecaProxyServices.Proxy();
                    var Recipe = new Entidades.Biblioteca{
                       Libro  = LibroName,
                       Categoria = GeneroName
                    };
                    var p = Proxy.CreateNewBook(Recipe);


                });

        }
        #region Propiedades

        private List<Entidades.Biblioteca> Biblio_BF;
        public List<Entidades.Biblioteca> Biblio
        {
            get { return Biblio_BF; }
            set
            {
                Biblio_BF = value;
                OnPropertyChanged();
            }
        }

        public CommandDelegate AddProductsCommand { get; private set; }

        private string LibroName_BF;
        public string LibroName
        {
            get { return LibroName_BF; }
            set
            {
                LibroName_BF = value;
                OnPropertyChanged();
            }
        }
        private string GeneroName_BF;
        public string GeneroName
        {
            get { return GeneroName_BF; }
            set
            {
                GeneroName_BF = value;
                OnPropertyChanged();
            }
        }
        #endregion

    }
}
