using System;
using System.Collections.Generic;

namespace OgrenciSistemi
{
    class Program
    {
        static Dictionary<string, string> kullaniciBilgileri = new Dictionary<string, string>();
        static Dictionary<string, Dictionary<int, ogrenci>> ogrenciBilgileri = new Dictionary<string, Dictionary<int, ogrenci>>();
        static string aktifOgretmen;

        static void Main()
        {
            KullaniciBilgileriEkle("Ece", "12366");
            KullaniciBilgileriEkle("Musti", "78900");

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Kullanıcı Adı: ");
                string kullaniciAdi = Console.ReadLine();

                Console.Write("Şifre: ");
                string sifre = Console.ReadLine();

                if (KullaniciGirisDogrulama(kullaniciAdi, sifre))
                {
                    Console.WriteLine("Giriş başarılı. Uygulamaya hoş geldiniz.");
                    aktifOgretmen = kullaniciAdi; // Aktif öğretmeni kaydet
                    UygulamayiBaslat();
                    break;
                }
                else
                {
                    Console.WriteLine("Kullanıcı adı veya şifre hatalı. Lütfen tekrar deneyin.");
                }

                if (i == 2)
                {
                    Console.WriteLine("3 kez yanlış giriş yaptınız. Program kapanıyor...");
                    return;
                }
            }
        }

        static void UygulamayiBaslat()
        {

                Console.Write("Öğrenci No: ");
                int oNo = int.Parse(Console.ReadLine());

                Console.Write("Öğrenci Adı: ");
                string oName = Console.ReadLine();

                Console.Write("Öğrenci Soyadı: ");
                string oSurname = Console.ReadLine();

                Console.Write("Vize 1: ");
                int vize1 = int.Parse(Console.ReadLine());

                Console.Write("Vize 2: ");
                int vize2 = int.Parse(Console.ReadLine());

                Console.Write("Final: ");
                int final = int.Parse(Console.ReadLine());

                Console.Write("Okul Adı: ");
                string okulName = Console.ReadLine();

                ogrenci ogrenci1 = new ogrenci(oNo, oName, oSurname, vize1, vize2, final, okulName);


            while (true)
            {
                if (!ogrenciBilgileri.ContainsKey(aktifOgretmen))
                {
                    ogrenciBilgileri[aktifOgretmen] = new Dictionary<int, ogrenci>();
                }

                ogrenciBilgileri[aktifOgretmen][oNo] = ogrenci1;

                Console.WriteLine("Yapmak istediğiniz işlemi seçiniz");
                islemler();
                int secim = int.Parse(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        Console.WriteLine("Öğrenci bilgileri gösteriliyor");
                        ogrenci1.ogrenciBilgileriGoster();
                        break;
                    case 2:
                        double ogrenciOrt = ogrenci1.ogrenciOrtBul();
                        Console.WriteLine("Ortalaması: " + ogrenciOrt);
                        break;
                    case 3:
                        Console.WriteLine("Okulunun adı: " + okulName);
                        break;
                    case 4:
                        Console.WriteLine("Ana ekrana dönülüyor...");
                        Main();
                        break;
                    case 5:
                       Console.WriteLine("Çıkış yapılıyor...");
                        return;
                    
                    default:
                        Console.WriteLine("Lütfen geçerli bir sayı giriniz!");
                        break;
                }
            }
        }

        static void islemler()
        {
            Console.WriteLine("1: Öğrenci bilgisi göster");
            Console.WriteLine("2: Öğrenci ortalamasını göster");
            Console.WriteLine("3: Öğrenci okulunu göster");
            Console.WriteLine("4: Öğretmen giriş sayfası");
            Console.WriteLine("5: Çıkış yap");
        }



        static void KullaniciBilgileriEkle(string kullaniciAdi, string sifre)
        {
            kullaniciBilgileri[kullaniciAdi] = sifre;
        }

        static bool KullaniciGirisDogrulama(string kullaniciAdi, string sifre)
        {
            if (kullaniciBilgileri.ContainsKey(kullaniciAdi))
            {
                return kullaniciBilgileri[kullaniciAdi] == sifre;
            }

            return false;
        }
    }
}
