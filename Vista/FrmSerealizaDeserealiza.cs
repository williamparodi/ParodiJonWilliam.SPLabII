﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TpUtiles;

namespace Vista
{
    public partial class FrmSerealizaDeserealiza : Form
    {
        Cartuchera<Lapiz> cartuchera;
        private Lapiz lapiz;
        private int fila;
        private string path;
        public FrmSerealizaDeserealiza()
        {
            InitializeComponent();
            cartuchera = new Cartuchera<Lapiz>();
            lapiz = new Lapiz();
            path = "";
            cartuchera.ListaUtiles = HardcodeaLista();
        }

        private void btn_SerealizarXml_Click(object sender, EventArgs e)
        {
            try
            {
                if (path == "")
                {
                    path = "lapiz.xml";
                    lapiz.SerializaLapizXml(path, lapiz);
                    MessageBox.Show("Lapiz serealizado");
                }
                else
                {
                    lapiz.SerializaLapizXml(path, lapiz);
                    MessageBox.Show("Se Actualizo el lapiz serealizado");
                }

            }
            catch (ExceptionArchivo ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmSerealizaDeserealiza_Load(object sender, EventArgs e)
        {
            dtgv_ListaLapices.DataSource = null;
            dtgv_ListaLapices.DataSource = cartuchera.ListaUtiles;
        }

        public List<Lapiz> HardcodeaLista()
        {
            Lapiz lapiz1 = new Lapiz(10, "Faber Castell", EColor.Azul, ETipoLapiz.Normal);
            Lapiz lapiz2 = new Lapiz(25, "Larro", EColor.Amarillo, ETipoLapiz.Grafito);
            Lapiz lapiz3 = new Lapiz(166, "Jovi", EColor.Rojo, ETipoLapiz.Normal);
            Lapiz lapiz4 = new Lapiz(35, "Filgo", EColor.Negro, ETipoLapiz.Normal);
            Lapiz lapiz5 = new Lapiz(36, "Plexy", EColor.Rojo, ETipoLapiz.Grafito);
            List<Lapiz> auxLista = new List<Lapiz>();
            auxLista.Add(lapiz1);
            auxLista.Add(lapiz2);
            auxLista.Add(lapiz3);
            auxLista.Add(lapiz4);
            auxLista.Add(lapiz5);

            return auxLista;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lapiz is not null)
                {
                    lapiz.Precio = cartuchera.ListaUtiles[fila].Precio;
                    lapiz.Color = cartuchera.ListaUtiles[fila].Color;
                    lapiz.Marca = cartuchera.ListaUtiles[fila].Marca;
                    lapiz.TipoDeLapiz = cartuchera.ListaUtiles[fila].TipoDeLapiz;
                    lapiz.SerializaLapizJson(lapiz);
                    MessageBox.Show("Lapiz serealizado en fromato Json");
                }
            }
            catch (ExceptionArchivo ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgv_ListaLapices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            if (fila != -1)
            {
                if (cartuchera.ListaUtiles[fila] is not null)
                {
                    lapiz.Precio = cartuchera.ListaUtiles[fila].Precio;
                    lapiz.Color = cartuchera.ListaUtiles[fila].Color;
                    lapiz.Marca = cartuchera.ListaUtiles[fila].Marca;
                    lapiz.TipoDeLapiz = cartuchera.ListaUtiles[fila].TipoDeLapiz;
                }
            }
        }
    }

}