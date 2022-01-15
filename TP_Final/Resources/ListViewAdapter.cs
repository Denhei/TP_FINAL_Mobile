
using Android.App;
using Android.Views;
using Android.Widget;
using TP_Final.Resources.Model;
using System.Collections.Generic;

namespace TP_Final.Resources
{
    public class ListViewAdapter : BaseAdapter
    {
        private readonly Activity context;
        private readonly List<Mercadoria> mercadorias;

        public ListViewAdapter(Activity _context, List<Mercadoria> _mercadorias)
        {
            this.context = _context;
            this.mercadorias = _mercadorias;
        }

        public override int Count
        {
            get
            {
                return mercadorias.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return mercadorias[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.ListViewLayout, parent, false);

            var lvtxtNome = view.FindViewById<TextView>(Resource.Id.txtvNome);
            var lvtxtPeso = view.FindViewById<TextView>(Resource.Id.txtvPeso);
            var lvtxtNCM = view.FindViewById<TextView>(Resource.Id.txtvNCM);
            var lvtxtNomeProdutor = view.FindViewById<TextView>(Resource.Id.txtvNomeProdutor);
            var lvtxtEmailProdutor = view.FindViewById<TextView>(Resource.Id.txtvEmailProdutor);

            lvtxtNome.Text = mercadorias[position].Nome;
            lvtxtPeso.Text = "" + mercadorias[position].Peso;
            lvtxtNCM.Text = mercadorias[position].NCM.ToString();
            lvtxtNomeProdutor.Text = mercadorias[position].NomeProdutor;
            lvtxtEmailProdutor.Text = "" + mercadorias[position].EmailProdutor;

            return view;

        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
    }
}