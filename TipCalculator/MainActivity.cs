using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TipCalculator
{
    [Activity(Label = "TipCalculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        EditText totalText;
        EditText percentText;
        Button calculateButton;
        TextView tipView;
        TextView totalView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            totalText = FindViewById<EditText>(Resource.Id.totalText);
            percentText = FindViewById<EditText>(Resource.Id.percentText);
            tipView = FindViewById<TextView>(Resource.Id.tipText);
            totalView = FindViewById<TextView>(Resource.Id.grandTotalText);
            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);

            calculateButton.Click += delegate
            {
                ParseText();
            };
        }

        public void ParseText()
        {
            string t = totalText.Text;
            string p = percentText.Text;

            decimal total = Decimal.Parse(t);
            decimal percent = Decimal.Parse(p);

            Calculate(total, percent);
        }

        public void Calculate(decimal total, decimal percent)
        {
            decimal realPercent = percent * 0.01m;

            decimal tip = total * realPercent;
            decimal grandTotal = total + tip;

            tipView.Text = tip.ToString("F2");
            totalView.Text = grandTotal.ToString("F2");

        }
    }
}

