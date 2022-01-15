using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP_Final.Resources.Model;

namespace TP_Final.Resources.Database
{
    public class Database
    {
        private readonly string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool CriarBanco()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Mercadorias.db")))
                {
                    conexao.CreateTable<Mercadoria>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool InserirMercadoria(Mercadoria mercadoria)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Mercadorias.db")))
                {
                    conexao.Insert(mercadoria);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public List<Mercadoria> BuscarMercadorias()
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Mercadorias.db")))
                {
                    return conexao.Table<Mercadoria>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public bool AtualizarMercadorias(Mercadoria mercadoria)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Mercadorias.db")))
                {
                    conexao.Query<Mercadoria>("UPDATE Mercadoria set Nome=?,Peso=?,NCM=?, NomeProdutor=?, EmailProdutor=? Where Id=?", mercadoria.Nome, mercadoria.Peso, mercadoria.NCM, mercadoria.NomeProdutor, mercadoria.EmailProdutor, mercadoria.Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool DeletarMercadorias(Mercadoria mercadoria)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Mercadorias.db")))
                {
                    conexao.Delete(mercadoria);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool GetMercadorias(int Id)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Mercadorias.db")))
                {
                    conexao.Query<Mercadoria>("SELECT * FROM Mercadoria Where Id=?", Id);
                    
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
    }
}