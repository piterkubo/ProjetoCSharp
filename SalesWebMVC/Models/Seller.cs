using System;

// importando a biblioteca icollection para criar o relacionamento de salesrecord.
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


// importando a biblioteca linq para retorno do calculo via lambda
using System.Linq;




namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }

        //implementando uma anotation[]
        // {0} = nome do atributo
        // {1} = o valor max 60 declarado
        // {2} = o valor min 3 declarado


        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "{0} required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //criando o anotation display []
        [Display(Name = "Dt Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }


        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Salario Base")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double BaseSalary { get; set; }


        // declarando o relacionamento dos vendedores com o departamento
        public Department Department { get; set; }



        // Declarando o metodo para não deixar o id como null
        public int DepartmentId { get; set; }



        //importando a coleção de salesrecord e instanciando.
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();


        // criando o construtor

        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }



        // criando um metodo para add o vendedor na lista de venda

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }



        // criando um metodo para remover a venda desse vendedor


        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }


        // criando um memtod para calcular o total de vendas do vendedor

        public double TotalSales(DateTime initial, DateTime final)
        {

            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);

        }


    }
}
