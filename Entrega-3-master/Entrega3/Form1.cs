﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3
{
    public partial class Form1 : Form
    {
        private const int FILAS = 8;
        private const int COLUMNAS = 8;
        private const int CELDAS = 64;

        Bitmon bitmons = new Bitmon();
        List<Button> listaBotones;
        Button[,] matrizBotones;
        bool[,] terreno;
        bool[,] hayBitmon;
        Terreno terreno1 = new Terreno();
        AgregarBitmons addBitmon = new AgregarBitmons();
        
        int time;

        public Form1()
        {
            InitializeComponent();

            matrizBotones = new Button[FILAS, COLUMNAS];
            terreno = new bool[FILAS, COLUMNAS];
            hayBitmon = new bool[FILAS, COLUMNAS];

            listaBotones = new List<Button>();
            for (int fila = 0; fila < FILAS; fila++)
            {
                for (int columna = 0; columna < COLUMNAS; columna++)
                {
                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.Margin = new Padding(0, 0, 0, 0);
                    button.Padding = new Padding(0, 0, 0, 0);
                    button.FlatStyle = FlatStyle.Popup;
                    button.Click += cell_Click;
                    button.BackColor = Color.LightGray;
                    button.FlatAppearance.BorderSize = 0;
                    tableLayoutPanel1.Controls.Add(button, columna, fila);
                    matrizBotones[fila, columna] = button;
                    listaBotones.Add(button);
                }

            }
            
            terreno1.ConfiguracionTerreno(matrizBotones, terreno, CELDAS, COLUMNAS, FILAS);
            
        }

        private void agregarBitmon()
        {

        }
        private void configurarmapa()
        {
            for (int fila = 0; fila < FILAS; fila++)
            {
                for (int columna = 0; columna < COLUMNAS; columna++)
                {
                    hayBitmon[fila, columna] = false;

                }

            }

            Random random = new Random();
            int creados = 0;
            while (creados < bitmonsiniciales)
            { 
                int fila = random.Next(FILAS);
                int columna = random.Next(COLUMNAS);
                bool existeUnBombmon = hayBitmon[fila, columna];
                if (!existeUnBombmon)
                {
                    hayBitmon[fila, columna] = true;
                    matrizBotones[fila, columna].Text = "bitmon";
                    creados++;
                }

            }


        }

        
        private void cell_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            int filaBoton = 0;
            int columnaBoton = 0;

            // Para la posición del botón
            for (int fila = 0; fila < FILAS; fila++)
            {
                for (int columna = 0; columna < COLUMNAS; columna++)
                {
                    if (boton == matrizBotones[fila, columna])
                    {
                        filaBoton = fila;
                        columnaBoton = columna;
                        break;
                    }
                }
            }
        }
        

    }

}