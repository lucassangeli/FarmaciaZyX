//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Farmacia.DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemVenda
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public int IdVenda { get; set; }
        public int Quantidade { get; set; }
        public double ValorVenda { get; set; }
    
        public virtual Produto Produto { get; set; }
        public virtual Venda Venda { get; set; }
    }
}
