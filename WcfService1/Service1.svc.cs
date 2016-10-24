using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string check(string pesel)
        {
            
            int[] mnozniki = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            Int32 i_day = Int32.Parse(string.Concat(pesel[4].ToString(), pesel[5].ToString()));

            if(pesel.Length == 11){
                int li = 0;
                while(li < pesel.Length)
            {
                if (char.IsLetter(pesel[li]))
                {
                    return string.Format("PESEL nie może zawierać liter !");
                    break;
                }
                li = li + 1;
            }
                    if (i_day > 31)
                      {
                          return string.Format("Błąd danych. Dzień miesiaca powyzej 31.");
                      }
                    else if (i_day < 31){
                         int sum = 0;            
                            for(int i = 0; i < mnozniki.Length; i++)
                                {
                                sum+=mnozniki[i]*int.Parse(pesel[i].ToString());
                                }
                                int reszta = sum%10;
                                    if(reszta == 0 && (pesel[10].ToString()) == "0"){
                                        return string.Format("Twoj pesel jest prawidłowy: {0}", pesel);
                                    }
                                    else if(((10 - reszta).ToString()) == (pesel[10].ToString()))
                                    {
                                        return string.Format("Twoj pesel jest prawidłowy: {0}", pesel);
                                    }
                                    else
                                    {
                                        return string.Format("Twoj pesel jest nieprawidłowy!");
                                    }
                         }
            }
                else if(pesel.Length < 11 && pesel.Length > 0)
                {
                    return string.Format("Twoj pesel jest zbyt krótki! {0}", pesel);
                }
                    else if (pesel.Length > 11)
                    {
                        return string.Format("Twoj pesel jest zbyt długi! {0}", pesel);
                    }
                        else if (pesel.Length == 0)
                        {
                            return string.Format("Nie wpisałeś nic..");
                        }
           
            return null;
        }

        public string check_konto(string konto)
        {
            if (konto.Length == 26 || konto.Length== 28)
                {
                    return string.Format("Długość konta jest prawidłowa");
                }
                    else if (konto.Length < 26 && konto.Length > 0)
                    {
                        return string.Format("Numer konta za krótki!");
                    }
                        else if (konto.Length > 26)
                        {
                            return string.Format("Zbyt długi numer konta!");
                        }
                            else if (konto.Length == 0)
                            {
                                return string.Format("Nie wpisałeś nic... Wpisz dane.");
                            }
            return null;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
