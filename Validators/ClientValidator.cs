using clientsapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace clientsapi.Validators
{
    public class ClientValidator
    {
        public Validation ValidatorAdd(Client client)
        {
            Validation validation = new Validation();

            if (client.Name == "" || client.Name == null)
            {
                validation.Error = "O nome do cliente é obrigatório.";
                return validation;
            }
            
            if (client.Name.Length < 3)
            {
                validation.Error = "O nome precisa ter mais do que 3 caracteres.";
                return validation;
            }

            string pattern = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";
            bool result = Regex.IsMatch(client.CPF, pattern);
            if (!result)
            {
                validation.Error = "O CPF está no formato inválido. Use pontos, traço e 11 números.";
                return validation;
            }
            
            if(client.Gender == "" || client.Gender == null)
            {
                validation.Error = "O campo sexo é obrigatório.";
                return validation;
            }

            if(client.IdSituation <= 0)
            {
                validation.Error = "É obrigatório informar a situação do cliente";
                return validation;
            }

            if (client.IdType <= 0)
            {
                validation.Error = "É obrigatório informar o tipo do cliente";
                return validation;
            }

            return validation;
        }
    }
}