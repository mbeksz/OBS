
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciSistemi
{
    public class ogrenci
    {
        private int oNo, vize1, vize2, final;
        private string oName, okulName;
        private string oSurname;

        public ogrenci(int oNo, string oName, string oSurname, int vize1, int vize2, int final, string okulName)
        {
            this.oNo = oNo;
            this.oName = oName;
            this.oSurname = oSurname;
            this.vize1 = vize1;
            this.vize2 = vize2;
            this.final = final;
            this.okulName = okulName;

        }

        public void ogrenciBilgileriGoster()
        {
            Console.WriteLine($"Ogrenci adi {oName} ");
            Console.WriteLine($"Ogrenci soyadi {oSurname} ");
            Console.WriteLine($"Ogrenci no {oNo} ");
            Console.WriteLine($"Ogrenci vize1 {vize1} ");
            Console.WriteLine($"Ogrenci vize2 {vize2} ");
            Console.WriteLine($"Ogrenci final {final} ");
        }

        public double ogrenciOrtBul()
        {
            double ort = (vize1 * 0.2 + vize2 * 0.2 + final * 0.6);
            return ort;
        }
        public void okulgetir()
        {
            Console.WriteLine("Ogrencinin okulu " + okulName);
        }


    }
}