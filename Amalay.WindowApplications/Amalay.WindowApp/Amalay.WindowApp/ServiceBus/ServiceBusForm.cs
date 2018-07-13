using Amalay.Entities;
using Amalay.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amalay.WindowApp
{
    public partial class ServiceBusForm : Form
    {
        private string topicFilePath = @".\Resources\XmlFiles\TopicsAndSubscriptions.xml";

        public ServiceBusForm()
        {
            InitializeComponent();
            InitializeFields();
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeFields()
        {
            //Bind topics
            cmbTopics.DisplayMember = "Name"; //OR cmbEnvironment.ValueMember = "Name";
            cmbTopics.DataSource = ServiceBusDemo.Instance.GetTopicsAndSubscriptions(topicFilePath);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            //Select default topic.
            cmbTopics.SelectedIndex = cmbTopics.FindStringExact(Constants.DefaultSelect);   //Default selection of topic.
        }

        private void cmbTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTopics.SelectedItem != null)
            {
                var selectedItem = cmbTopics.SelectedItem as Topic;

                if (selectedItem != null && selectedItem.Name != Constants.DefaultSelect && selectedItem.Subscriptions != null && selectedItem.Subscriptions.Count > 0)
                {
                    if (!selectedItem.Subscriptions.Exists(s => s.Name == Constants.DefaultSelect))
                    {
                        selectedItem.Subscriptions.Insert(0, new Subscription() { Name = Constants.DefaultSelect });
                    }

                    cmbSubscriptions.DisplayMember = "Name";
                    cmbSubscriptions.DataSource = selectedItem.Subscriptions;

                    //Select default subscription.
                    cmbSubscriptions.SelectedIndex = cmbSubscriptions.FindStringExact(Constants.DefaultSelect);  //Default selection of subscription.
                }
                else
                {
                    cmbSubscriptions.DataSource = null;
                }
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string message = "Please select topic and subscription!";

            try
            {                
                var topic = cmbTopics.SelectedItem as Topic;
                var subscription = cmbSubscriptions.SelectedItem as Subscription;
                
                if((topic != null && topic.Name != Constants.DefaultSelect) && (subscription != null && subscription.Name != Constants.DefaultSelect))
                {
                    lblMessage.Text = "Wait.....";
                    lblMessage.ForeColor = Color.Red;

                    ServiceBusDemo.Instance.SendMessageToServiceBus(topic.Name, subscription.Name);

                    message = "Message send successfully!";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            MessageBox.Show(message, "Alert", MessageBoxButtons.OK);
            lblMessage.Text = string.Empty;            
        }

        private void btnSendJsonMessage_Click(object sender, EventArgs e)
        {
            string message = "Please select topic and subscription!";

            try
            {
                var topic = cmbTopics.SelectedItem as Topic;
                var subscription = cmbSubscriptions.SelectedItem as Subscription;

                if ((topic != null && topic.Name != Constants.DefaultSelect) && (subscription != null && subscription.Name != Constants.DefaultSelect))
                {
                    lblMessage.Text = "Wait.....";
                    lblMessage.ForeColor = Color.Red;

                    ServiceBusDemo.Instance.SendJsonMessageToServiceBus(topic.Name, subscription.Name);

                    message = "Message send successfully!";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            MessageBox.Show(message, "Alert", MessageBoxButtons.OK);
            lblMessage.Text = string.Empty;
        }

        private void btnReceiveMessage_Click(object sender, EventArgs e)
        {
            string message = "Please select topic and subscription!";

            ServiceBusDemo.Instance.ReceiveMessageToServiceBus();
        }

        private void btnCreateTopic_Click(object sender, EventArgs e)
        {
            ServiceBusDemo.Instance.CreateTopicAndSubscriptionToServiceBus();
        }

        private void ServiceBusForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
