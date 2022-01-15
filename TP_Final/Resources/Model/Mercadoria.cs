using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Annotations;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_Final.Resources.Model
{
    public class Mercadoria
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Peso { get; set; }
        public int NCM { get; set; }
        public string NomeProdutor { get; set; }
        public string EmailProdutor { get; set; }
    }
}