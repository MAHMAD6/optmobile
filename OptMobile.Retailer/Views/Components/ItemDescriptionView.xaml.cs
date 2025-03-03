using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer.Views.Components;

public partial class ItemDescriptionView : ContentView
{
    public ItemDescriptionView()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty PassedParameterProperty =
        BindableProperty.Create(
            nameof(PassedParameter),
            typeof(string),
            typeof(ItemDescriptionView),
            default(string),
            propertyChanged: OnPassedParameterChanged);

    public string PassedParameter
    {
        get => (string)GetValue(PassedParameterProperty);
        set => SetValue(PassedParameterProperty, value);
    }

    private static async void OnPassedParameterChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is ItemDescriptionView view)
        {
            view.BindingContext = new ItemDescriptionViewModel
            {
                PassedParameter = oldValue as string
            };
        }
    }
}
