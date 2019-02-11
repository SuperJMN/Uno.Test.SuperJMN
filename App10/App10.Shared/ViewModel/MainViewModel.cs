using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using ReactiveUI;

namespace App10.Shared.ViewModel
{
    public class MainViewModel : ReactiveObject
    {
        private Item selectedItem;
        private readonly ObservableAsPropertyHelper<long> titleOh;

        public MainViewModel()
        {
            titleOh = Observable.Interval(TimeSpan.FromSeconds(1)).ToProperty(this, model => model.Title);

            MyItems = new List<Item>
            {
                new Item
                {
                    Name = "Mario",
                    Number = 11,
                    Image = new Uri("ms-appx:///mario.png", UriKind.Absolute)
                },
                new Item
                {
                    Name = "Luigi",
                    Number = 11,
                    Image = new Uri("luigi.png", UriKind.Relative)
                },
                new Item
                {
                    Name = "Toad",
                    Number = 11,
                    Image = new Uri("ms-appx:///toad.png", UriKind.Absolute)
                },
                new Item
                {
                    Name = "Princess Peach",
                    Number = 11,
                    Image = new Uri("ms-appx:///peach.png", UriKind.Absolute)
                }
            };
        }

        public Item SelectedItem
        {
            get => selectedItem;
            set => this.RaiseAndSetIfChanged(ref selectedItem, value);
        }

        public long Title => titleOh.Value;

        public List<Item> MyItems { get; }
    }

    public class Item
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public Uri Image { get; set; }
    }
}