using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Swimmy
{
    public class InputValidation
    {

        public static bool ValidaNomeUtente(String nomeUtente)
        {
            bool risultato = true;
            var espressioneRegolare = new System.Text.RegularExpressions.Regex(@"^([a-zA-Z0-9])+$");    //lettere, numeri
            if (espressioneRegolare.IsMatch(nomeUtente) == false)
            {
                risultato = false;
            }
            return risultato;
        }

        public static bool ValidaPassword(String p1, String p2)
        {
            bool risultato = true;
            if (p1.Equals(p2) == false)
            {
                risultato = false;
            }

            var espressioneRegolare = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9_\*\-\+\!\?\,\:\;\.\xE0\xE8\xE9\xF9\xF2\xEC\x27]{6,40}");    //min 6, max 40 di caratteri, numeri, _ * – + ! ? , : ; . e lettere accentate
            if (espressioneRegolare.IsMatch(p1) == false)
            {
                risultato = false;
            }
            return risultato;
        }

        public static bool ValidaNumTelefono(String numTel)
        {
            bool risultato = true;
            var espressioneRegolare = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
            if (espressioneRegolare.IsMatch(numTel) == false)
            {
                risultato = false;
            }
            return risultato;
        }

        public static bool ValidaNome(String input)
        {
            bool risultato = true;
            var espressioneRegolare = new System.Text.RegularExpressions.Regex(@"^([a-zA-Z\xE0\xE8\xE9\xF9\xF2\xEC\x27]\s?)+$");  //caratteri, lettere accentate apostrofo e un solo spazio fra le parole
            if (espressioneRegolare.IsMatch(input) == false)
            {
                risultato = false;
            }
            return risultato;
        }

        public static bool ValidaCAP(String cap)
        {
            bool risultato = true;
            var espressioneRegolare = new System.Text.RegularExpressions.Regex(@"^\d{5}$");  //5 numeri
            if (espressioneRegolare.IsMatch(cap) == false)
            {
                risultato = false;
            }
            return risultato;
        }

        public static bool ValidaEmail(String email)
        {
            bool risultato = true;
            var espressioneRegolare = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$");  //caratteri e . _ % – + @ + caratteri compreso . + . + min 2, max 4 caratteri 
            if (espressioneRegolare.IsMatch(email) == false)
            {
                risultato = false;
            }
            return risultato;
        }

        public static bool ValidaCF(String cf)
        {
            bool risultato = true;
            var espressioneRegolare = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z]{6}\d\d[a-zA-Z]\d\d[a-zA-Z]\d\d\d[a-zA-Z]");  //
            if (espressioneRegolare.IsMatch(cf) == false)
            {
                risultato = false;
            }
            return risultato;
        }

      
    }
}