﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sortowanie
{
    public partial class f : Form
    {
        int[] Table = new int[0];
        public f()
        {
            InitializeComponent();
            
        }

        public void Begin()
        {
            
        }
        public void End()
        {

        }

        public void GenerujZestawLiczb()
        {
            
        }
        public void ButtonBubbleSort_Click(object sender, EventArgs e)
        {
            int[] TTTable = Table;
            var CzasStart = DateTime.Now;

            bool Sortuj = true;
            int x = 0;
            int p = 1;
            while (Sortuj)
            {
                for (int i = 0; i < TTTable.Length-p; i++)
                {
                    if (TTTable[i]> TTTable[i+1]) 
                    {
                        x = TTTable[i + 1];
                        TTTable[i + 1] = TTTable[i];
                        TTTable[i] = x;
                        x = 0;
                    }
                }
                p = p + 1;
                if (p == TTTable.Length) { Sortuj = false; }
            }
            var CzasKoniec = DateTime.Now;
            var CzasTrwania = CzasKoniec - CzasStart;
            Czas.Text = "Czas sortowania: "+CzasTrwania.ToString();

            Wynik.Text = "";
            for (int y = 0; y < TTTable.Length; y++)
            {
                if (y % 25 == 0) { Wynik.Text = Wynik.Text + "\n "; }
                Wynik.Text = Wynik.Text + " " + TTTable[y].ToString();
            }

        }

        private void Liczby_Click(object sender, EventArgs e)
        {

        }

        private void GenerujLiczby_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var CzasStart = DateTime.Now;

            int[] Quick(int[] Tabela)
            {
                if (Tabela.Length == 2)
                {
                    if (Tabela[0] > Tabela[1])
                    {
                        int x = Tabela[1];
                        Tabela[1] = Tabela[0];
                        Tabela[0] = x;
                    }
                    return Tabela;
                }
                if (Tabela.Length == 1)
                {
                    return Tabela;
                }
                if (Tabela.Length == 0)
                {
                    return Tabela;
                }
                bool PrawaIstnieje = true;
                bool LewaIstnieje = true;

                int pivot = Tabela[Tabela.Length - 1];
                int IPivot = Tabela.Length - 1;
                int WiekszeOdPivota = 0;
                for (int y = 0; y < Tabela.Length; y++)
                {
                    if (Tabela[y] >= pivot && Tabela[y] != Tabela[IPivot]) { WiekszeOdPivota++; }
                }
                int[] Prawy = new int[WiekszeOdPivota];
                int[] Lewy = new int[Tabela.Length - WiekszeOdPivota];
             
                int l = 0;
                int r = 0;
                for (int y = 0; y < Tabela.Length; y++)
                {
                    if (Tabela[y] >= pivot)
                    {
                        if (PrawaIstnieje) { if (Tabela[y] != Tabela[IPivot]) { Prawy[r] = Tabela[y]; } }
                        r++;
                    }
                    else
                    {
                        if (LewaIstnieje) { if (Tabela[y] != Tabela[IPivot]) { Lewy[l] = Tabela[y]; } }
                        l++;
                    }
                }
                if (Prawy[0]==0) { PrawaIstnieje = false; }
                if (Lewy[0]==0) { LewaIstnieje = false; }
                xd.Text = xd.Text + "========\n";
                xd.Text = xd.Text + "Left: " + Lewy.Length.ToString() + "\n";
                xd.Text = xd.Text + "Right: " + Prawy.Length.ToString() + "\n";

                if (Lewy.Length != 1 && LewaIstnieje) { Lewy = Quick(Lewy); }
                if (Prawy.Length != 1 && PrawaIstnieje) { Prawy = Quick(Prawy); }

                xd.Text = xd.Text + "\n";
                if (PrawaIstnieje) {xd.Text = xd.Text + "Left: " + Lewy.Length.ToString() + "\n";}
                    if (PrawaIstnieje) { xd.Text = xd.Text + "Right: " + Prawy.Length.ToString() + "\n"; }

                    int[] TPivot = new int[1];
                    TPivot[0] = pivot;
                    int[] Temp = new int[0];

                    xd.Text = xd.Text + "TT: " + Temp.Length.ToString();

                    Temp = Temp.Concat(TPivot).ToArray();
                    if (LewaIstnieje) { Temp = Lewy.Concat(TPivot).ToArray(); }
                    if (PrawaIstnieje) { Temp = Temp.Concat(Prawy).ToArray(); }

                    xd.Text = xd.Text+ "Temp: " + Temp.Length.ToString();

                    return Temp;               
            }
            xd.Text = "";
            int[] TTTable =Quick(Table);


            var CzasKoniec = DateTime.Now;
            var CzasTrwania = CzasKoniec - CzasStart;
            Czas.Text = "Czas sortowania: " + CzasTrwania.ToString();

            Wynik.Text = "";
            for (int y = 0; y < TTTable.Length; y++)
            {
                if (y % 25 == 0) { Wynik.Text = Wynik.Text + "\n "; }
                Wynik.Text = Wynik.Text + " " + TTTable[y].ToString();
            }
        }

        private void Generuj_Click(object sender, EventArgs e)
        {
            GenerujZestawLiczb();
        }

        private void ButtonInsertSort_Click(object sender, EventArgs e)
        {
            int[] TTTable = Table;
            var CzasStart = DateTime.Now;

            bool Sortuj = true;
            int B = 1;
            while ( B < TTTable.Length)
                {
                    Sortuj = true;
                    int ii = B;
                    while (Sortuj)
                    {

                        int xx = 0;
                        
                        if (TTTable[ii-1] > TTTable[ii] )
                        {
                            xx = TTTable[ii];
                            TTTable[ii ] = TTTable[ii - 1];
                            TTTable[ii- 1] = xx;
                            ii--;
                            if (ii == 0) { Sortuj = false; }
                        }
                        else
                        {
                            Sortuj = false;
                        }
                        
                    }
                    B++;
            }
            var CzasKoniec = DateTime.Now;
            var CzasTrwania = CzasKoniec - CzasStart;
            Czas.Text = "Czas sortowania: " + CzasTrwania.ToString();

            Wynik.Text = "";
            for (int y = 0; y < TTTable.Length; y++)
            {
                if (y % 25 == 0) { Wynik.Text = Wynik.Text + "\n "; }
                Wynik.Text = Wynik.Text + " " + TTTable[y].ToString();
            }
        }

        private void ButtonMergeSort_Click(object sender, EventArgs e)
        {
            var CzasStart = DateTime.Now;
            xd.Text = "";
               int[] Merge(int[] Lewa, int[] Prawa)
            {
                int[] Temp = new int[Lewa.Length + Prawa.Length];
                int i = 0;
                int ip = 0;
                int il = 0;

                while ( il < Lewa.Length || ip < Prawa.Length)
                {
                    //xd.Text = xd.Text + " ";
                    if (il < Lewa.Length && ip < Prawa.Length)
                    {
                        if(Lewa[il] <= Prawa[ip])
                        {
                            Temp[i] = Lewa[il];
                            il++;
                            i++;
                            //xd.Text = xd.Text + "l";
                        }
                        else
                        {
                            Temp[i] = Prawa[ip];
                            ip++;
                            i++;
                            //xd.Text = xd.Text + "p";
                        }
                    }
                    else
                    {
                        if (il<Lewa.Length)
                        {
                            Temp[i] = Lewa[il];
                            il++;
                            i++;
                            //xd.Text = xd.Text + "l1";
                        }
                        else
                        {
                            if (ip<Prawa.Length)
                            {
                                Temp[i] = Prawa[ip];
                                ip++;
                                i++;
                                //xd.Text = xd.Text + "p1";
                            }
                        }
                    }
                }
                //xd.Text = xd.Text + "|||";
                return Temp;
            }


               int[] MergeSort(int[] Tabela)
               {
                    int[] Lewa = new int[0];
                    int[] Prawa = new int[0];
                    int[] Temp = new int[Tabela.Length];
                    if (Tabela.Length <= 1)
                    {
                         return Tabela;
                    }
                    int Srodek = Tabela.Length / 2;
                    Lewa = new int[Srodek];
                    if (Tabela.Length % 2 == 0)
                    {
                        Prawa = new int[Srodek];
                    }
                    else
                    {
                        Prawa = new int[Srodek + 1];
                        
                    }

                    for(int c = 0; c < Srodek; c++)
                    {
                        Lewa[c] = Tabela[c];
                    }
                    int x = 0;
                    for (int c = Srodek; c < Tabela.Length; c++)
                    {
                        Prawa[x] = Tabela[c];
                        x++;
                    }
                    Lewa = MergeSort(Lewa);
                    Prawa = MergeSort(Prawa);
                    Temp = Merge(Lewa, Prawa);
                xd.Text = xd.Text + "d";
                return Temp;
               }
            int[] TTTable=MergeSort(Table);
            var CzasKoniec = DateTime.Now;
            var CzasTrwania = CzasKoniec - CzasStart;
            Czas.Text = "Czas sortowania: " + CzasTrwania.ToString();

            Wynik.Text = "";
            for (int y = 0; y < TTTable.Length; y++)
            {
                if (y % 25 == 0) { Wynik.Text = Wynik.Text + "\n "; }
                Wynik.Text = Wynik.Text + " " + TTTable[y].ToString();
            }
        }

        private void ButtonZapisz_Click(object sender, EventArgs e)
        {
            SaveFileDialog Zapis = new SaveFileDialog();

            Zapis.Filter = "Plik (*.txt)|*.txt";
            Zapis.FilterIndex = 2;
            Zapis.RestoreDirectory = true;
            if (Zapis.ShowDialog() == DialogResult.OK)
            {
                int generujliczby = Decimal.ToInt32(NumericUpDownLiczby.Value);
                string[] Table = new string[generujliczby];
                Random rnd = new Random();
                for (int i = 0; i < Table.Length; i++)
                {
                    Table[i] = rnd.Next(1, 100).ToString();
                }

                File.WriteAllLinesAsync(Zapis.FileName, Table);
            }
        }

        private void ButtonOtworz_Click(object sender, EventArgs e)
        {
            OpenFileDialog Otworz = new OpenFileDialog();

            Otworz.Filter = "Plik (*.txt)|*.txt";
            Otworz.FilterIndex = 2;
            Otworz.RestoreDirectory = true;
            if (Otworz.ShowDialog() == DialogResult.OK)
            {
                var fileStream = Otworz.OpenFile();

                using (StreamReader reader = new StreamReader(Otworz.FileName))
                {
                    while (reader.Peek() >= 0)
                    {
                        int linia = Int32.Parse(reader.ReadLine().ToString());
                        int[] Temp = new int[1];
                        Temp[0] = linia;
                        Table = Table.Concat(Temp).ToArray();
                    }
                }
                Liczby.Text = "";
                for (int y = 0; y < Table.Length; y++)
                {
                    if (y % 25 == 0) { Liczby.Text = Liczby.Text + "\n "; }
                    Liczby.Text = Liczby.Text + " " + Table[y].ToString();
                }
                Czas.Text = "Zaladowano";
            }
        }

    }//k
}
