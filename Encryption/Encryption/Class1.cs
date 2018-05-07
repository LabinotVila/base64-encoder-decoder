using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public class toBase64
    {
		//ENKRIPTIMI
		//Hapat per me ba Encode n'Baz 64:
		//1. Na vyn tekstin ASCII me kthy ne tekst binar me 8 bite.
		//2. Na vyn tekstin binar me ka 8 bite me nda me ka 6 bite.
		//3. Na vyn me fitu numer prej numrit me 6 bite: x*2^5 + x*2^4 + x*2^3...
		//4. Na vyn qat numer me kthy n'njo me baz 64 (qe osht 'range' te funksioni convertIntToChar)
										//indeksi
        public char convertIntToChar(int number) //Masi vargu i ka 6 bita n'fillim, numri nuk mundet me qen ma i madh se 63, per at numrin ton e krahasojm me indeksin
        {										 //e 'range', nese numri osht sa indeksi (i == numri), ktheje qat karakter.									
            char found = 'a'; //ska arsye t'vecqant, mundemi me ba char found = 'b' ose char found
            string range = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

            for (int i = 0; i < range.Length; i++)
            {
                if (number == i)
                {
                    found = range[i];
                    break;
                }
            }

            return found;
        }

        StringBuilder first = new StringBuilder(); //na vyn stringbuilderi se ma leht mujm me manovru me to, me string psh smundesh me shti n'indekt t'par diqka
        public string convertIntToBinary(int number)	//e me stringbuilder mujm leht me kry shum gjana, ky funksioni e kthen nji numer n'binar, qfardo numri (n'rastin 
        {								//jo ma shum se 64.
            if (number == 1) 		//kjo osht hapi i fundit kur gjindet numri binar, masi gjith osht 1 numri i fundit ne numra binar. Tani e dim qe 
            {						//numrat binar lexohet prej posht -> tenalt masi t'gjindet, per at arsye ne nuk po ja bojm first.Append() - qe e shtin numrin n'rren 
                first.Insert(0, 1);	//t'stringut, po ja bajm Insert (0, 1), i thojm te indeksi 0 (n'fillim', shtine numrin 1 edhe i bjen qe po e lexojm numrin binar 
									//prej posht te nalt
                while (first.Length % 8 != 0) //nese na vyn qe masi po duhet me kthy tekstin ton n'8 bita, nese psh numri nuk i ka 8 bita mas konvertimit, me ja shtu ne 
                {							//se qashtu e lyp mnyra e enkodimit. Numri mundet me i pas 6 bita ose 5, ose numri 1 e ka 1 bit ama kur t'kaloje naper ket proces 
                    first.Insert(0, 0);		//bahet 8 bita patjeter 
                }

                return first.ToString(); 
            }
            if (number % 2 == 0) //nese numri osht cift, shtine 0 te indeksi 0 (me lexu prej posht -> nalt)
            {
                first.Insert(0, 0);
            }
            if (number % 2 == 1) //nese numri osht tek, shtine 1 te indeksi 0 
            {
                first.Insert(0, 1);
            }

            number = number / 2; //tani na vyn me pjestu numrin me 2 edhe me shti apet n'ket funksion deri sa numri t'bahet numri 1
            convertIntToBinary(number); //funksion 'rekurziv'

            return first.ToString(); //ky hap s'ekzekutoher kurr (egzekutohet)
        }

		//kodi fillon ketu
        StringBuilder second = new StringBuilder();
        public string convertTextToBinary(string text) //tash tu e perdor qat funksionin nalt qe 1 numer ta kthen n'binar, leht mujm me 1 unaz me kalu naper krejt 
        {												//anetaret e tekstit edhe mi kthy njo ka njo n'binar edhe mi shti me 1 stringbuilder. 			
            byte[] byteArray = Encoding.ASCII.GetBytes(text); //i kthen komplet karakteret n'ASCII vlera
			
			//string asd = 'diqka'
			//byte[] asd = {70, 82, 95}

            for (int i = 0; i < byteArray.Length; i++) //i shtojm bita me u ba 8
            {
                first.Clear();
                string binaryNumber = convertIntToBinary(byteArray[i]); //po e gjajm numrin binar tu e shti te qaj funksioni nalt 
                second.Append(binaryNumber); //po e shtijm numrin binar 'binaryNumber' n'rren n'stringbuilder 


            }

            return second.ToString(); //dmth n'fun t'ktij programi, ka me u kthy nji varg 8*x bitsh
        }

        StringBuilder third = new StringBuilder();
        public string splitBySixBits(string text) //tash ja nis mu enkodu, kur krejt qat vargun 8*x bitsh qe e fitojm, na vyn me nda kah 6. Se me 6 bita numri ma i madh qe 
        {					//formohet osht 63 qe s'ka qare pa hyj n'njanin prej qatyneve 'range'
            int sum = 0; 	//na vyn nji shum me ru dikun 
            char pos = '1'; 	

            if (text.Length % 6 != 0)
            {
                text = text.PadRight(text.Length + (6 - text.Length % 6), '0'); //masi ti ndajm kah 6, nese teksti.length nuk osht shumfish i 6, bane padding (me zgjanu deri 
            }																			//sa t'bahet shumfish i 6


            for (int i = 0; i < text.Length; i = i + 6) //tash masi cdo 6 bita na vyn me i kalu per me i marr numrat, e bajm i = i + 6
            {
                if (text[i].Equals(pos)) //psh merre numrin 10010011, e ndajm ket numer n'100100 | 11 (6 bitat e par), edhe po thojm nese numri i par osht 1, shtoja 32
                {
                    sum = sum + 32;
                }
                if (text[i + 1].Equals(pos)) //nese numri i dyt osht 1, shtoja 16. Njejt me 2^5 + 2^4 + 2^3 + 2^2 + 2^1 + 2^0 = nji numer 0-63 bitsh
                {
                    sum = sum + 16;
                }
                if (text[i + 2].Equals(pos))
                {
                    sum = sum + 8;
                }
                if (text[i + 3].Equals(pos))
                {
                    sum = sum + 4;
                }
                if (text[i + 4].Equals(pos))
                {
                    sum = sum + 2;
                }
                if (text[i + 5].Equals(pos))
                {
                    sum = sum + 1;
                }

                third.Append(convertIntToChar(sum)); //tash po i thojm qe qat numrin qe e ke fitu e qe sosht ma shum se 63 bita, ktheje n'karakter edhe shtine n'stringbuilder 
                sum = 0; //tani bane shumen 0 mos me na u perzi me at nalt

            }

            return third.ToString(); //edhe n'fund kthehet kodi n'baz 64
        }

        public string addPaddingToText(string text) //tash me e dit ku kryhet, duhemi me ja shtu padding ( '=' ) osht algoritem i gatshem edhe vec na vyn me kontrollu 
        {										//nese gjatsia e tekstit tone nuk osht % 4, shtoji barazime deri sa t'bahet modul i 4. 
            if (text.Length % 4 != 0)
            {
                text = text.PadRight(text.Length + (4 - text.Length % 4), '='); //tani nese teksti psh del n'fund xx bahet xx== ose yyy = yyy=. Vec 2 vlera 
            }																	//kurr se 8 bita - 6 bita = 2 bita, 2 jan gjith, tani ose nji = ia shtojm ose dy.		

            return text;
        }

        public string Encode(string text) //tani qe perdorusi mos me i shkru 10 funksione me ju konvertu n'baz 64, e kem shkru ket funksion 
        {
            string string1 = convertTextToBinary(text); //i marrim krejt bitat qe jan 8
            string string2 = splitBySixBits(string1); //i ndajm ka 6 e i kthejm me baz 64

            first.Clear(); //i pastrojm builderat qe nese shkrun apet useri, mos me ju ba stack
            second.Clear();
            third.Clear();

            return addPaddingToText(string2); //edhe e kthejm tekstin final me padding
        }
    }
}