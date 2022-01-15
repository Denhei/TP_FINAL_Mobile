using Android.App;
using Android.OS;
using Android.Widget;
using TP_Final.Resources;
using TP_Final.Resources.Database;
using TP_Final.Resources.Model;
using System.Collections.Generic;
using System;
using TP_Final;
using Android.Runtime;

namespace App.Crud_Xamarin
{
    [Activity(Label = "Lucas Sergio: CB3007626 | Eleson Souza: CB3007235", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ListView lvDados;
        List<Mercadoria> listaAlunos = new List<Mercadoria>();
        Database db;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_main);

            //criar banco de dados
            CriarBancoDados();
            lvDados = FindViewById<ListView>(Resource.Id.lvDados);
            var txtNome = FindViewById<EditText>(Resource.Id.txtNome);
            var txtPeso = FindViewById<EditText>(Resource.Id.txtIdade);
            var txtNCM = FindViewById<EditText>(Resource.Id.txtNCM);
            var txtNomeProdutor = FindViewById<EditText>(Resource.Id.txtNomeProdutor);
            var txtEmailProdutor = FindViewById<EditText>(Resource.Id.txtEmailProdutor);
            var btnIncluir = FindViewById<Button>(Resource.Id.btnIncluir);
            var btnEditar = FindViewById<Button>(Resource.Id.btnEditar);
            var btnDeletar = FindViewById<Button>(Resource.Id.btnDeletar);
            var btnLocalizar = FindViewById<Button>(Resource.Id.btnLocalizacao);

            //carregar Dados
            CarregarDados();

            //botão Incluir
            btnIncluir.Click += delegate
            {
                Mercadoria aluno = new Mercadoria()
                {
                    Nome = txtNome.Text,
                    Peso = Convert.ToDecimal(txtPeso.Text),
                    NCM = Convert.ToInt32(txtNCM.Text),
                    NomeProdutor = txtNomeProdutor.Text,
                    EmailProdutor = txtEmailProdutor.Text
                };
                db.InserirMercadoria(aluno);
                CarregarDados();
                
                LimparCampos(txtNome, txtPeso, txtNCM, txtNomeProdutor, txtEmailProdutor);
            };
            //botão editar
            btnEditar.Click += delegate
            {
                Mercadoria aluno = new Mercadoria()
                {
                    Id = int.Parse(txtNome.Tag.ToString()),
                    Nome = txtNome.Text,
                    Peso = Decimal.Parse(txtPeso.Text),
                    NCM = Convert.ToInt32(txtNCM.Text),
                    NomeProdutor = txtNomeProdutor.Text,
                    EmailProdutor = txtEmailProdutor.Text
                };
                db.AtualizarMercadorias(aluno);
                CarregarDados();

                LimparCampos(txtNome, txtPeso, txtNCM, txtNomeProdutor, txtEmailProdutor);
            };
            //botão deletar
            btnDeletar.Click += delegate
            {
                Mercadoria aluno = new Mercadoria()
                {
                    Id = int.Parse(txtNome.Tag.ToString()),
                    Nome = txtNome.Text,
                    Peso = Decimal.Parse(txtPeso.Text),
                    NCM = Convert.ToInt32(txtNCM.Text),
                    NomeProdutor = txtNomeProdutor.Text,
                    EmailProdutor = txtEmailProdutor.Text
                };
                db.DeletarMercadorias(aluno);
                CarregarDados();

                LimparCampos(txtNome, txtPeso, txtNCM, txtNomeProdutor, txtEmailProdutor);
            };
            //evento itemClick do ListView
            lvDados.ItemClick += (s, e) =>
            {
                for (int i = 0; i < lvDados.Count; i++)
                {
                    //if (e.Position == i)
                    //    lvDados.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Chocolate);
                    //else
                    //    lvDados.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
                //vinculando dados do listview 
                var lvtxtNome = e.View.FindViewById<TextView>(Resource.Id.txtvNome);
                var lvtxtPeso = e.View.FindViewById<TextView>(Resource.Id.txtvPeso);
                var lvtxtNCM = e.View.FindViewById<TextView>(Resource.Id.txtvNCM);
                var lvtxtNomeProdutor = e.View.FindViewById<TextView>(Resource.Id.txtvNomeProdutor);
                var lvtxtEmailProdutor = e.View.FindViewById<TextView>(Resource.Id.txtvEmailProdutor);
                txtNome.Text = lvtxtNome.Text;
                txtNome.Tag = e.Id;
                txtPeso.Text = lvtxtPeso.Text;
                txtNCM.Text = lvtxtNCM.Text;
                txtNomeProdutor.Text = lvtxtNomeProdutor.Text;
                txtEmailProdutor.Text = lvtxtEmailProdutor.Text;
            };

            btnLocalizar.Click += delegate
            {
                ShowLocation();
            };
        }

        private static void LimparCampos(EditText txtNome, EditText txtPeso, EditText txtNCM, EditText txtNomeProdutor, EditText txtEmailProdutor)
        {
            txtNome.Text = string.Empty;
            txtPeso.Text = string.Empty;
            txtNCM.Text = string.Empty;
            txtNomeProdutor.Text = string.Empty;
            txtEmailProdutor.Text = string.Empty;
        }

        //rotina para criar o banco de dados
        private void CriarBancoDados()
        {
            db = new Database();
            db.CriarBanco();
        }
        //Obtem todos os alunos da tabela Aluno e exibe no ListView
        private void CarregarDados()
        {
            listaAlunos = db.BuscarMercadorias();
            var adapter = new ListViewAdapter(this, listaAlunos);
            lvDados.Adapter = adapter;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public async void ShowLocation()
        {
            var localizacao = await Xamarin.Essentials.Geolocation.GetLastKnownLocationAsync();
            AlertDialog.Builder alert = new AlertDialog.Builder(this);

            alert.SetTitle("Sua localização atual");

            if (localizacao != null)
            {
                alert.SetMessage($@"Latitude: {localizacao.Latitude.ToString()} {System.Environment.NewLine} 
                                    Longiude: {localizacao.Longitude.ToString()} {System.Environment.NewLine}
                                    Altitude: {localizacao.Longitude.ToString()}");
            }
            else
            {
                alert.SetMessage("Falha ao puxar a localização");
            }

            Dialog dialog = alert.Create();
            dialog.Show();
        }
    }
}