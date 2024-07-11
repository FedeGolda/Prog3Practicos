using System;
using System.Collections.Generic;

namespace ObligatorioProg3.Models;

public partial class Clima
{
    public int Id { get; set; }

    public DateTime? Fecha { get; set; }

    public double Temperatura { get; set; }

    public string DescripciónClima { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();


    public double CalcularDescuentoAdicional(double precioInicial)
    {
        double precioConDescuento = precioInicial;

        // Aplicar descuento adicional basado en la temperatura
        if (Temperatura < 0)
        {
            // Aplicar un descuento del 10% adicional
            precioConDescuento *= 0.90;
        }
        else if (Temperatura < 10)
        {
            // Aplicar un descuento del 5% adicional
            precioConDescuento *= 0.95;
        }

        return precioConDescuento;
    }



}
