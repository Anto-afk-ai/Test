﻿
using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Widget;
using EAXamarinApp.Helpers;
using EAXamarinApp.Model;
using EAXamarinApp.ViewModel;
using Java.Interop;
using Plugin.CurrentActivity;


namespace EAXamarinApp.Droid
{

    [Activity(Label = "AddItemActivity")]
    public class AddItemActivity : Activity
    {
        FloatingActionButton saveButton;
        EditText title, description;

        public Item Item { get; set; }
        public ItemsViewModel viewModel { get; set; }
        public BaseViewModel baseModel { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_add_item);
            saveButton = FindViewById<FloatingActionButton>(Resource.Id.save_button);
            title = FindViewById<EditText>(Resource.Id.txtTitle);
            description = FindViewById<EditText>(Resource.Id.txtDesc);

            saveButton.Click += SaveButton_Click;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var _item = new Item();
            _item.Text = title.Text;
            _item.Description = description.Text;

            MessagingCenter.Send(this, "AddItem", _item);
            Finish();
        }

        [Export("BackDoorDemo")]
        public void BackDoorDemo()
        {
            title.Text = title.Text + "I am hacking from the other way around";
        }
    }
}
