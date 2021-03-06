﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3
{
    class Wetar : Bitmon
    {
        public Wetar(int tiempoDeVida, int puntosDeVida, int puntosDeAtaque, int cantidadDeHijos, int posicionX, int posicionY)
        {
            this.tiempoDeVida = tiempoDeVida;
            this.puntosDeVida = puntosDeVida;
            this.puntosDeAtaque = puntosDeAtaque;
            especie = "🐳";
            this.cantidadDeHijos = cantidadDeHijos;
            this.posicionX = posicionX;
            this.posicionY = posicionY;
        }


        public override void CambioTerreno(Button[,] matrizBotones)
        {
        }
        public override bool AfinidadTerreno(Button[,] matrizBotones)
        {
            if (matrizBotones[posicionX, posicionY].BackColor == Color.Aqua)
            {
                afin = true;
                return afin;
            }
            else
            {
                afin = false;
                return afin;
            }
        }
        public  bool AfinidadTerrenoSiguiente(Button[,] matrizBotones)
        {
            if (matrizBotones[posicionX, posicionY-1].BackColor == Color.Aqua) 
            {
                afin = true;
                return afin;
            }
            else if (matrizBotones[posicionX, posicionY +1].BackColor == Color.Aqua) 
            {
                afin = true;
                return afin;
            }
            else if (matrizBotones[posicionX+1, posicionY ].BackColor == Color.Aqua) 
            {
                afin = true;
                return afin;
            }
            if (matrizBotones[posicionX-1, posicionY].BackColor == Color.Aqua)
            {
                afin = true;
                return afin;
            }
            else 
            {
                afin = false;
                return afin;
            }
        }
        public override int Daño(Bitmon bitmon) //Daño, recibe el otro bitmon en la misma celda
        {
            if (bitmon.Especie() == "🐉" || bitmon.Especie() == "🐍")
            {
                return puntosDeAtaque * 2;
            }
            else
            {
                return Convert.ToInt32(puntosDeAtaque * 0.5);
            }
        }
       public override void Desplazamiento(Button[,] matrizBotones) 
        {

                int direccion = random.Next(4);
            if(AfinidadTerreno(matrizBotones))
                if (direccion == 1 && posicionX<=6) // con 0 se mueve hacia la derecha
                {
                    posicionX += 1;
                    direccionMov = direccion;
                    
                }
                else if (direccion == 2 && posicionX>=1) // con 1 se mueve hacia la izquierda
                {
                    posicionX -= 1;
                    direccionMov = direccion;

                }
                else if (direccion == 0 && posicionY >=1) //con 2 se mueve hacia arriba
                {
                    posicionY -= 1;
                    direccionMov = direccion;
                }
                else if (direccion == 3 && posicionY <=6)// con 3 se mueve hacia abajo            
                {
                    posicionY += 1;
                    direccionMov = direccion;
                }

           
            }

        public override bool AfinidadBitmons(Bitmon bitmon)
        {
            if(bitmon.Especie() == "🐉" || bitmon.Especie() == "🐍" || bitmon.Especie() == "🌵")
            {
                afin = false;
                return afin;
            }
            else
            {
                afin = true;
                return afin;
            }
        }
    }
        }

    

