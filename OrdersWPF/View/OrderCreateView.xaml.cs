using Microsoft.Extensions.DependencyInjection;
using OrdersWPF.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OrdersWPF.View
{
    public partial class OrderCreateView : UserControl
    {
        public IEntityService entityService;
        public ITagEditor tagEditor;
        public List<string> listTags = new List<string>();
        public List<Tag> tagCollection = new List<Tag>();
        public List<Order> query;
        public OrderCreateView()
        {
            InitializeComponent();
            var array = Enum.GetValues(typeof(Tags));
            foreach (var item in array)
            {
                Tag t = new Tag(item.ToString(), false);
                tagCollection.Add(t);
            }
            dgTags.ItemsSource = tagCollection;
            UpdateCreate();
        }
        public async Task UpdateCreate()
        {
            entityService = MainWindow.serviceProvider.GetService<IEntityService>();
            tagEditor = MainWindow.serviceProvider.GetService<ITagEditor>();
            await Task.Run(() =>
            {
                query = entityService.ReadOrder();
            });
            dgOrderCreate.ItemsSource = query;
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {        
                Order o = new Order();
                o.Name_product = txtNamePro.Text;
                o.ID_Worker = Convert.ToInt64(txtWorkerID.Text);
                o.Tags = tagEditor.TagsUpdateSave(tagCollection);
                entityService.CreateOrder(o);
                UpdateCreate();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void chbTag_Click(object sender, RoutedEventArgs e)
        {
            Tag t = dgTags.SelectedItem as Tag;
            if (t._check == true)
            {
                Tag tt = new Tag(t._tag, false);
                tagCollection.Remove(t);
                tagCollection.Add(tt);
            }
            if (t._check == false)
            {
                Tag tt = new Tag(t._tag, true);
                tagCollection.Remove(t);
                tagCollection.Add(tt);
            }
        }
    }
}
