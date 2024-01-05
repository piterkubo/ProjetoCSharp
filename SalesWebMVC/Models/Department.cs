using System;
//importando a biblioteca do icollection
using System.Collections.Generic;

// importando a biblioteca para calcular via lambda o total de vendas via depto
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        
        //importando uma coleção de sellers e instanciando 
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();




        //criando o construtor

        public Department()
        {

        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }


        //criando metodo para add o vendedor


        public void AddSeller(Seller seller)
        {

            Sellers.Add(seller);

        }


        // criando metodo para calcular o total de vendas do depto
        public double TotalSales(DateTime initial, DateTime final)
        {

            return Sellers.Sum (seller => seller.TotalSales(initial, final));
        }

    }
}
