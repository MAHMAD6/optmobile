using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer;

public partial class OtpPage : ContentPage
{
    public OtpPage(OtpViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        txtOne.Focus(); //This line is not working means it should focused on first text box
    }

    // Move the cursor to the next and previous field when user enter or deletes a value
    private void OtpEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var currentEntry = sender as Entry;
        if (currentEntry != null && string.IsNullOrEmpty(currentEntry.Text))
        {
            if (currentEntry == txtTwo)
            {
                txtOne.Focus();
            }
            else if (currentEntry == txtThree)
            {
                txtTwo.Focus();
            }
            else if (currentEntry == txtFour)
            {
                txtThree.Focus();
            }
        }
        else if (currentEntry != null && !string.IsNullOrEmpty(currentEntry.Text))
        {
            if (currentEntry == txtOne)
            {
                txtTwo.Focus();
            }
            else if (currentEntry == txtTwo)
            {
                txtThree.Focus();
            }
            else if (currentEntry == txtThree)
            {
                txtFour.Focus();
            }
        }
    }
}

/*
 
//Following code execute on completed event if user press enter after entering value in textbox
    private void OtpEntry_Completed(object sender, EventArgs e)
    {
        var currentEntry = sender as Entry;
        if (currentEntry != null)
        {
            if (currentEntry == txtOne && !string.IsNullOrEmpty(currentEntry.Text))
            {
                txtTwo.Focus();
            }
            else if (currentEntry == txtTwo && !string.IsNullOrEmpty(currentEntry.Text))
            {
                txtThree.Focus();
            }
            else if (currentEntry == txtThree && !string.IsNullOrEmpty(currentEntry.Text))
            {
                txtFour.Focus();
            }
        }
    }
 */