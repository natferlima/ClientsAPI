using clientsapi.Models;
using clientsapi.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clientsapi
{
    public partial class Index : System.Web.UI.Page
    {
        HttpClient httpClient;

        public Index()
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://localhost:50381");
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetClients();
                GetClientSituations();
                GetClientTypes();
            }
        }

        private void GetClients()
        {
            HttpResponseMessage response = httpClient.GetAsync("api/client/").Result;

            if (response.IsSuccessStatusCode)
            {
                var clients = response.Content.ReadAsAsync<IEnumerable<Client>>().Result;
                var clientsList = clients
                    .Select(client => new
                    {
                        IdCliente = client.Id,
                        Nome = client.Name,
                        CPF = client.CPF,
                        Sexo = client.Gender,
                        IdTipoCliente = client.IdType,
                        IdSituacaoCliente = client.IdSituation,

                    }).ToList();
                GridView1.DataSource = clientsList;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label7.Text = "";
            Label8.Text = "";
            if(TextBox1.Text != "")
            {
                var uri = "api/client/" + TextBox1.Text;
                HttpResponseMessage response = httpClient.GetAsync(uri).Result;
                if(response.IsSuccessStatusCode)
                {
                    var client = response.Content.ReadAsAsync<Client>().Result;
                    TextBox2.Text = client.Name;
                    TextBox3.Text = client.CPF;
                    TextBox4.Text = client.Gender;
                    DropDownList1.SelectedIndex = client.IdType;
                    DropDownList3.SelectedIndex = client.IdSituation;
                }
                else
                {
                    Label7.Text = "Cliente não encontrado";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                }
            }
            else
            {
                Label7.Text = "É obrigatório informar o id do cliente.";
            }
            

        }

        private void GetClientSituations()
        {
            HttpResponseMessage response = httpClient.GetAsync("api/clientsituation/").Result;

            if (response.IsSuccessStatusCode)
            {
                var clientSituations = response.Content.ReadAsAsync<IEnumerable<ClientSituation>>().Result;
                var clientSituationsList = clientSituations
                    .Select(clientSituation => new ListItem
                    (
                        clientSituation.Description,
                        clientSituation.Id.ToString()

                    ));

                DropDownList3.DataSource = clientSituationsList;
                DropDownList3.DataBind();

                ListItem itemSelect = new ListItem(" Selecione ", "-1");
                DropDownList3.Items.Insert(0, itemSelect);
                DropDownList3.DataValueField = "Text";
                DropDownList3.DataSource = clientSituations;
            }
        }

        private void GetClientTypes()
        {
            HttpResponseMessage response = httpClient.GetAsync("api/clienttype/").Result;

            if (response.IsSuccessStatusCode)
            {
                var clientTypes = response.Content.ReadAsAsync<IEnumerable<ClientType>>().Result;
                var clientTypesList = clientTypes
                    .Select(clientType => new ListItem
                    (
                        clientType.Description,
                        clientType.Id.ToString()

                    ));

                DropDownList1.DataSource = clientTypesList;
                DropDownList1.DataBind();

                ListItem itemSelect = new ListItem(" Selecione ", "-1");
                DropDownList1.Items.Insert(0, itemSelect);
                DropDownList1.DataTextField = "Value";
                DropDownList1.DataValueField = "Text";
                DropDownList1.DataSource = clientTypes;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label7.Text = "";
            Label8.Text = "";
            Client client = new Client()
            {
                Name = TextBox2.Text,
                CPF = TextBox3.Text,
                IdType = DropDownList1.SelectedIndex,
                Gender = TextBox4.Text,
                IdSituation = DropDownList3.SelectedIndex,
            };

            HttpResponseMessage response = httpClient.PostAsJsonAsync("api/client/", client).Result;

            if(response.IsSuccessStatusCode)
            {
                Label8.Text = "Cliente cadastrado com sucesso!";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                DropDownList1.ClearSelection();
                DropDownList3.ClearSelection();
                GetClients();
            }
            else 
            {
                Label8.Text = "Não foi possível cadastrar o cliente.";
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Label7.Text = "";
            Label8.Text = "";
            if(TextBox1.Text != "")
            {
                var uri = "api/client/" + TextBox1.Text;
                Client client = new Client()
                {
                    Name = TextBox2.Text,
                    CPF = TextBox3.Text,
                    IdType = DropDownList1.SelectedIndex,
                    Gender = TextBox4.Text,
                    IdSituation = DropDownList3.SelectedIndex,
                };

                HttpResponseMessage response = httpClient.PutAsJsonAsync(uri, client).Result;

                if (response.IsSuccessStatusCode)
                {
                    Label8.Text = "As informações do cliente foram atualizadas com sucesso!";
                    Label7.Text = "";
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    DropDownList1.ClearSelection();
                    DropDownList3.ClearSelection();
                    GetClients();
                }
                else
                {
                    Label8.Text = "Não foi possível atualizar as informaçãoes cliente.";
                }
            }
            else
            {
                Label7.Text = "É obrigatório informar o id do cliente.";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Label7.Text = "";
            Label8.Text = "";
            if(TextBox1.Text != "")
            {
                var uri = "api/client/" + TextBox1.Text;
                HttpResponseMessage response = httpClient.DeleteAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    Label8.Text = "Cliente removido com sucesso!";
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    DropDownList1.ClearSelection();
                    DropDownList3.ClearSelection();
                    GetClients();
                }
                else
                {
                    Label8.Text = "Não foi possível remover o cliente.";
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    DropDownList1.ClearSelection();
                    DropDownList3.ClearSelection();
                }
            }
            else
            {
                Label7.Text = "É obrigatório informar o id do cliente.";
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Label7.Text = "";
            Label8.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            DropDownList1.ClearSelection();
            DropDownList3.ClearSelection();
        }
    }
}