using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Restaurant.Models;
using Restaurant.Models.BusinessLogicLayer;
using Restaurant.Views;

namespace Restaurant.ViewModels
{
    class MeniuVM : BasePropertyChanged
    {
        ProdusBLL prodBLL = new ProdusBLL();
        MeniuriBLL meniuriBLL = new MeniuriBLL();
        ComandaBLL comandaBLL = new ComandaBLL();
        public MeniuVM()
        {
            ProductList = prodBLL.GetAllProducts();
            MeniuriList = meniuriBLL.GetAllMeniuri();
            
            ObservableCollection<object> aux=new ObservableCollection<object>();
            for (int i=0;i<ProductList.Count;i++)
            {
                aux.Add(ProductList[i]);
            }

            for (int i = 0; i < MeniuriList.Count; i++)
            {
                aux.Add(MeniuriList[i]);
            }

            AllProducts = aux;
        }

        double costTransport = Convert.ToDouble(ConfigurationManager.AppSettings["b"]);
        double costMancare = 0;

        ObservableCollection<object> allProducts;

        ObservableCollection<Produs> ProduseCuAlergen;
        ObservableCollection<Produs> ProduseFaraAlergen;

        ObservableCollection<Produs> ProduseCuNume;
        ObservableCollection<Produs> ProduseFaraNume;

        ObservableCollection<Meniuri> MeniuriCuAlergen;
        ObservableCollection<Meniuri> MeniuriFaraAlergen;

        ObservableCollection<Meniuri> MeniuriCuNume;
        ObservableCollection<Meniuri> MeniuriFaraNume;

        public ObservableCollection<object> AllProducts
        {
            get
            {
                return allProducts;
            }
            set
            {
                allProducts = value;
                NotifyPropertyChanged("AllProducts");
            }
        }

        public ObservableCollection<Produs> ProductList
        {
            get
            {
                return prodBLL.ProductList;
            }
            set
            { 
                prodBLL.ProductList = value;
                NotifyPropertyChanged("ProductList");
            }
            
        }

        public ObservableCollection<Meniuri> MeniuriList
        {
            get
            {
                return meniuriBLL.GetAllMeniuri();
            }
            set
            {
                meniuriBLL.ListaMeniuri = value;
                NotifyPropertyChanged("MeniuriList");
            }

        }

        ObservableCollection<Produs> produseCurente;

        public ObservableCollection<Produs> ProduseCurente
        {
            get
            {
                return produseCurente;
            }
            set
            {
                produseCurente = value;
                NotifyPropertyChanged("ProduseCurente");
            }
        }

        ObservableCollection<Meniuri> meniuriCurente;

        public ObservableCollection<Meniuri> MeniuriCurente
        {
            get
            {
                return meniuriCurente;
            }
            set
            {
                meniuriCurente = value;
                NotifyPropertyChanged("MeniuriCurente");
            }
        }

        ObservableCollection<object> ProduseComandate=new ObservableCollection<object>();

        List<int> numarBucatiProdus=new List<int>();

        Produs p;

        public Produs P
        {
            get
            {
                return p;
            }
            set
            {
                p = value;
                if(p!=null)
                {
                    Bt1 = true;
                    ProdusIndisponibil = "";
                    if (p.Cantitate > p.CantitateTotala)
                    {
                        Bt1 = false;
                        ProdusIndisponibil = "Produs indisponibil";
                    }
                }
                NotifyPropertyChanged("P");
            }
        }

        string produsIndisponibil;
        public string ProdusIndisponibil
        {
            get
            {
                return produsIndisponibil;
            }
            set
            {
                produsIndisponibil = value;
                NotifyPropertyChanged("ProdusIndisponibil");
            }
        }

        Meniuri m;

        public Meniuri M
        {
            get
            {
                return m;
            }
            set
            {
                m = value;
                if (m != null)
                {
                    Bt2 = true;
                    MeniuIndisponibil = "";
                    for (int i = 0; i < m.Produse.Count; i++)
                    {
                        if (m.Produse[i].Cantitate > m.Produse[i].CantitateTotala)
                        {
                            Bt2 = false;
                            MeniuIndisponibil = "Meniu indisponibil";
                        }
                    }
                }
                NotifyPropertyChanged("M");
            }
        }

        string meniuIndisponibil;
        public string MeniuIndisponibil
        {
            get
            {
                return meniuIndisponibil;
            }
            set
            {
                meniuIndisponibil = value;
                NotifyPropertyChanged("MeniuIndisponibil");
            }
        }
        public ObservableCollection<Produs> ProduseMicDejun()
        {
            ObservableCollection<Produs> micDejun = new ObservableCollection<Produs>();

            for (int i = 0; i < ProductList.Count; i++)
            {
                if (ProductList[i].Categorie == "Mic dejun")
                    micDejun.Add(ProductList[i]);
            }
            return micDejun;
        }

        public ObservableCollection<Meniuri> MeniuriMicDejun()
        {
            ObservableCollection<Meniuri> micDejun = new ObservableCollection<Meniuri>();

            for (int i = 0; i < MeniuriList.Count; i++)
            {
                if (MeniuriList[i].Categorie == "Mic dejun")
                    micDejun.Add(MeniuriList[i]);
            }
            return micDejun;
        }
        private void MicDejun(object param)
        {
            ProduseCurente = ProduseMicDejun();
            MeniuriCurente = MeniuriMicDejun();
            Bt1 = false;
            Bt2 = false;
        }

        private ICommand meniuMicDejun;
        public ICommand MeniuMicDejun
        {
            get
            {
                if (meniuMicDejun == null)
                {
                    meniuMicDejun = new RelayCommand(MicDejun);
                }
                return meniuMicDejun;
            }
        }

        public ObservableCollection<Produs> ProdusePui()
        {
            ObservableCollection<Produs> preparatePui = new ObservableCollection<Produs>();

            for (int i = 0; i < ProductList.Count; i++)
            {
                if (ProductList[i].Categorie == "Preparate din pui")
                    preparatePui.Add(ProductList[i]);
            }
            return preparatePui;
        }

        public ObservableCollection<Meniuri> MeniuriPui()
        {
            ObservableCollection<Meniuri> preparatePui = new ObservableCollection<Meniuri>();
            for (int i = 0; i < MeniuriList.Count; i++)
            {
                if (MeniuriList[i].Categorie == "Preparate din pui")
                    preparatePui.Add(MeniuriList[i]);
            }
            return preparatePui;
        }
        private void Pui(object param)
        {
            ProduseCurente = ProdusePui();
            MeniuriCurente = MeniuriPui();
            Bt1 = false;
            Bt2 = false;
        }

        private ICommand meniuPui;
        public ICommand MeniuPui
        {
            get
            {
                if (meniuPui == null)
                {
                    meniuPui = new RelayCommand(Pui);
                }
                return meniuPui;
            }
        }

        public ObservableCollection<Produs> ProduseVita()
        {
            ObservableCollection<Produs> preparateVita = new ObservableCollection<Produs>();

            for (int i = 0; i < ProductList.Count; i++)
            {
                if (ProductList[i].Categorie == "Preparate din vita")
                    preparateVita.Add(ProductList[i]);
            }
            return preparateVita;
        }

        public ObservableCollection<Meniuri> MeniuriVita()
        {
            ObservableCollection<Meniuri> preparateVita = new ObservableCollection<Meniuri>();
            for (int i = 0; i < MeniuriList.Count; i++)
            {
                if (MeniuriList[i].Categorie == "Preparate din vita")
                    preparateVita.Add(MeniuriList[i]);
            }
            return preparateVita;
        }
        private void Vita(object param)
        {
            ProduseCurente = ProduseVita();
            MeniuriCurente = MeniuriVita();
            Bt1 = false;
            Bt2 = false;
        }

        private ICommand meniuVita;
        public ICommand MeniuVita
        {
            get
            {
                if (meniuVita == null)
                {
                    meniuVita = new RelayCommand(Vita);
                }
                return meniuVita;
            }
        }

        public ObservableCollection<Produs> ProduseSosuri()
        {
            ObservableCollection<Produs> sosuri = new ObservableCollection<Produs>();

            for (int i = 0; i < ProductList.Count; i++)
            {
                if (ProductList[i].Categorie == "Sosuri")
                    sosuri.Add(ProductList[i]);
            }
            return sosuri;
        }

        public ObservableCollection<Meniuri> MeniuriSosuri()
        {
            ObservableCollection<Meniuri> sosuri = new ObservableCollection<Meniuri>();
            for (int i = 0; i < MeniuriList.Count; i++)
            {
                if (MeniuriList[i].Categorie == "Sosuri")
                    sosuri.Add(MeniuriList[i]);
            }
            return sosuri;
        }
        private void Sos(object param)
        {
            ProduseCurente = ProduseSosuri();
            MeniuriCurente = MeniuriSosuri();
            Bt1 = false;
            Bt2 = false;
        }

        private ICommand meniuSosuri;
        public ICommand MeniuSosuri
        {
            get
            {
                if (meniuSosuri == null)
                {
                    meniuSosuri = new RelayCommand(Sos);
                }
                return meniuSosuri;
            }
        }

        public ObservableCollection<Produs> ProduseDeserturi()
        {
            ObservableCollection<Produs> deserturi = new ObservableCollection<Produs>();

            for (int i = 0; i < ProductList.Count; i++)
            {
                if (ProductList[i].Categorie == "Desert")
                    deserturi.Add(ProductList[i]);
            }
            return deserturi;
        }

        public ObservableCollection<Meniuri> MeniuriDeserturi()
        {
            ObservableCollection<Meniuri> deserturi = new ObservableCollection<Meniuri>();
            for (int i = 0; i < MeniuriList.Count; i++)
            {
                if (MeniuriList[i].Categorie == "Desert")
                    deserturi.Add(MeniuriList[i]);
            }
            return deserturi;
        }
        private void Desert(object param)
        {
            ProduseCurente = ProduseDeserturi();
            MeniuriCurente = MeniuriDeserturi();
            Bt1 = false;
            Bt2 = false;
        }

        private ICommand meniuDesert;
        public ICommand MeniuDesert
        {
            get
            {
                if (meniuDesert == null)
                {
                    meniuDesert = new RelayCommand(Desert);
                }
                return meniuDesert;
            }
        }

        public ObservableCollection<Produs> ProduseBauturi()
        {
            ObservableCollection<Produs> bauturi = new ObservableCollection<Produs>();

            for (int i = 0; i < ProductList.Count; i++)
            {
                if (ProductList[i].Categorie == "Bauturi")
                    bauturi.Add(ProductList[i]);
            }
            return bauturi;
        }
        public ObservableCollection<Meniuri> MeniuriBauturi()
        {
            ObservableCollection<Meniuri> bauturi = new ObservableCollection<Meniuri>();
            for (int i = 0; i < MeniuriList.Count; i++)
            {
                if (MeniuriList[i].Categorie == "Bauturi")
                    bauturi.Add(MeniuriList[i]);
            }
            return bauturi;
        }
        private void Bautura(object param)
        {
            ProduseCurente = ProduseBauturi();
            MeniuriCurente = MeniuriBauturi();
            Bt1 = false;
            Bt2 = false;
        }

        private ICommand meniuBauturi;
        public ICommand MeniuBauturi
        {
            get
            {
                if (meniuBauturi == null)
                {
                    meniuBauturi = new RelayCommand(Bautura);
                }
                return meniuBauturi;
            }
        }

        bool bt1;
        public bool Bt1
        {
            get
            {
                return bt1;
            }
            set
            {
                bt1 = value;
                NotifyPropertyChanged("Bt1");
            }
        }

        bool bt2;
        public bool Bt2
        {
            get
            {
                return bt2;
            }
            set
            {
                bt2 = value;
                NotifyPropertyChanged("Bt2");
            }
        }
        

        public void Btn1Click(object param)
        {
            bool exista = false;

            if(ProduseComandate!=null)
            {
                for (int i = 0; i < ProduseComandate.Count; i++)
                {
                    if (ProduseComandate[i] == P)
                    {
                        Produs produs = P;
                        numarBucatiProdus[i] += 1;
                        exista = true;
                        
                        produs.CantitateTotala -= produs.Cantitate;
                        ProduseComandate[i]=produs;
                        P = produs;
                    }
                }
            }
            if(!exista)
            {
                ProduseComandate.Add(P);
                numarBucatiProdus.Add(1);
                Produs produs = P;
                produs.CantitateTotala -= produs.Cantitate;
                P = produs;
            }

            costMancare += P.Pret;
            double comMinima = Convert.ToDouble(ConfigurationManager.AppSettings["a"]);
            if (costMancare >= comMinima)
            {
                costTransport = 0;
            }

            for(int i=0;i<MeniuriList.Count;i++)
            {
                for(int j=0;j< MeniuriList[i].Produse.Count;j++)
                {
                    if(MeniuriList[i].Produse[j].Nume==P.Nume)
                    {
                        MeniuriList[i].Produse[j].CantitateTotala -= MeniuriList[i].Produse[j].Cantitate;
                    }
                }
            }
        }

        private ICommand b1Click;
        public ICommand B1Click
        {
            get
            {
                if (b1Click == null)
                {
                    b1Click = new RelayCommand(Btn1Click);
                }
                return b1Click;
            }
        }

        public void Btn2Click(object param)
        {
            bool exista = false;
            if(ProduseComandate!=null)
            {
                for (int i = 0; i < ProduseComandate.Count; i++)
                {
                    if (ProduseComandate[i] == M)
                    {
                        numarBucatiProdus[i] += 1;
                        exista = true;

                        Meniuri meniuri = M;
                        for (int j = 0; j < meniuri.Produse.Count; j++)
                        {
                            Produs produs = meniuri.Produse[j];
                            produs.CantitateTotala -= produs.Cantitate;
                            meniuri.Produse[j] = produs;
                            
                        }

                        M = meniuri;
                    }
                }
            }
            
            if (!exista)
            {
                ProduseComandate.Add(M);
                numarBucatiProdus.Add(1);
                Meniuri meniuri = M;
                for (int j = 0; j < meniuri.Produse.Count; j++)
                {
                    Produs produs = meniuri.Produse[j];
                    produs.CantitateTotala -= produs.Cantitate;
                    meniuri.Produse[j] = produs;
                }

                M = meniuri;
            }
            costMancare += M.Pret;
            double comMinima = Convert.ToDouble(ConfigurationManager.AppSettings["a"]);
            if (costMancare >= comMinima)
            {
                costTransport = 0;
            }
        }

        private ICommand b2Click;
        public ICommand B2Click
        {
            get
            {
                if (b2Click == null)
                {
                    b2Click = new RelayCommand(Btn2Click);
                }
                return b2Click;
            }
        }

        public void CosClick(object param)
        {
            if(ProduseComandate==null || ProduseComandate.Count==0)
            {
                MessageBox.Show("Cosul este gol !");
            }
            else
            {
                StringBuilder s = new StringBuilder();
                s.Append("Cost mancare: \n\n");
                for (int i = 0; i < ProduseComandate.Count; i++)
                {
                    s.Append(numarBucatiProdus[i].ToString() + "x  ");
                    if(ProduseComandate[i] is Produs)
                    {
                        Produs p = ProduseComandate[i] as Produs;
                        s.Append(p.Nume + " " + (numarBucatiProdus[i] * p.Pret).ToString() + " lei\n");
                        
                    }
                    else if (ProduseComandate[i] is Meniuri)
                    {
                        Meniuri m = ProduseComandate[i] as Meniuri;
                        s.Append(m.Nume +" "+ (numarBucatiProdus[i] * m.Pret).ToString() + " lei\n");
                       
                    }
                }
                
                s.Append("\nCost transport: " + costTransport.ToString() + " lei\n");
                s.Append("\nCost total: " + (costTransport+costMancare).ToString() + " lei\n");
                MessageBox.Show(s.ToString());
            }
            
        }

        private ICommand cos;

        public ICommand Cos
        {
            get
            {
                if (cos == null)
                {
                    cos = new RelayCommand(CosClick);
                }
                return cos;
            }
        }

        public void GolireCosClick(object param)
        {
            costMancare = 0;
            costTransport = Convert.ToDouble(ConfigurationManager.AppSettings["b"]);
            for (int i = 0; i < ProduseComandate.Count; i++)
            {
                if(ProduseComandate[i] is Produs)
                {
                    Produs produs = ProduseComandate[i] as Produs;
                    produs.CantitateTotala = produs.CantitateTotala + (produs.Cantitate* numarBucatiProdus[i]);
                    ProduseComandate[i] = produs;
                    P = produs;
                }
                else
                {
                    Meniuri meniuri = ProduseComandate[i] as Meniuri;
                    for(int j=0; j< meniuri.Produse.Count;j++)
                    {
                        meniuri.Produse[j].CantitateTotala += meniuri.Produse[j].Cantitate * numarBucatiProdus[i];
                    }
                    ProduseComandate[i] = meniuri;
                    M = meniuri;
                }
                
            }
            ProduseComandate.Clear();
            numarBucatiProdus.Clear();
        }

        private ICommand golireCos;

        public ICommand GolireCos
        {
            get
            {
                if (golireCos == null)
                {
                    golireCos = new RelayCommand(GolireCosClick);
                }
                return golireCos;
            }
        }

        public void FinalizareComanda(object param)
        {
            if(ProduseComandate.Count!=0 && ProduseComandate !=null)
            {
                DateTime dateTime = DateTime.Now.Date;
                TimeSpan timeSpan = DateTime.Now.TimeOfDay;
                
                Utilizator utilizator = Meniu.utilizatorCurent;
                comandaBLL.AddComanda("Inregistrata", costMancare, costTransport, dateTime, timeSpan, utilizator.Id_Utilizator);

                ObservableCollection<Comanda> comenzi = comandaBLL.SelectComenzileUnuiClient(utilizator.Id_Utilizator);
                Comanda ultimaComanda = comenzi[comenzi.Count - 1];

                for (int i = 0; i < ProduseComandate.Count; i++)
                {
                    if (ProduseComandate[i] is Produs)
                    {
                        Produs produs = ProduseComandate[i] as Produs;
                        comandaBLL.AddComandaProdus(ultimaComanda.IdComanda, produs.Id_produs, numarBucatiProdus[i]);
                        prodBLL.UpdateProdus(produs);
                    }
                    else if (ProduseComandate[i] is Meniuri)
                    {
                        Meniuri meniuri = ProduseComandate[i] as Meniuri;
                        comandaBLL.AddComandaMeniu(ultimaComanda.IdComanda, meniuri.Id_meniu, numarBucatiProdus[i]);
                        for (int j = 0; j < meniuri.Produse.Count; j++)
                        {
                            prodBLL.UpdateProdus(meniuri.Produse[j]);
                        }
                    }
                }

                MessageBox.Show("Comanda adaugata cu succes !");
                ProduseComandate.Clear();
            }
            else
            {
                MessageBox.Show("Cosul de cumparaturi este gol, pentru a plasa o comanda trebuie sa adaugati cel putin 1 produs!");
            }

            
        }
        private ICommand adaugaComanda;
        public ICommand AdaugaComanda
        {
            get
            {
                if (adaugaComanda == null)
                {
                    adaugaComanda = new RelayCommand(FinalizareComanda);
                }
                return adaugaComanda;
            }
        }

        //public void ComenzileClientuli(object param)
        //{
        //    Utilizator utilizator = Meniu.clientCurent;
        //    ObservableCollection<Comanda> comenzi = comandaBLL.SelectComenzileUnuiClient(utilizator.Id_Utilizator);

        //    StringBuilder s = new StringBuilder();
        //    if(comenzi.Count==0 || comenzi == null)
        //    {
        //        MessageBox.Show("Nu ati plasat nicio comanda pana acum !");
        //    }
        //    else
        //    {
        //        Comenzi comenzi = new Comenzi();
        //    }
            
        //}
        //private ICommand vizualizareComenzi;
        //public ICommand VizualizareComenzi
        //{
        //    get
        //    {
        //        if (vizualizareComenzi == null)
        //        {
        //            vizualizareComenzi = new RelayCommand(ComenzileClientuli);
        //        }
        //        return vizualizareComenzi;
        //    }
        //}

        bool contine=false;
        public bool Contine
        {
            get
            {
                return contine;
            }
            set
            {
                contine = value;
                NotifyPropertyChanged("Contine");
            }
        }

        bool nuContine=false;
        public bool NuContine
        {
            get
            {
                return nuContine;
            }
            set
            {
                nuContine = value;
                NotifyPropertyChanged("NuContine");
            }
        }

        bool alergen = false;
        public bool Alergen
        {
            get
            {
                return alergen;
            }
            set
            {
                alergen = value;
                NotifyPropertyChanged("Alergen");
            }
        }

        bool partNume = false;
        public bool PartNume
        {
            get
            {
                return partNume;
            }
            set
            {
                partNume = value;
                NotifyPropertyChanged("PartNume");
            }
        }

        string searchTxt = "Cauta cuvant cheie";

        public string SearchTxt
        {
            get
            {
                return searchTxt;
            }
            set
            {
                searchTxt = value;
                NotifyPropertyChanged("SearchTxt");
            }
        }

        public void ClickDepozit(object param)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < ProductList.Count; i++)
            {
                s.Append(ProductList[i].Nume + "    Cantitate totala: " + ProductList[i].CantitateTotala.ToString()+"\n");
            }
            MessageBox.Show(s.ToString());
        }

        private ICommand depozit;

        public ICommand Depozit
        {
            get
            {
                if (depozit == null)
                {
                    depozit = new RelayCommand(ClickDepozit);
                }
                return depozit;
            }
        }

        public void ClickCauta(object param)
        {
            if(Contine==false && NuContine == false)
            {
                MessageBox.Show("Va rugam selectati daca doriti ca produsele sa contina sau nu alergenul/numele introdus!");
            }
            else if(Alergen == false && PartNume==false)
            {
                MessageBox.Show("Va rugam selectati daca doriti ca produsele sa contina sau nu alergenul/numele introdus!");
            }
            else if(Contine == true && NuContine == false)
            {
                if(Alergen == true && PartNume==false)
                {
                    ProduseCuAlergen = prodBLL.SelectProduseCareAuAlergen(SearchTxt);
                    MeniuriCuAlergen = meniuriBLL.SelectMeniuriCuAlergen(SearchTxt);
                    if (ProduseCuAlergen.Count != 0 || MeniuriCuAlergen.Count != 0)
                    {
                        ProduseCurente = ProduseCuAlergen;
                        MeniuriCurente = MeniuriCuAlergen;
                    }
                    else
                    {
                        MessageBox.Show("Nu s-au gasit preparate/meniuri care sa contina alergenul selectat!");
                    }
                }
                else if (Alergen == false && PartNume == true)
                {
                    ProduseCuNume = prodBLL.SelectProduseCareContinNume(SearchTxt);
                    MeniuriCuNume = meniuriBLL.SelectMeniuriCareContinNume(SearchTxt);

                    if (ProduseCuNume.Count != 0 || MeniuriCuNume.Count != 0)
                    {
                        ProduseCurente = ProduseCuNume;
                        MeniuriCurente = MeniuriCuNume;
                    }
                    else
                    {
                        MessageBox.Show("Nu s-a gasit niciun preparat/meniu care sa contina cuvantul cheie introdus!");
                    }
                }

            }
            else if(Contine == false && NuContine == true)
            {
                if(Alergen == true && PartNume == false)
                {
                    ProduseFaraAlergen = prodBLL.SelectProduseCareNuAuAlergen(SearchTxt);
                    MeniuriFaraAlergen = meniuriBLL.SelectMeniuriFaraAlergen(SearchTxt);
                    if (ProduseFaraAlergen.Count != 0 || MeniuriFaraAlergen.Count != 0)
                    {
                        ProduseCurente = ProduseFaraAlergen;
                        MeniuriCurente = MeniuriFaraAlergen;
                    }
                    else
                    {
                        MessageBox.Show("Nu s-au gasit preparate/meniuri care sa NU contina alergenul selectat!");
                    }
                }
                else if(Alergen == false && PartNume == true)
                {
                    ProduseFaraNume = prodBLL.SelectProduseCareNuContinNume(SearchTxt);
                    MeniuriFaraNume = meniuriBLL.SelectMeniuriCareNuContinNume(SearchTxt);

                    if (ProduseFaraNume.Count != 0 || MeniuriFaraNume.Count != 0)
                    {
                        ProduseCurente = ProduseFaraNume;
                        MeniuriCurente = MeniuriFaraNume;
                    }
                    else
                    {
                        MessageBox.Show("Nu s-a gasit niciun preparat/meniu care sa NU contina cuvantul cheie introdus!");
                    }
                }
            }
            Bt1 = false;
            Bt2 = false;
        }

        private ICommand cauta;

        public ICommand Cauta
        {
            get
            {
                if (cauta == null)
                {
                    cauta = new RelayCommand(ClickCauta);
                }
                return cauta;
            }
        }
    }


   
}
