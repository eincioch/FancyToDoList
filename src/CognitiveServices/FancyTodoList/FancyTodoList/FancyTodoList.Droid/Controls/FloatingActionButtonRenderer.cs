﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using FAB = Android.Support.Design.Widget.FloatingActionButton;
using Xamarin.Forms.Platform.Android;
using Android.Content.Res;
using System.ComponentModel;
using FancyTodoList.Controls;
using FancyTodoList.Droid.Controls;

[assembly: ExportRenderer(typeof(FloatingActionButton), typeof(FloatingActionButtonRenderer))]
namespace FancyTodoList.Droid.Controls
{
    [Obsolete]
    public class FloatingActionButtonRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<FloatingActionButton, FAB>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<FloatingActionButton> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            var fab = new FAB(Context);
            // set the bg
            fab.BackgroundTintList = ColorStateList.ValueOf(Element.ButtonColor.ToAndroid());

            // set the icon
            var elementImage = Element.Image;
            var imageFile = elementImage?.File;

            if (imageFile != null)
            {
                fab.SetImageDrawable(Context.Resources.GetDrawable(imageFile));
            }
            fab.Click += Fab_Click;
            SetNativeControl(fab);

        }
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            Control.BringToFront();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var fab = (FAB)Control;
            if (e.PropertyName == nameof(Element.ButtonColor))
            {
                fab.BackgroundTintList = ColorStateList.ValueOf(Element.ButtonColor.ToAndroid());
            }

            if (e.PropertyName == nameof(Element.Image))
            {
                var elementImage = Element.Image;
                var imageFile = elementImage?.File;

                if (imageFile != null)
                {
                    fab.SetImageDrawable(Context.Resources.GetDrawable(imageFile));
                }
            }

            base.OnElementPropertyChanged(sender, e);
        }

        private void Fab_Click(object sender, EventArgs e)
        {
            // proxy the click to the element
            ((IButtonController)Element).SendClicked();
        }
    }
}