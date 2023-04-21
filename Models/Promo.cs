namespace AR_Ejercicio2Tablas.Models
{
    public class Promo
    {
        public int PromoId { get; set; }
        public string? PromoType { get; set; }
        public DateTime FechaPromo { get; set; }

        public int BurguerId { get; set; }
        public Burguer? Burguer { get; set; }


        public List<Promo>? Promos { get; set; }


    }
}
