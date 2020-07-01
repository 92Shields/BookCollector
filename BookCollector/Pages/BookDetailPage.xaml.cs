using BookCollector.Models;
using BookCollector.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookCollector.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookDetailPage : ContentPage
    {
        private BookDetailViewModel ViewModel;

        public BookDetailPage(Guid bookId)
        {
            InitializeComponent();
            this.ViewModel = new BookDetailViewModel(Navigation, bookId);
            BindingContext = this.ViewModel;
        }

        public async void DeleteBook_Click(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Are you sure?", "Cancel", null, "Confirm");

            switch (action)
            {
                case "Confirm":
                    
                    await this.ViewModel.DeleteBook();
                    break;
            }
        }

        public async void EditTitle_Click(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync(title:"Title", message:"", cancel:"Cancel", initialValue:title.Text);
            if (String.IsNullOrEmpty(result)) return;
            await ViewModel.UpdateTitle(result);
            title.Text = result;
        }

        public async void EditAuthor_Click(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync(title: "Author", message: "", initialValue: author.Text);
            if (String.IsNullOrEmpty(result)) return;
            await ViewModel.UpdateAuthor(result);
            author.Text = result;
        }

        public async void EditIsbn_Click(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync(title: "ISBN", message: "", initialValue: isbn.Text, keyboard:Keyboard.Numeric);
            await ViewModel.UpdateIsbn(result);
            isbn.Text = result;
        }

        public async void EditPublisher_Click(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync(title: "Publisher", message: "", initialValue: publisher.Text);
            await ViewModel.UpdatePublisher(result);
            publisher.Text = result;
        }

        public async void EditEdition_Click(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync(title: "Title", message: "", initialValue: edition.Text, keyboard: Keyboard.Numeric);
            await ViewModel.UpdateEdition(result);
            edition.Text = result;
        }

        public async void EditPublishDate_Click(object sender, EventArgs e)
        {
            publishDatePicker.IsEnabled = true;
            publishDatePicker.Focus();
            publishDatePicker.DateSelected += OnPublishDateSelected;
            publishDatePicker.Unfocused += delegate { publishDatePicker.IsEnabled = false; };
        }

        private async void OnPublishDateSelected(object sender, DateChangedEventArgs e)
        {
            var result = e.NewDate;
            await ViewModel.UpdatePublishDate(result);
        }

        public async void EditPageCount_Click(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync(title: "Title", message: "", initialValue: pageCount.Text, keyboard: Keyboard.Numeric);
            await ViewModel.UpdatePageCount(result);
            pageCount.Text = result;
        }

        public async void EditLocation_Click(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync(title: "Title", message: "", initialValue: "");
            await ViewModel.UpdateLocation(result);
            location.Text = result;
        }

        public async void EditSigned_Click(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Signed", "Is the book signed?", "Yes", "No");
            await ViewModel.UpdateSigned(result);
            signedEntry.IsChecked = true;
        }

        public async void EditProof_Click(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Proof", "Is the book a proof?", "Yes", "No");
            await ViewModel.UpdateProof(result);
            proofEntry.IsChecked = true;
        }

        public async void EditPurchasePrice_Click(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync(title: "Title", message: "", initialValue: purchasePrice.Text, keyboard: Keyboard.Numeric);
            await ViewModel.UpdatePurchasePrice(result);
            purchasePrice.Text = result;
        }

        public async void EditValuation_Click(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync(title: "Title", message: "", initialValue: valuation.Text, keyboard: Keyboard.Numeric);
            await ViewModel.UpdateValuation(result);
            valuation.Text = result;
        }

        public async void EditRating_Click(object sender, EventArgs e)
        {
            string result = await DisplayActionSheet("Rating", "Cancel", null, "1", "2", "3", "4", "5");
            await ViewModel.UpdateRating(result);
            rating.Text = result;
        }

        public async void EditCondition_Click(object sender, EventArgs e)
        {
            conditionPicker.IsEnabled = true;
            conditionPicker.Focus();
            conditionPicker.SelectedIndexChanged += OnConditionSelected;
            conditionPicker.Unfocused += delegate { conditionPicker.IsEnabled = false; };
        }

        private async void OnConditionSelected(object sender, EventArgs e)
        {
            var result = (string)conditionPicker.SelectedItem;
            await ViewModel.UpdateCondition(result);
        }

        public async void EditLendingStatus_Click(object sender, EventArgs e)
        {
            lendingPicker.IsEnabled = true;
            lendingPicker.Focus();
            lendingPicker.SelectedIndexChanged += OnLendingStatusSelected;
            lendingPicker.Unfocused += delegate { lendingPicker.IsEnabled = false; };
        }

        private async void OnLendingStatusSelected(object sender, EventArgs e)
        {
            var result = (string)lendingPicker.SelectedItem;
            await ViewModel.UpdateLendingStatus(result);
        }

        public async void EditLentTo_Click(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync(title: "Lent To", message: "", initialValue: lentTo.Text);
            await ViewModel.UpdateLentTo(result);
            lentTo.Text = result;
        }
    }
}