using Microsoft.Extensions.DependencyInjection;
using OrdersWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OrdersWPF.View
{
    public partial class OrderUpdateView : UserControl
    {
        public IEntityService entityService;
        public ITagEditor tagEditor;
        public List<string> listTags = new List<string>();
        public List<Tag> tagCollection = new List<Tag>();
        public List<Order> query;
        public long index;
        public OrderUpdateView()
        {
            InitializeComponent();
            var array = Enum.GetValues(typeof(Tags));
            foreach (var item in array)
            {
                listTags.Add(item.ToString());
            }
            UpdateDg();
        }
        public void TagsManager(List<string> List)
        {
            using (UsingBase db = new UsingBase())
            {
                var query = (from q in db.Order
                         where q.ID_Order == index
                         select q.Tags).First();
                var rtrArr = tagEditor.Splitter(query);
                if (rtrArr != null)
                {
                    foreach (var item in rtrArr)
                    {
                        foreach (var tag in List)
                        {
                            if (item == tag)
                            {
                                Tag t = new Tag(item, true);
                                tagCollection.Add(t);
                            }
                            else
                            {
                                Tag t = new Tag(tag, false);
                                tagCollection.Add(t);
                            }
                        }
                    }
                }
            }
            var a = tagCollection.Where(x => x._check == true).GroupBy(x => x._tag).Select(x => x.First()).ToList();
            var b = tagCollection.GroupBy(x => x._tag).Select(x => x.First()).ToList();
            tagCollection = a.Concat(b).GroupBy(x => x._tag).Select(x => x.First()).ToList();
            dgTags.ItemsSource = tagCollection;
        }
        public async Task UpdateDg()
        {
            entityService = MainWindow.serviceProvider.GetService<IEntityService>();
            tagEditor = MainWindow.serviceProvider.GetService<ITagEditor>();
            await Task.Run(() =>
            {
                query = entityService.ReadOrder();
            });
            dgOrderUpdate.ItemsSource = query;
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (UsingBase db = new UsingBase())
                {
                    Order o = new Order();
                    tagCollection = dgTags.Items.Cast<Tag>().ToList();
                    o.ID_Order = index;
                    o.Name_product = txtNamePro.Text;
                    o.ID_Worker = Convert.ToInt64(txtWorkerID.Text);
                    o.Tags = tagEditor.TagsUpdateSave(tagCollection);
                    entityService.UpdateOrder(o);
                }
                UpdateDg();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void dgOrderUpdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgOrderUpdate.SelectedItem != null)
            {
                using (UsingBase db = new UsingBase())
                {
                    Order oID = dgOrderUpdate.SelectedItem as Order;
                    index = oID.ID_Order;
                    tagCollection.Clear();
                    TagsManager(listTags);  
                    var query = (from q in db.Order
                                 where q.ID_Order == index
                                 select q).First();
                    txtNamePro.Text = query.Name_product;
                    txtWorkerID.Text = query.ID_Worker.ToString();
                }
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

