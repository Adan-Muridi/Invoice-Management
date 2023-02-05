using AutoMapper;
using Invoice_Management.Application.Invoices.Commands;
using Invoice_Management.Application.Invoices.DTOs;
using Invoice_Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Management.Application.Invoices.MappingProfile
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice,InvoiceDTO>();
            CreateMap<InvoiceItem,InvoiceItemDTO>().ConstructUsing(i=>new InvoiceItemDTO
            {
                Id= i.Id,
                Item= i.Item,
                Quantiity= i.Quantiity,
                Rate= i.Rate,
            });

            CreateMap<InvoiceDTO, Invoice>();
            CreateMap<InvoiceItemDTO, InvoiceItem>();

            CreateMap<CreateInvoiceCommand,Invoice>();

        }
    }
}
