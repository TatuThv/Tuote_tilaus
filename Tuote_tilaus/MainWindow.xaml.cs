using System;
using System.Collections.Generic;
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

namespace Tuote_tilaus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Orderlkm;
        public int Itemlkm;
        
        List<TilausOtsikko> orders = new List<TilausOtsikko>();

        public MainWindow()
        {
            InitializeComponent();
            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            textColumn1.Binding = new Binding("TilausNumero");
            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Binding = new Binding("TuoteNumero");
            DataGridTextColumn textColumn3 = new DataGridTextColumn();
            textColumn3.Binding = new Binding("TuoteNimi");
            DataGridTextColumn textColumn4 = new DataGridTextColumn();
            textColumn4.Binding = new Binding("Maara");
            
            //DataGridin otsikot + edellä "ilmaan" luotujen sarakkeiden sijoitus konkreettiseen DataGridiin, joka on luotu formille
            textColumn1.Header = "Tilauksen numero";
            dgTilausRivit.Columns.Add(textColumn1);
            textColumn2.Header = "Tuotenumero";
            dgTilausRivit.Columns.Add(textColumn2);
            textColumn3.Header = "Tuotenimi";
            dgTilausRivit.Columns.Add(textColumn3);
            textColumn4.Header = "Määrä";
            dgTilausRivit.Columns.Add(textColumn4);
            //testtttt
        }

        class TilausRivi
        {
            public int TilausNumero { get; set; }
            public string TuoteNumero { get; set; }
            public string TuoteNimi { get; set; }
            public int Maara { get; set; }
            public decimal AHinta { get; set; }

        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            CreateOrder();

        }

        public void CreateOrder()
        {
            
            TilausOtsikko Tilaus = new TilausOtsikko();
            TilausRivi TilausR = new TilausRivi();
            
            try
            {

                Tilaus.OrderDate = datebox.SelectedDate.Value;
                if (Tilaus.OrderDate <= DateTime.Today && Itemlkm > 0)
                {
                    orders.Add(Tilaus);
                }
                if(Itemlkm == 0)
                {
                    throw new Exception("kpl määrä ei voi olla 0");
                }

                
                Orderlkm = orders.Count;
                Tilaus.Id = Orderlkm;
                dgTilausRivit.Items.Add(TilausR);

                Tilaus.ItemName = nametxt.Text;
                Tilaus.Address = addresstxt.Text;
                Tilaus.ArrivalDate = Tilaus.OrderDate.AddDays(14);
                TilausR.TilausNumero = Orderlkm;
                TilausR.TuoteNimi = nametxt.Text;
                TilausR.Maara = int.Parse(kpltxt.Text);

                tilaustxt.Text += "Tilausnumero " + Tilaus.Id + "\r\n" +
                "Tilauspäivämäärä: " + Tilaus.OrderDate.ToString() +
                "\r\n" + "Tuotteen nimi: " + Tilaus.ItemName +
                "\r\n" + "Tuotteiden kpl määrä: " + Itemlkm +
                "\r\n" + "Toimitus osoite: " + Tilaus.Address +
                "\r\n" + "Toimituspäivämäärä: " + Tilaus.ArrivalDate.ToString() + "\n" + "\n";

                    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void Minus_btn_Click(object sender, RoutedEventArgs e)
        {
            if(int.Parse(kpltxt.Text) > 0)
            {
                Itemlkm = int.Parse(kpltxt.Text);
                Itemlkm--;
                kpltxt.Text = Itemlkm.ToString();
            }
            else
            {
                kpltxt.Text = 0.ToString();
            }

        }

        private void Plus_btn_Click(object sender, RoutedEventArgs e)
        {
            Itemlkm = int.Parse(kpltxt.Text);
            Itemlkm++;
            kpltxt.Text = Itemlkm.ToString();
        }

        //private void Add_new_line_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        TilausRivi TilausR = new TilausRivi();
        //        TilausR.TilausNumero = Orderlkm;
        //        TilausR.TuoteNimi = nametxt.Text;
        //        TilausR.Maara = int.Parse(kpltxt.Text);
                

        //        MessageBox.Show("Tilausrivi tallennettu: " + "\r\n" + "Tilausnumero: " + TilausR.TilausNumero.ToString() +
        //                    "\r\n" + "Tuotenumero: " + TilausR.TuoteNumero +
        //                    "\r\n" + "Tuotteen nimi: " + TilausR.TuoteNimi +
        //                    "\r\n" + "Määrä: " + TilausR.Maara.ToString() +
        //                    "\r\n" + "A-hinta: " + TilausR.AHinta.ToString()
        //            );

        //        dgTilausRivit.Items.Add(TilausR);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}
    }


}
