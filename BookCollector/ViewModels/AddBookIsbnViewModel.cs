using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BookCollector.ViewModels
{
    class AddBookIsbnViewModel
    {
        public INavigation Navigation { get; set; }

        public AddBookIsbnViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
        }
    }
}
