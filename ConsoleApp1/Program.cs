using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Konsoldan ürün listesi listelenecek 5 tane . Sonra seçilen ürünün fiyatı yazacak
             Ürünü almak istiyormusunuz diye onay alınacak. Evet veya hayır çıkacak.
             Hayır derse başa dönecek. Evet derse hangi kartla işlem yapacaksınız die sorulacak.(garanti, enpara, pttbank)
             Banka seçilecek. Ürün fiyatı tekrar sorulacak alıyormusunuz die hayır derse yine en başa dönecek.
             Evet derse hangi kargo firmasını seçtiği sorulacak.Kargo onaylanacak.
             En son ekranda 
             Ürün adı
             Ürün fiyatı 
             Sadece kdv fiyatı 
             Sadece ürün fiyatı üzerinden banka komisyon tutarı
             Kargo fiyatı
             Toplam tutar
             Kdv tutarının toplam tutar üzerindeki yüzdelik dilimi.
             */
           
            Console.WriteLine("100 tl ve üzeri alışverişinizde kargo ücreti bedava!!!");
            Console.WriteLine("Lütfen Almak İstediğiniz Ürünün Kodunu Yazınız: ");
            List<Product> products = new List<Product>();
            products.Add(new Product(55.99, "Kazak"));
            products.Add(new Product(79.99, "Pantolon"));
            products.Add(new Product(255, "Ayakkabı"));
            products.Add(new Product(125.75, "Mont"));
            products.Add(new Product(525, "Gözlük"));
        baş:
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i+1} == {products[i].Name}");
            }
            
            int seçilenürünindeks = int.Parse(Console.ReadLine());
            var seçilenürün = products[seçilenürünindeks-1];
            if(seçilenürün == null)
            {
                Console.WriteLine("Hatalı Giriş Yaptınız.");
                goto baş;
            }
            Product product = new Product();
            
            Console.WriteLine($"Seçilen {seçilenürün.Name} ürününün fiyatı: {seçilenürün.Price}");
        xy:
            Console.WriteLine("Ürünü Almak İstiyormusunuz? Evet Hayır");
            string onay = Console.ReadLine();
            if(onay.ToLower()== "evet") 
            {
                Console.WriteLine("Lütfen işlem yapacağınız bankayı seçiniz: ");
            }
            else if(onay.ToLower()=="hayır")
            {
                goto baş;
            }
            else 
            {
                Console.WriteLine("Hatalı Giriş Yaptınız. Lütfen Tekrar Deneyiniz."); goto xy;
            }

            List<Banks> bankalars = new List<Banks>();
            bankalars.Add(new Banks("Garanti",0.25));
            bankalars.Add(new Banks("HSBC",0.25));
            bankalars.Add(new Banks("Enpara",0.10));
            bankalars.Add(new Banks("HalkBank",0.15));
            bankalars.Add(new Banks("VakıfBank",0.1));
            bankalars.Add(new Banks("YapıKredi",0.15));
            for (int i = 0; i < bankalars.Count; i++)
            {
                Console.WriteLine($"{i+1} == {bankalars[i].Name}");
            }

            int seçilenbankaindeks = int.Parse(Console.ReadLine());
            var seçilenbanka = bankalars[seçilenbankaindeks-1];
        yx:
            Console.WriteLine($"{seçilenürün.Name} isimli ürünü {seçilenürün.Price} fiyata almayı onaylıyormusunuz? Evet Hayır");
            onay = Console.ReadLine();
            if (onay.ToLower() == "evet"  )
            {
                Console.WriteLine("Lütfen tercih ettiğiniz kargo firmasını seçiniz: ");
            }
            else if (onay.ToLower() == "hayır")
            {
                goto baş;
            }
            else
            {
                Console.WriteLine("Hatalı Giriş Yaptınız. Lütfen Tekrar Deneyiniz."); goto yx;
            }

            List<Cargo> cargos = new List<Cargo>();
            cargos.Add(new Cargo("Yurtiçi",12));
            cargos.Add(new Cargo("Aras",8));
            cargos.Add(new Cargo("HepsiJet",5));
            cargos.Add(new Cargo("Ptt",10));
            cargos.Add(new Cargo("Sürat",9));
            for (int i = 0; i < cargos.Count; i++)
            {
                Console.WriteLine($"{i+1} == {cargos[i].Name}");
            }
            int seçilenkargoindeks = int.Parse(Console.ReadLine());
            var seçilenkargo = cargos[seçilenkargoindeks - 1];
            double Total = seçilenürün.Price + seçilenürün.sadeceKdv() + seçilenbanka.getKomisyon(seçilenürün.Price) + seçilenkargo.Ücret;

            double kargoücreti = 0;  
            if (seçilenürün.Price<=100)
            {
                kargoücreti = seçilenkargo.Ücret;
            }

            Console.WriteLine("Sipariş bilgileriniz: " + "\n" + 
           "Ürün Adı: " + seçilenürün.Name + "\n" +
           "Fiyatı: " +seçilenürün.Price + "\n" +  
           "Kdv Fiyatı: " + seçilenürün.sadeceKdv() + "\n" +
           "Seçilen Banka: " + seçilenbanka.Name + "\n" +
           "Banka Komisyonu: " + seçilenbanka.getKomisyon(seçilenürün.Price) + "\n" +
           "Seçilen Kargo: " + seçilenkargo.Name + "\n" +
           "Kargo Ücreti: " + kargoücreti + "\n" +
           "Toplam Fiyat: " + (Total));
            
            double x;
            x = seçilenürün.sadeceKdv() * 100 / Total;
            Console.WriteLine("Kdv fiyatının, toplam fiyat içindeki oranı: " + x);

                       
            Console.ReadLine();
            

        }

    }

}

