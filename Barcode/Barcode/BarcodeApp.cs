using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ZXing;

namespace Barcode
{
    public  class BarcodeApp
    {
        // C:\Users\pc\Desktop\git\C#\Barcode\Barcode
        private string mainDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
        private string barcodeJsonFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString() + "\\barcode.json";
        private void Init()
        {
            string barcodePhotoDirectory = mainDirectory + "\\BarcodeImage";

            if (!Directory.Exists(barcodePhotoDirectory))
            {
                Directory.CreateDirectory(barcodePhotoDirectory);
                
            }
            if(!File.Exists(barcodeJsonFilePath)) 
            {
               using var fs =  File.Create(barcodeJsonFilePath);
               fs.Dispose();
               File.WriteAllText(barcodeJsonFilePath, "[]");
            }
        }
        public void Start() 
        {
            Init();
            Console.Write("Barkod üretmek için (1)\nBarkod Okutmak için (2)\n=>");
            var islem = Console.ReadLine().Trim();
            switch (islem) 
            {
                case "1":
                    GenerateBarcode();

                    break;
                case "2":
                    GetBarcode();
                    break;
                default:
                    Console.WriteLine("geçersiz işlem");
                break;
            }
            
           
           
            
        }
        public void WriteFile(Barcode barcode) 
        { 
            List<Barcode> barcodes = ReadFile();
            barcodes.Add(barcode);
            string barcodesString = JsonSerializer.Serialize(barcodes);
            File.WriteAllText(barcodeJsonFilePath, barcodesString);


        }
        public List<Barcode> ReadFile() 
        { 
            string barcodesString = File.ReadAllText(barcodeJsonFilePath);
            return JsonSerializer.Deserialize<List<Barcode>>(barcodesString);
        }
        public Barcode GetFileBarcode(string barcode)
        {
            return ReadFile().FirstOrDefault(b => b.Value == barcode);
        }
        public void GenerateBarcode()
        {
            Barcode _barcode = new Barcode();
            Console.Write("Barcode üretilecek ürün ismi\n=>");
            _barcode.Name = Console.ReadLine().Trim();
            Console.Write("Barcode üretilecek ürünün barcode değeri\n=>");
            _barcode.Value = Console.ReadLine().Trim();
            
            _barcode.FilePath = mainDirectory + "\\BarcodeImage\\" + _barcode.Value + ".png";
            _barcode.Id = Barcode.nextId();
           
            WriteFile(_barcode);
            WriteBarcode(_barcode.Value, _barcode.FilePath);
        } 
        public void GetBarcode() 
        {
            Console.Write("Okutulacak barkodun dosya dizinini giriniz\n=>");
            string photoPath = Console.ReadLine().Trim();
            var barcodeValue = ReadBarcode(photoPath);
            Barcode barcode =  GetFileBarcode(barcodeValue);
            Console.Write("\nBarkodun ürün ismi: " + barcode.Name +"\n"+ " Barkodun ürün Id'si: " + barcode.Id );
        }
        public void WriteBarcode(string barcodeValue,string imagePath) 
        {

            //  
            BarcodeWriter barcodeWriter = new BarcodeWriter()
            {
                Format = BarcodeFormat.CODE_128
            }; 
          
            var img = barcodeWriter.Write(barcodeValue);
            img.Save(imagePath);
            img.Dispose();

        }
        public string  ReadBarcode(string imagePath) 
        {
             // C:\Users\pc\Desktop\git\C#\Barcode\Barcode\BarcodeImage\123456.png
            BarcodeReader barcodeReader = new BarcodeReader();
            var barcodeBitmap = (Bitmap)Bitmap.FromFile(imagePath);
            var barcodeResult = barcodeReader.Decode(barcodeBitmap);
            barcodeBitmap.Dispose();
            return barcodeResult.Text;
        }
    }
}
